using Caliburn.Micro;
using System;
namespace BookStoreManagement.ViewModels
{
    public class ViewBaseModel : Screen
    {
        private IEventAggregator eventAggregator;
        public ViewBaseModel()
        { }
        public ViewBaseModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }
    }
}
