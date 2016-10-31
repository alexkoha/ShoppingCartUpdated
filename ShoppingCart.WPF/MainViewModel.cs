using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using ShoppingCart.EventsArgs;
using ShoppingCart.Managers;
using ShoppingCart.Models;
using ShoppingCart.WPF.Chain;
using ShoppingCart.WPF.Command;
using ShoppingCart.WPF.Services;

namespace ShoppingCart.WPF
{
    public class MainViewModel : ObservableObject
    {
        private UserManager _appManager;

        public ObservableCollection<ItemKey> Products { get; set; }
        public ObservableCollection<ItemKey> CartProducts { get; set; }
        public ObservableCollection<ChainViewModel> Tabs { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public DelegateCommand AddButtonClickCommand { get; private set; }
        public DelegateCommand RemoveProductCommand { get; private set; }
        public DelegateCommand ChangeUserCommand { get; private set; }
        public DelegateCommand ExpendMenuCommand { get; private set; }

        private ItemKey _selectedProduct;
        public ItemKey SelctedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if(Equals(value, _selectedProduct)) return;
                _selectedProduct = value;
            }
        }

        private int _quantityOfProduct;
        public int QuantityOfProduct
        {
            get { return _quantityOfProduct; }
            set
            {
                if (!Equals(_quantityOfProduct, value)) 
                    _quantityOfProduct = value;
            }
        }

        private ItemKey _selectedProductInCart;
        public ItemKey SelectedProductInCart
        {
            get { return _selectedProductInCart; }
            set
            {
                if (!Equals(value, _selectedProductInCart)) 
                    _selectedProductInCart = value;
            }
        }

