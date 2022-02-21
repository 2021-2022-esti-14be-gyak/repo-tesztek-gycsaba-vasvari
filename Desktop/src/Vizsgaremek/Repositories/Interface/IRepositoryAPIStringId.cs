using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories.Interface
{
    interface ﻿IRepositoryAPIStringId<T>
    {
        public List<T> GetAll();
        public T Get(string id);
        public void Insert(T entity);
        public void Update(string id, T entity);
        public void Delete(string id);
    }
}
