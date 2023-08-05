using System;
using Microsoft.AspNetCore.Mvc;
using TrungBook.WebApi.Services;
using TrungBook.WebApi.Models;

namespace TrungBook.WebApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly MongoDBService _mongoDBService;
        
        public BooksController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Books>> Get() {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Books books)
        {
            await _mongoDBService.CreateAsync(books);
            return CreatedAtAction(nameof(Get), new { id = books.Id }, books);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id) {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }

    }
}
