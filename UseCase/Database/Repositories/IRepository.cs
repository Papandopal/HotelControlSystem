using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Database.Repositories
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll(); 
        public T GetById(int id);
        public bool IsExists(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
