using AjmeraInfotech.Common;
using AjmeraInfotech.Domain.interfaces.entity;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AjmeraInfotechInterview.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookEntity _bookEntity;
        private IMapper _mapper;
        private static ILogger<BookController> _logger;
        public BookController(IBookEntity bookEntity,IMapper mapper, ILogger<BookController> logger)
        {
            _bookEntity = bookEntity;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        [Route("Save")]
        public  ActionResult SaveBook(Book book)
        {
            try
            {
                return Ok(_bookEntity.SaveBook(book));
            }
           catch(Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("getbyid")]
        public ActionResult<Book> GetBookById(Guid id)
        {
            try
            {
                var result = _bookEntity.GetBookById(id);
                return Ok(_mapper.Map<Book>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return StatusCode(500);
            }

        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Book>> GetBooks()
        {
            try
            {
                var result = _bookEntity.GetBooks();
                return Ok(_mapper.Map<List<Book>>(result));
            }      
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return StatusCode(500);
            }
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Book book)
        {
            try
            {
                return Ok(_bookEntity.Update(book));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return StatusCode(500);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Guid Id)
        {
            try
            {
                return Ok(_bookEntity.Delete(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return StatusCode(500);
            }
        }
    }
}
