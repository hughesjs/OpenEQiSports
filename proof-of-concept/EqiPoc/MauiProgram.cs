﻿using Microsoft.Extensions.Logging;

namespace EqiPoc;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
#if DEBUG
		DeviceDisplay.KeepScreenOn = true;
#endif
		
		MauiAppBuilder builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

