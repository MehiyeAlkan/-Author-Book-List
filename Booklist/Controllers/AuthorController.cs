using DTOlayer.DTOs.AuthorDTO;
using LibraryService.RepositoryClass;
using LibraryService.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Controllers
{

    [ApiController]
    [Route("[controller]")]


    public class AuthorController : ControllerBase
    {
        IAuthorService _authorService;

        private IAuthorListRepository _authorRepository;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

       [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {

            var list = await _authorService.GetAllAuthor();
            return Ok(list);
        }
     


        [HttpPost("/getidauthor")]
        public async Task<IActionResult> GetNIdAuthor([FromBody] AuthorDTO authorDTO) {

            var author = await _authorService.GetNIdAuthor(authorDTO);
            return Ok(author);
        }







       [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try

            {
                await _authorService.AddAuthor(authorDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorDTO authorDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingauthor = await _authorService.GetIdAuthor(authorDTO.Id);

            if (existingauthor == null)
            {
                return NotFound();
            }


            try
            {
                await _authorService.UpdateAuthor(authorDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }



        [HttpDelete]
        public async Task<IActionResult> DeletedAuthor( [FromBody] AuthorDTO authorDTO)
        {

            var deletedAuthor = await _authorService.GetIdAuthor(authorDTO.Id);
            if (deletedAuthor == null)
            {
                return NotFound();
            }

            try
            {
                await _authorService.DeleteAuthor(authorDTO); ;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }
    }
}



