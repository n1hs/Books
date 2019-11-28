using System;
using System.Linq;
using Caliburn.Micro;

namespace BookStoreManagement.Models
{
    public class CustomerReponsitory : IReponsitory<KhachHang>
    {
        private BindableCollection<KhachHang> _store;
        public BindableCollection<KhachHang> Store {
            get
            {
                if (_store is null)
                    GetAll();
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        public void Add(KhachHang newItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(KhachHang item)
        {
            throw new NotImplementedException();
        }

        public void Edit(KhachHang item, string key)
        {
            throw new NotImplementedException();
        }

        public KhachHang Find(string key)
        {
            try
            {
                return Store.Where(x => x.User.ToLower() == key.ToLower()).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void GetAll()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                _store = new Caliburn.Micro.BindableCollection<KhachHang>(db.KhachHangs.ToList());
            }
        }
    }
}