        private string _currentUserName;
        public string CurrentUserName
        {
            get { return _currentUserName; }

            set
            {
                if (value == _currentUserName) return;
                _currentUserName = value;
                RaisePropertyChangedEvent("CurrentUserName");
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    ChangeUser();
                }
            }
        }


        private bool _isMenuExpented;
        private ProductsRepository _productsRepositoryService;
        private UsersRepository _usersRepositoryService;

        public bool IsMenuExpented
        {
            get { return _isMenuExpented; }
            set
            {
                if(value== _isMenuExpented)
                    return;
                _isMenuExpented = value;
                RaisePropertyChangedEvent("IsMenuExpented");
            }
        }


        public MainViewModel(UserManager appManager, ProductsRepository productsRepositoryService, UsersRepository usersRepositoryService)
        {
            _productsRepositoryService = productsRepositoryService;
            _usersRepositoryService = usersRepositoryService;
            _appManager = appManager;

            _appManager.CartPriceUpdated += AppManagerOnCartPriceUpdated;
            _appManager.CurrentUserUpdated += AppManagerOnCurrentUserUpdated;
            _appManager.ProductCartListUpdated += AppManagerOnProductCartListUpdated;
            _appManager.UsersListUpdated += AppManagerOnUsersListUpdated;

            Tabs = new ObservableCollection<ChainViewModel>();
            Users = new ObservableCollection<User>();
            CartProducts = new ObservableCollection<ItemKey>();

            InitTabs();
            InitUsers();

            AddButtonClickCommand = new DelegateCommand(AddProductToCart,CheckAddProduct);
            RemoveProductCommand = new DelegateCommand(RemoveItemFromCart);
            ChangeUserCommand = new DelegateCommand(ChangeUser);
            ExpendMenuCommand = new DelegateCommand(ExpendMenu);


            LoadCurrentUserName();
            LoadProductsList();

            _quantityOfProduct = 1;
            IsMenuExpented = false;
        }

        private async void LoadCurrentUserName()
        {
            var user = await Task.Run(() => _usersRepositoryService.GetCurrentUserAsync());
            CurrentUserName = user.Name;

        }

        private async void LoadProductsList()
        {
            Products = new ObservableCollection<ItemKey>();
            var list = await Task.Run(() => _productsRepositoryService.GetProductsAsync());
            list.ToList().ForEach(item=>Products.Add(item));
        }


        private void AppManagerOnUsersListUpdated(object sender, UsersListUpdatedArgs usersListUpdatedArgs)
        {
            var updatedUsersList = usersListUpdatedArgs.UsersList.ToList();

            if (Users.Count < updatedUsersList.Count)
            {
                updatedUsersList.ForEach((user) =>
                {
                    var isUserContained = Users.Contains(user);
                    if (!isUserContained)
                    {
                        Users.Add(user);
                    }
                });
            }
            else
            {
                Users.ToList().ForEach((user) =>
                {
                    if (!updatedUsersList.Contains(user))
                        Users.Remove(user);
                });
            }

        }

        private void ExpendMenu()
        {
            IsMenuExpented = !IsMenuExpented;
        }

        private async void InitUsers()
        {
            var usersList = await _usersRepositoryService.GetUsersAsync();
            usersList.ToList().ForEach(user=>Users.Add(user));
        }

        private void InitTabs()
        {
            Tabs.Add(new ChainViewModel("Viktory", "../Images/victory_logo.jpg"));
            Tabs.Add(new ChainViewModel("ShookHair","../Images/shokHaair_logo.jpg"));
            Tabs.Add(new ChainViewModel("MahsaneiHashook","../Images/mahsaneihashook_logo.jpg"));
        }

        private void AppManagerOnProductCartListUpdated(object sender, ProductCartListUpdatedArgs productsInCartUpdated)
        {
            var updatedProductsList = productsInCartUpdated.ListProductsInCart.ToList();

            if (CartProducts.Count() < updatedProductsList.Count ) 
                updatedProductsList.ForEach(item =>
                {
                    if (!CartProducts.Contains(item))
                        CartProducts.Add(item);
                });
            else
            {
                CartProducts.ToList().ForEach((product) =>
                {
                    if (!updatedProductsList.Contains(product))
                        CartProducts.Remove(product);
                });
            }

        }

        private void AppManagerOnCurrentUserUpdated(object sender, CurrentUserEventArgs currentUserEventArgs)
        {
            LoadCurrentUserName();
        }

        private async void AppManagerOnCartPriceUpdated(object sender, CartPriceUpdatedArgs cartPriceUpdatedArgs)
        {
            await Task.Run(() =>
            {
                Tabs[0].CartPrice = cartPriceUpdatedArgs.ViktoryCartPrice;
                Tabs[0].ExpensiveProducts = cartPriceUpdatedArgs.ViktoryExpensiveProducts;
                Tabs[0].CheapestProducts = cartPriceUpdatedArgs.ViktoryChipestProducts;

                Tabs[1].CartPrice = cartPriceUpdatedArgs.ShookHaairCartPrice;
                Tabs[1].ExpensiveProducts = cartPriceUpdatedArgs.ShookHaairExpensiveProducts;
                Tabs[1].CheapestProducts = cartPriceUpdatedArgs.ShookHaairChipestProducts;

                Tabs[2].CartPrice = cartPriceUpdatedArgs.MahsaneyHashookCartPrice;
                Tabs[2].ExpensiveProducts = cartPriceUpdatedArgs.MahsaneyHashookExpensiveProducts;
                Tabs[2].CheapestProducts = cartPriceUpdatedArgs.MahsaneyHashookChipestProducts;

            });
        }


        private void CalculateCartPrice() 
        {
            _appManager.CalculateCart();
        }

        public void SaveCartInFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Date File|*.dat",
                Title = "Save Shopping Cart"
            };
            saveFileDialog1.ShowDialog();
            var fileName = saveFileDialog1.FileName;

            _appManager.SaveShoppingCart(fileName);
        }

        public void LoadCartFromFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Date File|*.dat",
                Title = "Open file Shopping Cart"
            };
            openFileDialog1.ShowDialog();

            var fileName = openFileDialog1.FileName;


            if(fileName.Any())
                CartProducts.Clear();

            _appManager.LoadShoppingCart(fileName);
            CalculateCartPrice();
        }

        public void ExportExcelFile()
        {
            if (!CartProducts.Any())
            {
                MessageBox.Show("Empty Cart");
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Date Data|*.xls",
                Title = "Save Shopping Cart"
            };
            saveFileDialog1.ShowDialog();
            var fileName = saveFileDialog1.FileName;

            if(fileName.Any())
                _appManager.CreatExcelFileShoppingCart(fileName);
        }

        private void AddProductToCart()
        {
            _appManager.AddItemToCart(SelctedProduct , QuantityOfProduct);
            CalculateCartPrice();
        }

        private bool CheckAddProduct()
        {
            if ( QuantityOfProduct > 0)
            {
                if (!CartProducts.Contains(SelctedProduct))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Item already in the cart");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You must enter quantity and positive number");
            }
            return true;
        }

        private void RemoveItemFromCart()
        {
            if (SelectedProductInCart == null) return;

            _appManager.RemoveItemFromCart(SelectedProductInCart);
            CalculateCartPrice();
        }

        private void ChangeUser()
        {
            if (SelectedUser == null)
                return;
            CartProducts.Clear();
            _appManager.ChooseCurrentUser(SelectedUser);
            CalculateCartPrice();
        }
    }


}
