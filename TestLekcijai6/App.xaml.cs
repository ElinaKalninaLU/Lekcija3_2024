using GeometryClasses;

namespace TestLekcijai6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            dm = new GeometryDataManager();
        }

        public static GeometryDataManager dm { get; set; }
    }
}
