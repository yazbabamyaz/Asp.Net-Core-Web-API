using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //class referans tipli struct yaparsak değer tipli olur classa benzer ama fark çok büyük
    //record ise
    //dto:data transfer objects ten bahsediyorsak bu readonly olmalıdır değeri değişmemelidir.immutable
    //linq desteği vardır ref type tir ctor tanımlama gibi dto tanımlama şansı verir.
    //set kısımlar init şeklinde verilir.(readonly-immutable- özelliğini verdik)
    //public record BookDtoForUpdate
    //{
    //    public int Id { get; init; }//tanımlandığı yerde inisialize edildiği yerde değerini vereceksin.
    //    public string Title { get; init; }
    //    public decimal Price { get; init; }
    //}

    //doğrulama için BookDtoForManipulation kalıtım alıyoruz.
    //public record BookDtoForUpdate(int Id, string Title, decimal? Price);//Şeklinde kullanım da var. ctor gibi




    //BUNLAR PARAMETRELER İÇİN.    
    public record BookDtoForUpdate:BookDtoForManipulation
    {       

        [Required]
        public int Id { get; init; }
    }

}
