using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository:IRepositoryBase<Book>
    {
        //Buraya 5 tane crud imzası gelecek
        //Buraya özel metot imzaları olursa yazarsın

        //Create metodu zaten var ama biz ilerisi için yazdık yani metodta orderby kullanırsın vs vs
        IQueryable<Book> GetAllBooks(bool trackChanges);
        Book GetOneBookById(int id,bool trackChanges);
        void CreateOneBook(Book book);
        void DeleteOneBook(Book book);
        void UpdateOneBook(Book book);
    }
}
