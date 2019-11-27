using System;
using System.Windows;
using BookStoreManagement.Models;
using System.Linq;
using Caliburn.Micro;

namespace BookStoreManagement.ViewModels.MainPage
{
    public class FindBookViewModel : ViewBaseModel
    {
        private DataProvider dataProvider;

        private string searchKey;

        public string SearchKey
        {
            get { return searchKey; }
            set { searchKey = value;
                if (string.IsNullOrEmpty(value))
                {
                    searchBooks = null;
                    ListBooks = dataProvider.BookReponsitory.Store;
                }
            }
        }

        private int searchBy = 0;

        public int SearchBy
        {
            get { return searchBy; }
            set { searchBy = value;
                NotifyOfPropertyChange("SearchBy");
            }
        }


        private BindableCollection<Sach> listBooks;
        private BindableCollection<Sach> searchBooks;     

        public BindableCollection<Sach> ListBooks
        {
            get { return listBooks; }
            set { listBooks = value;
                NotifyOfPropertyChange("ListBooks");
            }
        }

        private object selectedBook = null;

        public object SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                if (value is null)
                {
                    RighPaneVisibility = Visibility.Collapsed;
                }
                else
                {
                    RighPaneVisibility = Visibility.Visible;
                }
            }
        }

        private Visibility righPaneVisibility = Visibility.Collapsed;

        public Visibility RighPaneVisibility
        {
            get { return righPaneVisibility; }
            set { righPaneVisibility = value;
                NotifyOfPropertyChange("RighPaneVisibility");
            }
        }


        public FindBookViewModel(DataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            ListBooks = dataProvider.BookReponsitory.Store;
        }

        public void Search()
        {
            if (string.IsNullOrEmpty(searchKey))
                return;
            switch(searchBy)
            {
                case 0:
                    searchBooks = new BindableCollection<Sach>(listBooks.Where(x => x.MaSach.Contains(searchKey) || x.TenSach.Contains(searchKey) || x.TacGia.Contains(searchKey)).ToList());
                    break;
                case 1:
                    searchBooks = new BindableCollection<Sach>(listBooks.Where(x => x.MaSach.Contains(searchKey)).ToList());
                    break;
                case 2:
                    searchBooks = new BindableCollection<Sach>(listBooks.Where(x => x.TenSach.Contains(searchKey)).ToList());
                    break;
                case 3:
                    searchBooks = new BindableCollection<Sach>(listBooks.Where(x => x.TacGia.Contains(searchKey)).ToList());
                    break;
            }
            ListBooks = searchBooks;
        }
    }
}
