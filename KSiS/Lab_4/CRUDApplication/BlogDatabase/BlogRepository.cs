﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatabase
{
    public class BlogRepository
    {
        public BlogDatabaseContainer BlogDatabase { get; set; }

        public BlogRepository(BlogDatabaseContainer blogDatabase)
        {
            BlogDatabase = blogDatabase;
            BlogDatabase.Configuration.LazyLoadingEnabled = false;
        }

        private void Save()
        {
            BlogDatabase.SaveChanges();
        }

        private ICollection<IElement> GetList<T>()
        {
            return (ICollection<IElement>)BlogDatabase.GetType().GetField(typeof(T) + "Set").GetValue(null);
        }

        public void Create<T>(IElement element)
        {
            var list = GetList<T>().ToList();
            list.Add(element);
            Save();
        }

        public ICollection<IElement> RetreiveAll<T>()
        {
            return GetList<T>();
        }

        public IElement Retreive<T>(int id)
        {
            var list = GetList<T>().ToList();
            return list.Find(x => x.Id == id);
        }

        public void Update<T>(IElement newElement)
        {
            var list = GetList<T>().ToList();
            var oldElement = list.Find(x => newElement.Id == x.Id);
            if (oldElement == null) throw new Exception("No such element");

            foreach (var oldProperty in oldElement.GetType().GetProperties())
            {
                foreach (var newProperty in newElement.GetType().GetProperties())
                {
                    if (oldProperty.Name == newProperty.Name)
                    {
                        oldProperty.SetValue(oldElement, newProperty.GetValue(null));
                    }
                }
            }
        }

        public void Delete<T>(int id)
        {
            var list = GetList<T>().ToList();
            var el = list.Find(x => x.Id == id);
            list.Remove(el);
            Save();
        }
    }
}
