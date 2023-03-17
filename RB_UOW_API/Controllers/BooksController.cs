using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_UOW_Core;
using RB_UOW_Core.Conts;
using RB_UOW_Core.Interfaces;
using RB_UOW_Core.Models;

namespace RB_UOW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetAllSync")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetByNameSync")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "Zoo", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Zoo"), new[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Zoo"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Ali", AuthorId = 1 });
            _unitOfWork.Complete();//Very important when you want to add delete update your data
            return Ok();
        }
    }
}
