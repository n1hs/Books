using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace BookStoreManagement.Models
{
    public interface IReponsitory<T> where T: class
    {
        BindableCollection<T> Store { set; get; }
        void GetAll();
        void Add(T newItem);
        void Edit(T item, string key);
        void Delete(T item);
        T Find(string key);
    }
}
