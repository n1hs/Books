using System;
using System.Windows.Controls;
using Caliburn.Micro;
using BookStoreManagement.StartUp;
using BookStoreManagement.ViewModels.OptionsPage;
using BookStoreManagement.ViewModels.MainPage;
using BookStoreManagement.Models;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;

namespace BookStoreManagement.ViewModels
{
    public class ShellViewModel : ViewBaseModel, IShell
    {
        private SimpleContainer _container;
        private INavigationServiceEx navigationService;
        private DataProvider dataProvider;
        #region Properties
        private UserControl dialogContent;

        public UserControl DialogContent
        {
            get { return dialogContent; }
            set { dialogContent = value;
                NotifyOfPropertyChange("DialogContent");
            }
        }

        private bool isDialogOpen;

        public bool IsDialogOpen
        {
            get { return isDialogOpen; }
            set { isDialogOpen = value;
                NotifyOfPropertyChange("IsDialogOpen");
            }
        }
               
        public bool IsSignin
        {
            get { return !dataProvider.IsGuest; }
        }
        public bool IsSignout
        {
            get { return dataProvider.IsGuest; }
        }

        public bool IsCustomer {
            get { return dataProvider.IsCustomer; }
        }
        public bool IsEmployees {
            get { return dataProvider.IsEmploy; }
        }
        public bool IsAdmin { get { return dataProvider.IsAdmin; } }
        public string Name
        {
            get
            {
                return dataProvider.UserName;
            }
        }

        private string user;

        public string User
        {
            get { return user; }
            set { user = value;
                NotifyOfPropertyChange("User");
            }
        }

        private string password;

        public string Password
        {
            set { password = value;
                NotifyOfPropertyChange("Password");
            }
        }

        private bool loginButtonEnable;

        public bool LoginButtonEnable
        {
            get { return loginButtonEnable; }
            set { loginButtonEnable = value; NotifyOfPropertyChange("LoginButtonEnable"); }
        }

        private string loginMessage;

        public string LoginMessage
        {
            get { return loginMessage; }
            set {
                loginMessage = value;
                NotifyOfPropertyChange("LoginMessage");
            }
        }

        private HamburgerMenuItemCollection menuItems;

        public HamburgerMenuItemCollection MenuItems
        {
            get { return menuItems; }
            set { menuItems = value;
                NotifyOfPropertyChange("MenuItems");
            }
        }

        private int menuSelectedIndex = -1;

        public int MenuSelectedIndex
        {
            get { return menuSelectedIndex; }
            set { menuSelectedIndex = value;
                NotifyOfPropertyChange("MenuSelectedIndex");
            }
        }



        #endregion

        /// <summary>
        /// Contruction 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="dataProvider"></param>
        public ShellViewModel(SimpleContainer container, DataProvider dataProvider)
        {
            this._container = container;
            this.dataProvider = dataProvider;
            IsDialogOpen = false;
            dataProvider.IsGuest = true;
            dataProvider.UserName = "Khách";
            MenuItems = new HamburgerMenuItemCollection();
            SetMenuItemForGuest();
        }

        #region Methods

        public void RegisterFrame(Frame frame)
        {
            navigationService = new NavigationService(frame);

            _container.Instance(navigationService);
        }

        public void NavigateToView(string modelName)
        {
            switch(modelName)
            {
                case "About":
                    navigationService.NavigateToViewModel<AboutViewModel>();
                    break;
                case "Setings":
                    navigationService.NavigateToViewModel<SettingsViewModel>();
                    break;
                case "FindBook":
                    navigationService.NavigateToViewModel<FindBookViewModel>();
                    break;
                case "GHome":
                    navigationService.NavigateToViewModel<HomeViewModel>("Guest");
                    break;
                case "NHome":
                    navigationService.NavigateToViewModel<HomeViewModel>("NotGuest");
                    break;
                default:
                    navigationService.NavigateToViewModel<ErrorViewModel>();
                    break;
            }
        }

        public void ShowLoginPage()
        {
            DialogContent = new Views.UserControl.Login();
            DialogContent.DataContext = this;
            IsDialogOpen = true;
            LoginMessage = string.Empty;
            LoginButtonEnable = true;
        }

