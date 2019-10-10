using System;
using System.Windows.Controls;
using Caliburn.Micro;
using BookStoreManagement.StartUp;
using BookStoreManagement.ViewModels.OptionsPage;
using BookStoreManagement.ViewModels.MainPage;
using System.Windows;

namespace BookStoreManagement.ViewModels
{
    public class ShellViewModel : ViewBaseModel, IShell
    {
        private SimpleContainer _container;
        private INavigationServiceEx navigationService;
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

        private bool isMenuEnable = true;

        public bool IsMenuEnable
        {
            get { return isMenuEnable; }
            set { isMenuEnable = value;
                NotifyOfPropertyChange("IsMenuEnable");
            }
        }

        private bool isLog;

        public bool IsLog
        {
            get { return isLog; }
            set { isLog = value;
                NotifyOfPropertyChange("IsLog");
            }
        }

        public bool IsCustomer { get; set; }
        public bool IsEmployees { get; set; }
        public bool IsAdmin { get; set; }

        private string user;

        public string User
        {
            get { return user; }
            set { user = value;
                NotifyOfPropertyChange("User");
            }
        }




        #endregion

        public ShellViewModel(SimpleContainer container)
        {
            this._container = container;
            IsDialogOpen = true;
            DialogContent = new Views.UserControl.Login();
            DialogContent.DataContext = this;
        }

        #region Methods

        public void RegisterFrame(Frame frame)
        {
            navigationService = new NavigationService(frame);

            _container.Instance(navigationService);

            //navigationService.NavigateToViewModel(typeof(ProfileViewModel), "Main", null);
        }

        public void NavigateToView(string modelName)
        {
            switch(modelName)
            {
                case "About":
                    IsMenuEnable = false;
                    navigationService.NavigateToViewModel<AboutViewModel>();
                    IsMenuEnable = true;
                    break;
                case "Settings":
                    IsMenuEnable = false;
                    navigationService.NavigateToViewModel<SettingsViewModel>();
                    IsMenuEnable = true;
                    break;
                case "FindBook":
                    IsMenuEnable = false;
                    navigationService.NavigateToViewModel<FindBookViewModel>();
                    IsMenuEnable = true;
                    break;
                default:
                    IsMenuEnable = false;
                    navigationService.NavigateToViewModel<ErrorViewModel>();
                    IsMenuEnable = true;
                    break;
            }
        }

        public void Login(string user)
        {
            if (user == "customer")
            {
                IsCustomer = true;
                NotifyOfPropertyChange("IsCustomer");
            }
            else
            {
                if (user == "user")
                {
                    IsEmployees = true;
                    NotifyOfPropertyChange("IsEmployees");
                }
                else
                {
                    if (user == "admin")
                    {
                        IsEmployees = true;
                        NotifyOfPropertyChange("IsEmployees");
                        IsAdmin = true;
                        NotifyOfPropertyChange("IsAdmin");
                    }
                    else
                    {
                        MessageBox.Show("Thông tin đăng nhập chưa chính xác");
                        return;
                    }
                }
            }
            IsDialogOpen = false;
            IsLog = true;
            User = user;
            IsMenuEnable = false;
            navigationService.NavigateToViewModel<FindBookViewModel>();
            IsMenuEnable = true;
        }
        public void Login()
        {
            IsDialogOpen = false;
            IsLog = true;
            User = "Guest.";
            IsMenuEnable = false;
            navigationService.NavigateToViewModel<FindBookViewModel>();
            IsMenuEnable = true;
        }
        #endregion
    }
}
