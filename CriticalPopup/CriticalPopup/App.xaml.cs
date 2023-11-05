namespace CriticalPopup
{
    public partial class App : Application
    {
        public static App SAPP;
        public static double AppWidth;
        public static double AppHeight;

        public static double LargeFontWidth;
        public static double MediumFontWidth;
        public static double SmallFontWidth;
        public static double MicroFontWidth;
        public static int LargeFontRowSize;
        public static int MediumFontRowSize;
        public static int SmallFontRowSize;
        public static int MicroFontRowSize;

        public static bool inBackground = false;

        public App()
        {
            // Create a reference to this application
            SAPP = this;

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
