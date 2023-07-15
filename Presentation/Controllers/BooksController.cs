using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
            
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {            
                var books = _manager.BookService.GetAllBooks(false);//değişiklikleri izlemeye gerek yok bu yüzden ef te performansta bir artış olmalı 
                return Ok(books);          

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id) //parametre route tan gelecek. yazmak en doğrusu imiş
        {      
                var book = _manager.BookService.GetOneBookById(id, false);//tek bir değer yada default değeri yani null dır

                return Ok(book); 
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
            
                if (bookDto is null)
                {
                    return BadRequest();
                }
                var book= _manager.BookService.CreateOneBook(bookDto);

                return StatusCode(201, book);  //createdAtRoute ile ekleme yaparsak response ın header ına bir location bilgisi koyarız          
        }

        [HttpPut("{id:int}")]//Bir bütün olarak güncelleme
        public IActionResult UpdateOneBook([FromRoute] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            
                if (bookDto is null)// check parameter
                {
                    return BadRequest();//400
                }

                _manager.BookService.UpdateOneBook(id, bookDto, true);

                return NoContent();//204            

        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute] int id)
        {
            
                //kitap kontrolünü zaten bookmanager da yaptım. silebilirim.
                //var book = _manager.BookService.GetOneBookById(id,false);
                //if (book is null)
                //    return NotFound(new
                //    {
                //        statusCode = 404,
                //        message = $"{id} id'li kayıt bulunamadı..."
                //    });//404
                _manager.BookService.DeleteOneBook(id, false);

                return NoContent();           
        }


        [HttpPatch("{id:int}")]//Kısmi Güncelleme -Çalışmadı...-
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDto> book)
        {
            
                var bookDto = _manager.BookService.GetOneBookById(id, true);
               

                book.ApplyTo(bookDto);//book u entity e yansıt.
                                     ////burada da mapper kullanabilirdik ama hile yaptık
            _manager.BookService.UpdateOneBook(id, 
                new BookDtoForUpdate()
            {
                 Id=bookDto.Id, Price=bookDto.Price, Title=bookDto.Title
            }, true);
                return NoContent();//204             
        }
    }
}
