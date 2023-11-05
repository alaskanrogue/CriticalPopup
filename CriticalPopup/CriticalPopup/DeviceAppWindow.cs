using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using System.Net.NetworkInformation;
#if ANDROID
using AndroidX.Media;
#endif

namespace CriticalPopup
{
	public static class DevAppWin
	{
		internal static string model;
		internal static string manufacturer;
		internal static int platform;
		internal static int devicePlatform;
		internal static string osVersion;
		internal static int deviceType;
		internal static int physical;

		// App Startup Status
		public static bool AppStarting = true;

		// Device Screen Dimensions
		internal static double DeviceScreenWidth;
		internal static double DeviceScreenHeight;
		internal static double DeviceScreenDensity;
		internal static double ScreenWidth;
		internal static double ScreenHeight;

		// iPhone 12 Base Sizing For Scaling Purposes
		public static double AppContentWidthBase = 393;
		public static double AppContentHeightBase = 670;

		// App Window Dimensions
		public static double AppWidth;
		public static double AppHeight;
		internal static double CenterColumnWidth;
		internal static double LeftRightColumnWidth;

		public static double AppContentWidth;
		public static double AppContentHeight;
		public static double AppContentWidthSizingFactor = 1;
		public static double AppContentHeightSizingFactor = 1;

		//internal static int ScreenOrientation;
		//internal static int ScreenRotation;

		internal static double MicroFontBase = 12;
		internal static double SmallFontBase = 14;
		internal static double MediumFontBase = 18;
		internal static double LargeFontBase = 22;

		internal static double MicroFontLineHeightBase = 6;
		internal static double SmallFontLineHeightBase = 9;
		internal static double MediumFontLineHeightBase = 13;
		internal static double LargeFontLineHeightBase = 18;

		internal static double MicroFontRowCharactersBase = 50;
		internal static double SmallFontRowCharactersBase = 40;
		internal static double MediumFontRowCharactersBase = 30;
		internal static double MediumFontRowCharactersSmallLabelBase = 25;
		internal static double LargeFontRowCharactersBase = 30;

		internal static double MicroFont;
		internal static double SmallFont;
		internal static double MediumFont;
		internal static double LargeFont;

		internal static double MicroFontLineHeight;
		internal static double SmallFontLineHeight;
		internal static double MediumFontLineHeight;
		internal static double LargeFontLineHeight;

		internal static double MicroFontRowCharacters;
		internal static double SmallFontRowCharacters;
		internal static double MediumFontRowCharacters;
		internal static double MediumFontRowCharactersSmallLabel;
		internal static double LargeFontRowCharacters;


		// Images
		internal static string ImageFolder;

		// to remove
		internal static double ScreenWidthRef;
		internal static double ScreenHeightRef;

		public static void InitDeviceAppWindow()
		{
			// Device Model (?SMG-950U, iPhone10,6)
			var device = DeviceInfo.Model;
			model = device.ToString();

			// Manufacturer (?Samsung)
			manufacturer = DeviceInfo.Manufacturer.ToString();

			// Platform (?Android)
			string devPlatform = DeviceInfo.Platform.ToString();

			if (devPlatform == "WinUI")
			{
				platform = 1;
				devicePlatform = 1;
				ImageFolder = "";
			}
			else if (devPlatform == "iOS")
			{
				platform = 2;
				devicePlatform = 2;
			}
			else if (devPlatform == "Android")
			{
				platform = 3;
				devicePlatform = 3;
				ImageFolder = "";
			}
			else if (devPlatform == "Tizen")
			{
				platform = 4;
				devicePlatform = 4;
				ImageFolder = "";
			}
			else if (devPlatform == "macOS")
			{
				platform = 5;
				devicePlatform = 5;
				ImageFolder = "";
			}
			else if (devPlatform == "MacCatalyst")
			{
				platform = 6;
				devicePlatform = 6;
				ImageFolder = "";
			}
			else if (devPlatform == "tvOS")
			{
				platform = 7;
				devicePlatform = 7;
				ImageFolder = "";
			}
			else if (devPlatform == "watchOS")
			{
				platform = 8;
				devicePlatform = 8;
				ImageFolder = "";
			}

			// Operating System Version Number (7.0)
			osVersion = DeviceInfo.Version.ToString();

			// Idiom (Phone)
			string idiom = DeviceInfo.Idiom.ToString();
			if (idiom == "Phone")
			{
				deviceType = 1;
			}
			else if (idiom == "Tablet")
			{
				deviceType = 2;
			}
			else if (idiom == "Desktop")
			{
				deviceType = 3;
			}
			else if (idiom == "TV")
			{
				deviceType = 4;
			}
			else if (idiom == "Watch")
			{
				deviceType = 5;
			}
			else
			{
				deviceType = 6;
			}

			// Physical / Virtual Device
			physical = (int)DeviceInfo.DeviceType;

			SetAppSize();
		}

