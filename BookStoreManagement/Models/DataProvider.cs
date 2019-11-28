using System;
using Caliburn.Micro;

namespace BookStoreManagement.Models
{
    public class DataProvider
    {
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsEmploy { get;  set; }
        public bool IsCustomer { get;  set; }
        public bool IsGuest { get;  set; }

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

        private IReponsitory<KhachHang> _customerReponsitory;
        public IReponsitory<KhachHang> CustomerReponsitory
        {
            get
            {
                if (_customerReponsitory is null)
                    _customerReponsitory = new CustomerReponsitory();
                return _customerReponsitory;
            }
        }

        /// <summary>
        /// Kiem tra tai khoan dang nhap
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <returns>
        /// True - thanh cong
        /// Fasle - Sai mat khau
        /// Null - Khong tim thay
        /// </returns>
        internal bool? CheckAccount(string User, string Password)
        {
            if(AccountReponsitory.Store == null)
            {
                AccountReponsitory.GetAll();
            }
            NhanVien nhanVien = AccountReponsitory.Find(User);
            if (nhanVien != null )
            {
                if (nhanVien.PassWord.ToLower() != Assets.Helper.Sercurity.CalculateMD5Hash(Password).ToLower())
                    return false;
                UserName = nhanVien.Name;
                if(nhanVien.QuanLy == true)
                {
                    IsAdmin = true;
                }
                IsEmploy = true;
                IsCustomer = false;
                IsGuest = false;
                return true; ;
            }

            KhachHang khachHang = CustomerReponsitory.Find(User);
            if (khachHang != null)
            {
                if (khachHang.Password.ToLower() != Assets.Helper.Sercurity.CalculateMD5Hash(Password).ToLower())
                    return false;
                UserName = khachHang.TenKH;
                IsAdmin = false;
                IsEmploy = false;
                IsCustomer = true;
                IsGuest = false;
                return true; ;
            }

            UserName = "Khách";
            IsGuest = true;
            return null;
        }
    }
}
