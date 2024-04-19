import 'dart:async';
import 'package:flutter_blue_plus/flutter_blue_plus.dart';
import 'package:open_eqi_sports/modules/hardware/bt/constants/known_services.dart';

class FitnessMachineDiscoveryService {
  late Stream<List<BluetoothDevice>> deviceStream;
  final StreamController<List<BluetoothDevice>> _deviceStreamController;

  FitnessMachineDiscoveryService() : _deviceStreamController = StreamController<List<BluetoothDevice>>.broadcast() {
    deviceStream = _deviceStreamController.stream;
  }

  Future<void> start() async {
    final scanningSub = FlutterBluePlus.onScanResults.listen((results) async {
      if (results.isNotEmpty) {
        parseResults(results);
      }
    });

    FlutterBluePlus.cancelWhenScanComplete(scanningSub);
    FlutterBluePlus.startScan(withServices: [KnownServices.fitnessMachine], timeout: const Duration(seconds: 15));
  }

  void parseResults(List<ScanResult> results) {
    _deviceStreamController.add(results.map((r) => r.device).toList());
  }
}
