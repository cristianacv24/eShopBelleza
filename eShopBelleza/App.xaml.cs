using eShopBelleza.Services;
using Xamarin.Forms;

namespace eShopBelleza
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IProductService, ProductService>();
            DependencyService.Register<IOrdenService, OrdenService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
