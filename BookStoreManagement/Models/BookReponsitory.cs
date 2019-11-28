using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreManagement.Models
{
    public class BookReponsitory : IReponsitory<Sach>
    {
        private BindableCollection<Sach> _store;
        public BindableCollection<Sach> Store {
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

        public void Add(Sach newItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(Sach item)
        {
            throw new NotImplementedException();
        }

        public void Edit(Sach item, string key)
        {
            throw new NotImplementedException();
        }

        public Sach Find(string key)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                _store = new Caliburn.Micro.BindableCollection<Sach>(db.Saches.ToList());
            }
        }
    }
}