        private void SetMenuItemForGuest()
        {
            HamburgerMenuIconItem home = new HamburgerMenuIconItem();
            home.Label = "Home";
            home.Tag = "GHome";
            home.Icon = new PackIcon() { Kind = PackIconKind.Home };
            MenuItems.Add(home);
            MenuSelectedIndex = 0;
        }
        private void SetMenuItemForCustomer()
        {
            HamburgerMenuIconItem home = new HamburgerMenuIconItem();
            home.Label = "Home";
            home.Tag = "NHome";
            home.Icon = new PackIcon() { Kind = PackIconKind.Home };
            MenuItems.Add(home);
            MenuSelectedIndex = 0;
        }
        private void SetMenuItemForEmploy()
        {
            HamburgerMenuIconItem home = new HamburgerMenuIconItem();
            home.Label = "Home";
            home.Tag = "NHome";
            home.Icon = new PackIcon() { Kind = PackIconKind.Home };
            MenuItems.Add(home);
            HamburgerMenuIconItem qlk = new HamburgerMenuIconItem();
            qlk.Label = "Quản lý kho";
            qlk.Tag = "StoreMG";
            qlk.Icon = new PackIcon() { Kind = PackIconKind.Store };
            MenuItems.Add(qlk);
            HamburgerMenuIconItem qlkh = new HamburgerMenuIconItem();
            qlkh.Label = "Quản lý khách hàng";
            qlkh.Tag = "CustomerMG";
            qlkh.Icon = new PackIcon() { Kind = PackIconKind.Account };
            MenuItems.Add(qlkh);
            HamburgerMenuIconItem hd = new HamburgerMenuIconItem();
            hd.Label = "Hóa đơn";
            hd.Tag = "Hoadon";
            hd.Icon = new PackIcon() { Kind = PackIconKind.Details };
            MenuItems.Add(hd);
            MenuSelectedIndex = 0;
        }
        private void SetMenuItemForMG()
        {
            HamburgerMenuIconItem home = new HamburgerMenuIconItem();
            home.Label = "Home";
            home.Tag = "NHome";
            home.Icon = new PackIcon() { Kind = PackIconKind.Home };
            MenuItems.Add(home);
            HamburgerMenuIconItem qlnv = new HamburgerMenuIconItem();
            qlnv.Label = "Quan lý nhân viên";
            qlnv.Tag = "MGHome";
            qlnv.Icon = new PackIcon() { Kind = PackIconKind.Halloween };
            MenuItems.Add(qlnv);
            HamburgerMenuIconItem qlk = new HamburgerMenuIconItem();
            qlk.Label = "Quản lý kho";
            qlk.Tag = "StoreMG";
            qlk.Icon = new PackIcon() { Kind = PackIconKind.Store };
            MenuItems.Add(qlk);
            HamburgerMenuIconItem qlkh = new HamburgerMenuIconItem();
            qlkh.Label = "Quản lý khách hàng";
            qlkh.Tag = "CustomerMG";
            qlkh.Icon = new PackIcon() { Kind = PackIconKind.Account };
            MenuItems.Add(qlkh);
            HamburgerMenuIconItem hd = new HamburgerMenuIconItem();
            hd.Label = "Hóa đơn";
            hd.Tag = "Hoadon";
            hd.Icon = new PackIcon() { Kind = PackIconKind.Details };
            MenuItems.Add(hd);
            HamburgerMenuIconItem tk = new HamburgerMenuIconItem();
            tk.Label = "Thống kê";
            tk.Tag = "TK";
            tk.Icon = new PackIcon() { Kind = PackIconKind.Graphql };
            MenuItems.Add(tk);
            MenuSelectedIndex = 0;
        }

        public async void Login()
        {
            LoginButtonEnable = false;
            bool? checkLogin = await Task<bool?>.Factory.StartNew(() => dataProvider.CheckAccount(User, password));
            if(checkLogin == true)
            {
                LoginMessage = "Đăng nhập thành công.";
                IsDialogOpen = false;
                dataProvider.IsGuest = false;
                NotifyOfPropertyChange("IsAdmin");
                NotifyOfPropertyChange("IsEmployees");
                NotifyOfPropertyChange("IsCustomer");
                NotifyOfPropertyChange("IsSignin");
                NotifyOfPropertyChange("IsSignout");
                NotifyOfPropertyChange("Name");
                if(IsAdmin)
                {
                    SetMenuItemForMG();
                    return;
                }
                if(IsEmployees)
                {
                    SetMenuItemForEmploy();
                    return;
                }
                SetMenuItemForCustomer();
            }
            if (checkLogin == false)
            {
                LoginMessage = "Sai mật khẩu.";
            }
            if (checkLogin == null)
            {
                LoginMessage = "Không tìm thấy tài khoản.";
            }
            LoginButtonEnable = true;
        }

        public void Logout()
        {
            dataProvider.IsAdmin = false;
            dataProvider.IsCustomer = false;
            dataProvider.IsEmploy = false;
            dataProvider.IsGuest = true;
            dataProvider.UserName = "Khách";
            NotifyOfPropertyChange("IsAdmin");
            NotifyOfPropertyChange("IsEmployees");
            NotifyOfPropertyChange("IsCustomer");
            NotifyOfPropertyChange("IsSignin");
            NotifyOfPropertyChange("IsSignout");
            NotifyOfPropertyChange("Name");
            NavigateToView("About");
            MenuItems.Clear();
            SetMenuItemForGuest();
        }

        public void HamburgerMenuControl_OnItemInvoked(HamburgerMenuItemInvokedEventArgs e)
        {
            NavigateToView((e.InvokedItem as HamburgerMenuItem)?.Tag.ToString());
        }
        #endregion
    }
}
