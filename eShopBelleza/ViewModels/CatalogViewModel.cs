using eShopBelleza.Models;
using eShopBelleza.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopBelleza.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        #region VARIABLES
        private ObservableCollection<Product> _products;
        private IProductService _productService;
        private IOrdenService _ordenService;
        private Orden _orden;
        #endregion

        #region CONSTRUTOR
        public CatalogViewModel(INavigation navigation)
        {
            _productService = DependencyService.Get<IProductService>();
            _ordenService = DependencyService.Get<IOrdenService>();
            _orden = new Orden();
            getProducts();
        }
        #endregion

        #region Object
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value;
                OnpropertyChanged("Products");
            }
        }


        public Orden Orden
        {
            get { return _orden; }
            set
            {
                _orden = value;
                OnpropertyChanged("Products");
            }
        }

        public async Task AlertPro(Product p)
        {
          

            bool answer = await DisplayAlert("Importante", "Desea agregar "+p.Name+" a su pedido","Si", "No");

            if (answer)
            {
                await _productService.UpdateProductStockBy(p.Id, p.Stock - 1);

                _orden.IdProducts.Add(p.Id);
                _orden.Total += p.Price;

                getProducts();
            }
        
        }
        #endregion

        #region PROCCES
        private async void getProducts()
        {

            Products = await _productService.GetProducts();

    
         }

        private async void MakeAnOrder()
        {
            if (_orden.IdProducts.Count==0)
            {
                await DisplayAlert("Importante", "Todavia no ha gregado ningun producto", "OK");
            }
            else
            {
                _orden.ClientName = await App.Current.MainPage.DisplayPromptAsync("Datos Personales", "Nombre Completo");

                _orden.ClientAddress = await App.Current.MainPage.DisplayPromptAsync("Datos Personales", "Direccion");

                bool answer = await DisplayAlert("Confirmar pedido", "Nombre " + _orden.ClientName + " Dirrecion de entrega " + _orden.ClientAddress + " Valor Total Productos " + _orden.Total + " realizar pedido", "Si", "No");

                if (answer)
                {

                    await _ordenService.SaveOrden(_orden);
                }
            }
           
        }
        #endregion

        #region COMMMANS
        public ICommand AlertCommand => new Command<Product>(async (p) => await AlertPro(p));
        public ICommand MakeAnOrderCommand => new Command(async =>  MakeAnOrder());
        #endregion
    }
}