		// Initialize Display
		public static void SetAppSize()
		{
			try
			{
				DeviceScreenDensity = 1;

				DeviceScreenWidth = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo.Width;
				DeviceScreenHeight = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo.Height;
				DeviceScreenDensity = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo.Density;

				if (devicePlatform == 1) // Windows
				{
					ScreenWidth = 370;
					ScreenHeight = 800;
				}
				else
				{
					ScreenWidth = DeviceScreenWidth / DeviceScreenDensity;
					ScreenHeight = DeviceScreenHeight / DeviceScreenDensity;
				}

				double widthSizeFactor = ScreenWidth / ScreenHeight;
				double heightSizeFactor = ScreenHeight / ScreenWidth;

				// Phone
				if (deviceType == 1)
				{
					AppWidth = Math.Floor(ScreenWidth * .95);
					AppHeight = Math.Floor(AppWidth * 2);
				}
				// Tablet
				else if (deviceType == 2)
				{
					AppWidth = Math.Floor(ScreenWidth * .95);
					AppHeight = Math.Floor(AppWidth * 2);
				}
				// Desktop
				else if (deviceType == 3)
				{
					AppHeight = Math.Floor(ScreenHeight * .8);
					AppWidth = Math.Floor(AppHeight * widthSizeFactor);
				}
				// TV
				else if (deviceType == 4)
				{
					AppHeight = Math.Floor(ScreenHeight * .8);
					AppWidth = Math.Floor(AppHeight * widthSizeFactor);
				}
				// Watch
				else if (deviceType == 5)
				{
				}
				// Anything Else
				else
				{
				}

				ScreenWidthRef = ScreenWidth;
				ScreenHeightRef = ScreenHeight;

				LeftRightColumnWidth = Math.Ceiling(AppWidth * .05);
				CenterColumnWidth = Math.Ceiling(AppWidth - (LeftRightColumnWidth * 2));
			}
			catch (Exception ex)
			{
			}
		}

		internal static void SetFontSizes()
		{
			try
			{
				MicroFont = Math.Floor(MicroFontBase * AppContentHeightSizingFactor);
				SmallFont = Math.Floor(SmallFontBase * AppContentHeightSizingFactor);
				MediumFont = Math.Floor(MediumFontBase * AppContentHeightSizingFactor);
				LargeFont = Math.Floor(LargeFontBase * AppContentHeightSizingFactor);

				SetFontLineHeights();
			}
			catch (Exception ex)
			{
			}
		}

		internal static void SetFontLineHeights()
		{
			MicroFontLineHeight = Math.Floor(MicroFontLineHeightBase * AppContentHeightSizingFactor);
			SmallFontLineHeight = Math.Floor(SmallFontLineHeightBase * AppContentHeightSizingFactor);
			MediumFontLineHeight = Math.Floor(MediumFontLineHeightBase * AppContentHeightSizingFactor);
			LargeFontLineHeight = Math.Floor(LargeFontLineHeightBase * AppContentHeightSizingFactor);
		}

		internal static void SetFontRowCharacters()
		{
			MicroFontRowCharacters = Math.Floor(MicroFontRowCharactersBase * AppContentWidthSizingFactor);
			SmallFontRowCharacters = Math.Floor(SmallFontRowCharactersBase * AppContentWidthSizingFactor);
			MediumFontRowCharacters = Math.Floor(MediumFontRowCharactersBase * AppContentWidthSizingFactor);
			MediumFontRowCharactersSmallLabel = Math.Floor(MediumFontRowCharactersSmallLabelBase * AppContentWidthSizingFactor);
			LargeFontRowCharacters = Math.Floor(LargeFontRowCharactersBase * AppContentWidthSizingFactor);
		}
	}
}