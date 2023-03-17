using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_UOW_Core;
using RB_UOW_Core.Interfaces;
using RB_UOW_Core.Models;

namespace RB_UOW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetByIdSync")]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }


        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(1));
        }


    }
}
