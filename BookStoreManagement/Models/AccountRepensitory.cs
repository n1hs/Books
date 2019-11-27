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

        public void Edit(NhanVien item, object key)
        {
            throw new NotImplementedException();
        }

        public NhanVien Find(object key)
        {
            try
            {
                return Store.Single(x => x.UserName == key);
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
