using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));

            
           
        }

        //elimde çok sayıda repo olabilir ben onları tek tek newlemek yani IoC kaydını yapmak istemiyorum
        //normal de bir class altında başka bir class newlenmez. Sıkı bağlı bir uygulama geliştirmiş oluruz. ama hoca böyle yaptı???newlemeyi bu sınıf içinde manuel yapcaz

        public IBookRepository Book => _bookRepository.Value;//artık managerdan Book nesnesini istediği anda newlenmiş halini value ile döncez. Lazy loading yaptık.Kullanıldığı anda newlenme olacak

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
