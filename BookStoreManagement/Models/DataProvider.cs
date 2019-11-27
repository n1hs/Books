using System;
using Caliburn.Micro;

namespace BookStoreManagement.Models
{
    public class DataProvider
    {
        public string UserName { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool IsEmploy { get; private set; }
        public bool IsCustomer { get; private set; }
        public bool IsGuest { get; private set; }

        private IReponsitory<Sach> _bookReponsitory;
        public IReponsitory<Sach> BookReponsitory { 
            get
            {
                if (_bookReponsitory is null)
                    _bookReponsitory = new BookReponsitory();
                return _bookReponsitory;
            } 
        }
        private IReponsitory<NhanVien> _accountReponsitory;
        public IReponsitory<NhanVien> AccountReponsitory {
            get
            {
                if (_accountReponsitory is null)
                    _accountReponsitory = new AccountRepensitory();
                return _accountReponsitory;
            }
        }
        internal void CheckAccount(string User, string Password)
        {
            if(AccountReponsitory.Store == null)
            {
                AccountReponsitory.GetAll();
            }
            NhanVien nhanVien = AccountReponsitory.Find(User);
            if (nhanVien != null)
            {
                UserName = nhanVien.UserName;
                if(nhanVien.QuanLy == true)
                {
                    IsAdmin = true;
                }
                IsEmploy = true;
                return;
            }
            UserName = string.Empty;
            IsGuest = true;
        }
    }
}
