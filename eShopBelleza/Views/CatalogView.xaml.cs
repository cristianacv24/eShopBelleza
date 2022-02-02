using eShopBelleza.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopBelleza.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogView : ContentPage
    {
        public CatalogView()
        {

            InitializeComponent();
            BindingContext = new CatalogViewModel(Navigation);
           
        }
    }
}