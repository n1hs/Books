using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreManagement.Models
{
    public class AccountRepensitory : IReponsitory<NhanVien>
    {
        public BindableCollection<NhanVien> Store { get; set; }

        public void Add(NhanVien newItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(NhanVien item)
        {
            throw new NotImplementedException();
        }

        public void Edit(NhanVien item, string key)
        {
            throw new NotImplementedException();
        }

        public NhanVien Find(string key)
        {
            try
            {
                return Store.Where(x => x.UserName.ToLower() == key.ToLower()).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void GetAll()
        {
            using(DatabaseEntities db= new DatabaseEntities())
            {
                Store = new Caliburn.Micro.BindableCollection<NhanVien>(db.NhanViens.ToList());
            }
        }
    }
}
