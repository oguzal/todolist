using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApi.Exceptions;
using TodoApi.Models;

namespace TodoApi.Data
{
    public abstract class GenericRepository<T> where T : Entity
    {
        private List<T> list;
        public GenericRepository()
        {
            this.list = new List<T>();
        }
        public virtual List<T> List()
        {
            return this.list;
        }
        public virtual void Add(T entity)
        {
            this.list.Add(entity);
        }

        internal virtual void Delete(int Id)
        {
            try
            {
                var toDel = FindById(Id);
                if (toDel == null)
                {
                    throw new ObjectNotExistsInRepoException<Todo>() { objectId = Id };
                    //                return false;
                }
                else
                {
                    list.Remove(toDel);
                }
            }
            catch (Exception ex)
            {
                // Log first 
                throw ex;
            }
        }

        public virtual T FindById(int Id)
        {
            return list.FirstOrDefault(p => p.Id == Id);
        }

        public virtual T FindByName(string title)
        {
            return list.FirstOrDefault(p => p.Name.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public abstract void Update(int id, T entity);
    }

}
