using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    //Temel crud işlemlerini tüm repolarda ortak kullacağım o repoya-classa- özel metotlar varsa da onları o repoda tanımlayacağım abstract olduğu için
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        //şimdi bu base class ı abstract hale getircez yani newlenemesin yani ben bu classı yarım bırakıyorum demek buradaki implementasyonları yapacam bunları kalıtım ile devralacak sınıflar. ve kendilerine özel metotları da yazıp yollarına devam edebilecekler.
        //Bu classı devralacak class larda bu contexte ulaşsın diye protected yaptım.

        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)=> _context.Set<T>().Add(entity);
        //SAVECHANGES nerde? onu da manager üzerinde yapcaz.
       

        public void Delete(T entity)=>_context.Set<T>().Remove(entity);


        //parametre false ize yani değişiklikler izlenmesin ise AsNoTracking dön true ise ilgili nesnenin kendisini dön.
        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>();
        // ya da 

        //public IQueryable<T> FindAll(bool trackChanges)
        //{
        //    if (!trackChanges)
        //    {
        //        return _context.Set<T>().AsNoTracking();
        //    }            
        //       return _context.Set<T>();                     

        //}

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return _context.Set<T>().Where(expression);
            }
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)=>_context.Set<T>().Update(entity); 
        
    }
}
