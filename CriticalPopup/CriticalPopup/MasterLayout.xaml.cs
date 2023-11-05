using System.Threading.Tasks;

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Graphics;

#if IOS
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
#endif

namespace CriticalPopup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterLayout : ContentPage
    {
        internal static decimal heightFactor;

        //internal Rectangle frame;

        /// Main Grid Layout
        // App Width / Height
        internal double LRW;
        internal double LRH;
        // Middle Column
        internal double LR0;
        // Left / Right Columns
        internal double LR1;

        // Header Width / Height
        internal double HW;
        internal double HH;

        // Logo Width / Height
        internal double LW0;
        internal double LH0;

        /// Header / Footer Height
        //internal double H0;
        //internal double F0;

        // Remaining App Height
        internal double RAH;

        // Row Heights
        internal double R0;
        internal double R1;
        internal double R2;
        internal double R3;
        internal double R4;
        internal double R5;
        internal double R6;
        internal double R7;
        internal double R8;

        // Label Rows
        internal int textRows;

        internal MasterLayout()
        {
            heightFactor = 1;
		}

		internal void Layout(int style, bool header, bool filler, ContentPage currentScreen, double p0, double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8)
        {
            try
            {
				// Device Screen Dimensions
				double dsw = DevAppWin.DeviceScreenWidth;
				double dsh = DevAppWin.DeviceScreenHeight;
				double dsd = DevAppWin.DeviceScreenDensity;

				// Set the device margins
				LRW = DevAppWin.AppWidth;
                LRH = DevAppWin.AppHeight;
                LR0 = DevAppWin.CenterColumnWidth;
                LR1 = DevAppWin.LeftRightColumnWidth;

                currentScreen.WidthRequest = DevAppWin.AppWidth;
                currentScreen.HeightRequest = DevAppWin.AppHeight;

				//currentScreen.Content.Margin = new Thickness(0, 0, 0, 0);

				// Create the Frame
				AbsoluteLayout.SetLayoutFlags(currentScreen, AbsoluteLayoutFlags.SizeProportional);
                AbsoluteLayout.SetLayoutBounds(currentScreen, new Rect(0, 0, currentScreen.WidthRequest, currentScreen.HeightRequest));

				// Anchor the Frame
                currentScreen.Content.AnchorX = 0;
                currentScreen.Content.AnchorY = 0;
                currentScreen.Content.HeightRequest = currentScreen.HeightRequest;
                currentScreen.Content.WidthRequest = currentScreen.WidthRequest;

                // Finalize App Window Frame
                currentScreen.Focus();
                currentScreen.ForceLayout();

                // Set the App Window Size
                App.AppWidth = LRW;
                App.AppHeight = LRH;

                // Create the Header 
                if (header)
                {
                    // Size the Base Grid
                    currentScreen.Content.FindByName<Grid>("BaseGrid").WidthRequest = LRW;
                    currentScreen.Content.FindByName<Grid>("BaseGrid").HeightRequest = LRH;

					currentScreen.Content.FindByName<Grid>("BaseGrid").BackgroundColor = Microsoft.Maui.Graphics.Colors.LightGrey;

					// Header Grid Layout
					HW = DevAppWin.AppWidth;
                    HH = Math.Ceiling(HW * 0.295);

					// Set the Content Size Elements
					DevAppWin.AppContentWidth = HW;
					DevAppWin.AppContentHeight = DevAppWin.AppHeight - HH;

					DevAppWin.AppContentWidthSizingFactor = Math.Round((DevAppWin.AppContentWidth / DevAppWin.AppContentWidthBase), 2);
					if (DevAppWin.AppContentWidthSizingFactor > 1)
					{
						DevAppWin.AppContentWidthSizingFactor = 1;
					}

					DevAppWin.AppContentHeightSizingFactor = Math.Round((DevAppWin.AppContentHeight / DevAppWin.AppContentHeightBase), 2);
					if (DevAppWin.AppContentHeightSizingFactor > 1)
					{
						DevAppWin.AppContentHeightSizingFactor = 1;
					}

					RAH = LRH;

					DevAppWin.SetFontSizes();
					DevAppWin.SetFontRowCharacters();

					double HC0W = HH;
                    double HC1W = HW - HH;

                    currentScreen.Content.FindByName<RowDefinition>("HeaderGrid").Height = HH;
                    currentScreen.Content.FindByName<RowDefinition>("LayoutGrid").Height = LRH - HH;

                    // Size the Header Grid Base
                    currentScreen.Content.FindByName<Grid>("HeaderRoot").WidthRequest = HW;
                    currentScreen.Content.FindByName<Grid>("HeaderRoot").HeightRequest = HH;

                    if (style == 1)
                    {
                        currentScreen.Content.FindByName<ColumnDefinition>("HCol0").Width = Math.Ceiling(HW * 0.1);
                        currentScreen.Content.FindByName<ColumnDefinition>("HCol1").Width = Math.Ceiling(HW * 0.8);
                        currentScreen.Content.FindByName<ColumnDefinition>("HCol2").Width = Math.Ceiling(HW * 0.1);
                        currentScreen.Content.FindByName<RowDefinition>("HRow0").Height = HH;

                        currentScreen.Content.FindByName<Image>("TestLogo").Source = DevAppWin.ImageFolder + "logo.png";
                        currentScreen.Content.FindByName<Image>("TestLogo").WidthRequest = HW - HH;
                        currentScreen.Content.FindByName<Image>("TestLogo").HeightRequest = HH;
                        currentScreen.Content.FindByName<Image>("TestLogo").IsVisible = true;
                    }
                    else
                    {
                        currentScreen.Content.FindByName<ColumnDefinition>("HCol0").Width = HC0W;
                        currentScreen.Content.FindByName<ColumnDefinition>("HCol1").Width = HC1W;
                        currentScreen.Content.FindByName<RowDefinition>("HRow0").Height = HH;

                        currentScreen.Content.FindByName<Image>("Headerlogo").Source = DevAppWin.ImageFolder + "logo.png";
                        currentScreen.Content.FindByName<Image>("Headerlogo").WidthRequest = HH;
                        currentScreen.Content.FindByName<Image>("Headerlogo").HeightRequest = HH;
                        currentScreen.Content.FindByName<Image>("Headerlogo").IsVisible = true;

                        currentScreen.Content.FindByName<Image>("Header").Source = DevAppWin.ImageFolder + "header.png";
                        currentScreen.Content.FindByName<Image>("Header").WidthRequest = HW - HH;
                        currentScreen.Content.FindByName<Image>("Header").HeightRequest = HH;
                        currentScreen.Content.FindByName<Image>("Header").IsVisible = true;
                    }

					RAH = LRH - HH;

                    // Size the LayoutRoot Grid Base
                    currentScreen.Content.FindByName<Grid>("LayoutRoot").WidthRequest = LRW;
                    currentScreen.Content.FindByName<Grid>("LayoutRoot").HeightRequest = RAH;
                }
                else
                {
                    // Size the Layout Grid Base
                    currentScreen.Content.FindByName<Grid>("BaseGrid").WidthRequest = LRW;
                    currentScreen.Content.FindByName<Grid>("BaseGrid").HeightRequest = LRH;

                    // Size the LayoutRoot Grid Base
                    currentScreen.Content.FindByName<RowDefinition>("LayoutGrid").Height = LRH;

                    currentScreen.Content.FindByName<Grid>("LayoutRoot").WidthRequest = LRW;
                    currentScreen.Content.FindByName<Grid>("LayoutRoot").HeightRequest = LRH;
                }

                // Layout Grid Columns
                currentScreen.Content.FindByName<ColumnDefinition>("Col0").Width = LR1;
                currentScreen.Content.FindByName<ColumnDefinition>("Col1").Width = LR0;
                currentScreen.Content.FindByName<ColumnDefinition>("Col2").Width = LR1;

				double totalPercentage = p0 + p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8;

                // Comment out for Release
                if (totalPercentage > 100)
                {
                    bool stop = true;
					if (stop)
					{
						stop = false;
					}
                }

                if (totalPercentage < 100 && filler)
                {
                    if (style == 3)
                    {
                        int inActiveRows = 0;

                        if (p3 == 1) { inActiveRows += 1; }
                        if (p4 == 1) { inActiveRows += 1; }
                        if (p5 == 1) { inActiveRows += 1; }
                        if (p6 == 1) { inActiveRows += 1; }
                        if (p7 == 1) { inActiveRows += 1; }
                        
                        double resize = Math.Floor((100 - totalPercentage) * .95);
                        resize = Math.Floor(resize / inActiveRows);
                        resize += 1;

                        if (p3 == 1) { p3 = resize; }
                        if (p4 == 1) { p4 = resize; }
                        if (p5 == 1) { p5 = resize; }
                        if (p6 == 1) { p6 = resize; }
                        if (p7 == 1) { p7 = resize - 5; }
                    }
                    else
                    {
                        p6 += Math.Floor((100 - totalPercentage) * .85);
                    }
                }

                totalPercentage = p0 + p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8;

				if (totalPercentage > 100)
                {
                    double adj = 100 - totalPercentage;
                    if (style == 3)
                    {
                        p7 -= adj;
                    }
                    else
                    {
                        p8 -= adj;
                    }
                }

                // Layout Grid Rows
                R0 = RowHeightTest(Math.Floor(RAH * (p0 / 100)));
                R1 = RowHeightTest(Math.Floor(RAH * (p1 / 100)));
                R2 = RowHeightTest(Math.Floor(RAH * (p2 / 100)));
                R3 = RowHeightTest(Math.Floor(RAH * (p3 / 100)));
                R4 = RowHeightTest(Math.Floor(RAH * (p4 / 100)));
                R5 = RowHeightTest(Math.Floor(RAH * (p5 / 100)));
                R6 = RowHeightTest(Math.Floor(RAH * (p6 / 100)));
                R7 = RowHeightTest(Math.Floor(RAH * (p7 / 100)));
                R8 = RowHeightTest(Math.Floor(RAH * (p8 / 100)));

                double totalHeight = HH + R0 + R1 + R2 + R3 + R4 + R5 + R6 + R7 + R8;

                if (style == 1)
                {
                    // Layout Grid Rows
                    currentScreen.Content.FindByName<RowDefinition>("Row0").Height = R0;
                    currentScreen.Content.FindByName<RowDefinition>("Row1").Height = R1;
                    currentScreen.Content.FindByName<RowDefinition>("Row2").Height = R2;
                    currentScreen.Content.FindByName<RowDefinition>("Row3").Height = R3;
                    currentScreen.Content.FindByName<RowDefinition>("Row4").Height = R4;
                    currentScreen.Content.FindByName<RowDefinition>("Row5").Height = R5;
                    currentScreen.Content.FindByName<RowDefinition>("Row6").Height = R6;
                    currentScreen.Content.FindByName<RowDefinition>("Row7").Height = R7;
                    currentScreen.Content.FindByName<RowDefinition>("Row8").Height = R8;

                    // Layout the Controls
                    currentScreen.Content.FindByName<Grid>("Spacer1").HeightRequest = R0;
                    currentScreen.Content.FindByName<Grid>("Content1").HeightRequest = R1;
                    currentScreen.Content.FindByName<Grid>("Spacer2").HeightRequest = R2;
                    currentScreen.Content.FindByName<Grid>("Content2").HeightRequest = R3;
                    currentScreen.Content.FindByName<Grid>("Spacer3").HeightRequest = R4;
                    currentScreen.Content.FindByName<Grid>("Content3").HeightRequest = R5;
                    currentScreen.Content.FindByName<Grid>("Spacer4").HeightRequest = R6;
                    currentScreen.Content.FindByName<Grid>("Content4").HeightRequest = R7;
                    currentScreen.Content.FindByName<Grid>("Spacer5").HeightRequest = R8;

                    double SW0 = Math.Floor(DevAppWin.CenterColumnWidth / 2);
                    double SH0 = Math.Floor(DevAppWin.CenterColumnWidth / 2);
				}
				else if (style == 2)
                {
                    // Layout Grid Rows
                    currentScreen.Content.FindByName<RowDefinition>("Row0").Height = R0;
                    currentScreen.Content.FindByName<RowDefinition>("Row1").Height = R1;
                    currentScreen.Content.FindByName<RowDefinition>("Row2").Height = R2;
                    currentScreen.Content.FindByName<RowDefinition>("Row3").Height = R3;
                    currentScreen.Content.FindByName<RowDefinition>("Row4").Height = R4;
                    currentScreen.Content.FindByName<RowDefinition>("Row5").Height = R5;
                    currentScreen.Content.FindByName<RowDefinition>("Row6").Height = R6;
                    currentScreen.Content.FindByName<RowDefinition>("Row7").Height = R7;
                    currentScreen.Content.FindByName<RowDefinition>("Row8").Height = R8;

                    // Layout the Controls
                    currentScreen.Content.FindByName<Grid>("Spacer1").HeightRequest = R0;
                    currentScreen.Content.FindByName<Grid>("Content1").HeightRequest = R1;
                    //currentScreen.Content.FindByName<Grid>("Spacer2").HeightRequest = R2;
                    //currentScreen.Content.FindByName<Grid>("Content2").HeightRequest = R3;
                    //currentScreen.Content.FindByName<Grid>("Spacer3").HeightRequest = R4;
                    //currentScreen.Content.FindByName<Grid>("Content3").HeightRequest = R5;
                    //currentScreen.Content.FindByName<Grid>("Spacer4").HeightRequest = R6;
                    currentScreen.Content.FindByName<Grid>("Content4").HeightRequest = R7;
                    currentScreen.Content.FindByName<Grid>("Spacer5").HeightRequest = R8;
                }
                else if (style == 3)
                {
                    // Layout Grid Rows
                    currentScreen.Content.FindByName<RowDefinition>("Row0").Height = R0;
                    currentScreen.Content.FindByName<RowDefinition>("Row1").Height = R1;
                    currentScreen.Content.FindByName<RowDefinition>("Row2").Height = R2 + 5;
                    currentScreen.Content.FindByName<RowDefinition>("Row3").Height = R3 + 5;
                    currentScreen.Content.FindByName<RowDefinition>("Row4").Height = R4 + 5;
                    currentScreen.Content.FindByName<RowDefinition>("Row5").Height = R5 + 5;
                    currentScreen.Content.FindByName<RowDefinition>("Row6").Height = R6 + 5;
                    currentScreen.Content.FindByName<RowDefinition>("Row7").Height = R7;
                    currentScreen.Content.FindByName<RowDefinition>("Row8").Height = R8;

                    // Layout the Controls
                    currentScreen.Content.FindByName<Grid>("Spacer0").HeightRequest = R0;
                    currentScreen.Content.FindByName<Grid>("Instructions").HeightRequest = R1;
                    currentScreen.Content.FindByName<Grid>("ImminentUse").HeightRequest = R2;
                    currentScreen.Content.FindByName<Grid>("PeriodType").HeightRequest = R2;
                    currentScreen.Content.FindByName<Grid>("TimePeriod").HeightRequest = R2;
                    currentScreen.Content.FindByName<Grid>("DatePeriod").HeightRequest = R2;
                    currentScreen.Content.FindByName<Grid>("Months").HeightRequest = R3;
                    currentScreen.Content.FindByName<Grid>("Days").HeightRequest = R3;
                    currentScreen.Content.FindByName<Grid>("Years").HeightRequest = R3;
                    currentScreen.Content.FindByName<Grid>("RepeatPeriod").HeightRequest = R4;
                    currentScreen.Content.FindByName<Grid>("Payee").HeightRequest = R5;
                    currentScreen.Content.FindByName<Grid>("CheckNo").HeightRequest = R5;
                    currentScreen.Content.FindByName<Grid>("MaximumAmount").HeightRequest = R6;
                    currentScreen.Content.FindByName<Grid>("Amount").HeightRequest = R6;
                    currentScreen.Content.FindByName<Grid>("Buttons").HeightRequest = R8;
                }
                else if (style == 5)
                {
                    // Logo
                    LW0 = Math.Floor(DevAppWin.AppWidth);
                    LH0 = Math.Floor(R4);
                }
            }
            catch (Exception ex)
            {
            }
        }

        internal void SetRowSizes()
        {
            try
            {
                App.LargeFontWidth = Math.Floor(DevAppWin.LargeFont * .8);
                App.LargeFontRowSize = (int)Math.Floor((DevAppWin.CenterColumnWidth / App.LargeFontWidth) * 1.5) - 2;

                App.MediumFontWidth = Math.Floor(DevAppWin.MediumFont * .8);
                App.MediumFontRowSize = (int)Math.Floor((DevAppWin.CenterColumnWidth / App.MediumFontWidth) * 1.5) - 2;

                App.SmallFontWidth = Math.Floor(DevAppWin.SmallFont * .8);
                App.SmallFontRowSize = (int)Math.Floor((DevAppWin.CenterColumnWidth / App.SmallFontWidth) * 1.5) - 2;

                App.MicroFontWidth = Math.Floor(DevAppWin.MicroFont * .8);
                App.MicroFontRowSize = (int)Math.Floor((DevAppWin.CenterColumnWidth / App.MicroFontWidth) * 1.5) - 2;
            }
            catch (Exception ex)
            {
            }
        }

        internal static double RowHeightTest(double pixels)
        {
            if (pixels < 0)
            {
                return 0;
            }

            return pixels;
        }

        internal bool ParaBreak(string text)
        {
            string compare = text.Substring(1, 1);

            if (compare == "\n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		internal string SetTextRows(double characters, string text)
		{
			try
			{
				int linefeed = 0;

				if (text.IndexOf("\n") > 0)
				{
					linefeed = 1;
				}

				textRows = (int)(Math.Ceiling((text.Length / characters) + linefeed));
			}
			catch (Exception ex)
			{
			}

			return text; ;
		}

		internal double GetTextRowsHeight(string text, double characters, double height)
		{
			string current = text;
			string remaining = text;

			double textLength = remaining.Length;

			string working = "";
			int rowLength = (int)characters;

			int parsePos = 0;

			textRows = 0;

			if ((remaining.Length <= 30) && !remaining.Contains("\n"))
			{
				textRows = 2;
			}
			else
			{ 
				while (remaining.Length > 0)
				{
					if (remaining.Length >= 30)
					{
						if (remaining.Length >= 32)
						{
							working = remaining.Substring(0, 32);

							if (working.Contains("\n"))
							{
								remaining = remaining.Substring(working.IndexOf("\n") + 2);

								if (remaining.Substring(0, 2) == "\n")
								{
									remaining = remaining.Substring(2);

									textRows += 2;
								}
								else
								{
									textRows += 1;
								}
							}
							else if ((working.Substring(rowLength - 1, 1) != " ") && (working.Substring(rowLength, 1) != " "))
							{
								working = remaining.Substring(0, 30);

								parsePos = 29;

								while (working.Substring(parsePos, 1) != " ")
								{
									parsePos -= 1;
								}

								if (parsePos <= 21)
								{
									textRows += 1;
								}

								remaining = remaining.Substring(parsePos + 1);
							}
							else if ((working.Substring(rowLength - 1, 1) != " ") && (working.Substring(rowLength, 1) == " "))
							{
								remaining = remaining.Substring(rowLength + 1);
							}
							else
							{
								remaining = remaining.Substring(rowLength);
							}
						}
						else if (remaining.Length == 31)
						{
							working = remaining;

							parsePos = 30;

							while (working.Substring(parsePos, 1) != " ")
							{
								parsePos -= 1;
							}

							if (parsePos <= 22)
							{
								textRows += 1;
							}

							remaining = remaining.Substring(parsePos);
						}
						else
						{
							working = remaining.Substring(0, 30);

							if (working.Contains("/n"))
							{
								remaining = remaining.Substring(working.IndexOf("/n"));

								if (remaining.Contains("/n"))
								{
									remaining = remaining.Substring(working.IndexOf("/n") + 2);

									textRows += 2;
								}
							}
							else
							{
									remaining = "";
							}
						}

						if (remaining.Length > 0)
						{
							if (remaining.Substring(0, 1) == " ")
							{
								remaining = remaining.Substring(1);

								textRows += 1;
							}
						}

						textRows += 1;
					}
					else
					{
						remaining = "";

						textRows += 3;
					}
				}

				//if (textRows > 4)
				//{
				//	textRows += (int)Math.Floor((double)textRows / 2.5);
				//}
				//else
				//{
				//	textRows += 1;
				//}

				return (textRows + 2) * height;
			}

			return (textRows * height);
		}

		internal double ButtonsHeight(double originalHeight)
        {
            try
            {
                decimal oh = Convert.ToDecimal(originalHeight);
                decimal ff = (heightFactor - 1);
                decimal xf = .2M;

                decimal bh;
                if (ff > 0)
                {
                    bh = oh * (1 - (ff * xf));
                }
                else
                {
                    bh = oh;
                }

                double buttonHeight = Convert.ToDouble(bh);
                double finalButtonHeight = Math.Floor((DevAppWin.AppHeight / (Math.Floor(872 * DevAppWin.AppContentHeightSizingFactor)) * buttonHeight));

                return finalButtonHeight;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        internal bool TotalLabelCharacters(string label1, string label2)
        {
            try
            {
                int l1 = label1.Length;
                int l2 = label2.Length;

                if ((l1 > 12) || (l2 > 12))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        internal bool TotalLabelCharacters(string label1, string label2, string label3)
        {
            try
            {
                int l1 = label1.Length;
                int l2 = label2.Length;
                int l3 = label3.Length;

                if ((l1 > 10) || (l2 > 10) || (l3 > 10))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}