using ShoppingCart.WPF.Command;
using ShoppingCart.WPF.Users;

namespace ShoppingCart.WPF.MainMenu
{
    public class MainMenuViewModel
    {
        public DelegateCommand NewUserCommand { get; private set; }
        public DelegateCommand RemoveUserCommand { get; private set; }
        public DelegateCommand SaveCartInFileCommand { get; private set; }
        public DelegateCommand LoadCartFromFileCommand { get; private set; }
        public DelegateCommand ExportExcelFileCommand { get; private set; }

        private MainViewModel _mainViewModel;

        public MainMenuViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NewUserCommand = new DelegateCommand(SignUpNewUserWindow);
            RemoveUserCommand = new DelegateCommand(RemoveUserWindows);
            SaveCartInFileCommand = new DelegateCommand(SaveCartInFile);
            LoadCartFromFileCommand = new DelegateCommand(LoadCartFromFile);
            ExportExcelFileCommand = new DelegateCommand(ExportExcelFile);
        }

        private void ExportExcelFile()
        {
            _mainViewModel.ExportExcelFile();
        }

        public void SaveCartInFile()
        {
            _mainViewModel.SaveCartInFile();
        }

        public void LoadCartFromFile()
        {
            _mainViewModel.LoadCartFromFile();
        }

        private void SignUpNewUserWindow()
        {
            var signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();
        }

        private void RemoveUserWindows()
        {
            var removeUserWindow = new RemoveWindow();
            removeUserWindow.ShowDialog();
        }

    }
}
