using DTOlayer.DTOs.BookDTO;
using LibraryService.Mapping.BookMapper;
using LibraryService.Model;
using LibraryService.Service;
using Microsoft.AspNetCore.Mvc;


namespace LibraryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var list = await _bookService.GetAllBook();

            return Ok(list);
        }


        
        [HttpPost("getauthorbooks")]
        public async Task<IActionResult> GetNIdBook([FromBody] BookDTO bookDTO)
        {
            var book = await _bookService.GetAuthorIdBook(bookDTO.AuthorId);

            return Ok(book);

        }








        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO bookDTO)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try

            {
                await _bookService.AddBook(bookDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookDTO bookDTO)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingbook = await _bookService.GetIdBook(bookDTO.Id);

            if (existingbook == null)
            {
                return NotFound();
            }


            try
            {
                await _bookService.UpdateBook(bookDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }




        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook([FromBody] BookDTO bookDTO)
        {
            var book = await _bookService.GetIdBook(bookDTO.Id);
            if (book == null)
            {
                return BadRequest(book);
            }
            await _bookService.DeleteBook(book);
            return NoContent();
        }
    }
}
