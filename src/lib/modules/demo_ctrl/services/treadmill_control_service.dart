import 'dart:typed_data';

import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_blue_plus/flutter_blue_plus.dart';
import 'package:open_eqi_sports/modules/demo_ctrl/services/treadmill_status.dart';
import 'package:open_eqi_sports/modules/demo_ctrl/widgets/pages/control_page.dart';

class TreadmillControlService extends Cubit<TreadmillState> {
  BluetoothDevice? _device;
  BluetoothCharacteristic? _control;
  BluetoothCharacteristic? _workoutStatus;

  // Double underscore to ensure you use the setter
  double __requestedSpeed = 0;

  WorkoutStatus? _status;

  static const double minSpeed = 1;
  static const double maxSpeed = 6;

  TreadmillControlService(super.initialState) {
    FlutterBluePlus.setLogLevel(LogLevel.warning, color: false);
  }

  Future<void> connect() async {
    var subscription = FlutterBluePlus.onScanResults.listen(
      (results) async {
        if (results.isNotEmpty) {
          ScanResult r = results.single;
          _device = r.device;
          FlutterBluePlus.stopScan();
          await _device!.connect();
          await _setupServices();
          await _wakeup();
        }
      },
      onError: (e) => print(e),
    );
    FlutterBluePlus.cancelWhenScanComplete(subscription);

    await FlutterBluePlus.startScan(withServices: [Guid("1826")], withNames: ["CITYSPORTS-Linker"], timeout: const Duration(seconds: 15));
  }

  Future<void> _wakeup() async {
    await _control!.write([0x00]);
  }

  Future<void> start() async {
    await _control!.write([0x07]);
  }

  Future<void> stop() async {
    await _control!.write([0x08, 0x01]);
  }

  Future<void> _setSpeed(double speed) async {
    int requestSpeed = (speed * 100).toInt();
    ByteData bytes = ByteData(3);
    bytes.setUint8(0, 0x02);
    bytes.setUint16(1, requestSpeed, Endian.little);
    await _control!.write(bytes.buffer.asUint8List());
  }

  void pause() {
    // TODO: Implement pause method
    print('Pausing the treadmill');
  }

  Future<void> speedUp() async {
    _requestedSpeed += 0.5;
    await _setSpeed(_requestedSpeed);
    print('Increasing the speed of the treadmill to $_requestedSpeed km/h');
  }

  Future<void> speedDown() async {
    _requestedSpeed -= 0.5;
    await _setSpeed(_requestedSpeed);
    print('Decreasing the speed of the treadmill to $_requestedSpeed km/h');
  }

  void _processStatusUpdate(List<int> value) {
    _status = WorkoutStatus.fromBytes(value);
  }

  Future<void> _setupServices() async {
    await _device!.discoverServices();
    var fitnessMachine = _device!.servicesList.firstWhere((s) => s.uuid == Guid("1826"));
    _control = fitnessMachine.characteristics.firstWhere((c) => c.uuid == Guid("2ad9"));
    _workoutStatus = fitnessMachine.characteristics.firstWhere((c) => c.uuid == Guid("2acd"));
    _workoutStatus!.onValueReceived.listen(_processStatusUpdate);
    _workoutStatus!.setNotifyValue(true);
  }

  set _requestedSpeed(double value) {
    if (value < minSpeed) {
      value = minSpeed;
    } else if (value > maxSpeed) {
      value = maxSpeed;
    }
    __requestedSpeed = value;
  }

  double get _requestedSpeed => __requestedSpeed;
}