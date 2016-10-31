using ShoppingCart.Managers;
using ShoppingCart.WPF.MainMenu;
using ShoppingCart.WPF.Services;
using ShoppingCart.WPF.Users;

namespace ShoppingCart.WPF
{
    public class ViewModelLocator
    {
        private UserManager _userManager;

        private MainViewModel _mainViewModel;
        private MainMenuViewModel _mainMenuViewModel;
        private SignUpViewModel _signUpViewModel;
        private RemoveViewModel _removeViewModel;

        private ProductsRepository _productsRepositoryService;
        private UsersRepository _usersRepositoryService;

        public ViewModelLocator()
        {
            _userManager = new UserManager();

            _productsRepositoryService = new ProductsRepository(_userManager);
            _usersRepositoryService = new UsersRepository(_userManager);

            _mainViewModel = new MainViewModel(_userManager, _productsRepositoryService , _usersRepositoryService);
            _mainMenuViewModel = new MainMenuViewModel(_mainViewModel);
            _signUpViewModel= new SignUpViewModel(_userManager);
            _removeViewModel = new RemoveViewModel(_userManager);

        }

        public MainViewModel MainViewModel => _mainViewModel;
        public MainMenuViewModel MainMenuViewModel => _mainMenuViewModel;
        public SignUpViewModel SignUpViewModel => _signUpViewModel;
        public RemoveViewModel RemoveViewModel => _removeViewModel;
    }
}
