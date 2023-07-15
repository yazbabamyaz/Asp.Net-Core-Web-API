using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    //where ile kısıtlama getirmedik onu somut sınıfta yapcaz.T
    public interface IRepositoryBase<T>
    {
        //Bir sözleşme oluşturduk bunları kabul eden sınıf implement edecek.
        //ef de nesneyi izliyor ne zaman savechanges dersek o zaman değişiklikleri yansıtıyor.
        //o yüzden değişiklikleri izleyip izlemeyeceğimizi bir parametreye bağladık.
        //bazen izlememek gerekecek çünkü
       IQueryable<T> FindAll(bool trackChanges);
        //Şarta bağlı --- expression ifadesi içine bir func delege koyduk geriye bool dönecek
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression , bool trackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
