using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //dtoları record olarak tanımlayalım abstract record yaptık newlenme olmaz base record type olur ancak diğer dto lar kalıtım alsın diye de abstract yaptık
    public abstract record BookDtoForManipulation
    {
        //id de manipülasyon yapmicaz
        [Required(ErrorMessage ="Title is a required field.")]
        [MinLength(2 , ErrorMessage ="Title must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title must consist of at maximum 50 characters.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Title is a required field.")]
        [Range(10,1000)]
        public decimal? Price { get; init; }
    }
}
