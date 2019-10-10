using System;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BookStoreManagement.StartUp
{
    public interface INavigationServiceEx : INavigationService
    {
        void NavigateToViewModel<TViewModel>(string context, object extraData = null);
        void NavigateToViewModel(Type viewModel, string context, object extraData = null);
    }
    public class NavigationService : FrameAdapter, INavigationServiceEx
    {
        readonly Frame frame;
        public NavigationService(Frame frame, bool treatViewAsLoaded = false) : base(frame, treatViewAsLoaded)
        {
            this.frame = frame;
        }
        public void NavigateToViewModel<TViewModel>(string context, object extraData = null)
        {
            NavigateToViewModel(typeof(TViewModel), context, extraData);
        }

        public void NavigateToViewModel(Type viewModel, string context, object extraData = null)
        {
            var viewType = ViewLocator.LocateTypeForModelType(viewModel, null, context);

            var packUri = ViewLocator.DeterminePackUriFromType(viewModel, viewType);

            var uri = new Uri(packUri, UriKind.Relative);

            frame.Navigate(uri, extraData);
        }
    }
}
