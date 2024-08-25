using DTOlayer.DTOs.BookDTO;
using LibraryService.Mapping.BookMapper;
using LibraryService.Model;
using LibraryService.RepositoryClass;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Service
{

    public class BookService : IBookService
    {
        private readonly IBookListRepository _bookListRepository;

        public BookService(IBookListRepository bookListRepository)
        {
            _bookListRepository = bookListRepository;
        }

        public IBookListRepository Get_bookListRepository()
        {
            return _bookListRepository;
        }

        public async Task<List<BookDTO>> GetAllBook()
        {

            var list = await _bookListRepository.GetAllAsync();
            return list.Select(BookDTOMapper.ToDTO).ToList();
        }

        public async Task<BookDTO> GetIdBook([FromRoute] int id)
        {
            var idBook = await _bookListRepository.GetByIdAsync(id);

            if (idBook == null)
            {
                return null;
            }

            return BookDTOMapper.ToDTO(idBook);


        }

        public async Task<BookDTO> GetNIdBook(BookDTO bookDTO)
        {
            var idBook = await _bookListRepository.GetByIdAsync(bookDTO.Id);

            if (idBook == null)
            {
                return null;
            }

            return BookDTOMapper.ToDTO(idBook);

        }
        public async Task<List<BookDTO>> GetAuthorIdBook(int authorId)
        {
            var books = await _bookListRepository.GetAuthorIdBookAsync(authorId);

            if (books == null || !books.Any())
            {
                return null;
            }

            return books.Select(BookDTOMapper.ToDTO).ToList();
        }


        public async Task AddBook(BookDTO bookDTO)
        {

            var book = BookDTOMapper.ToEntity(bookDTO);

            await _bookListRepository.AddAsync(book);


        }
        public async Task UpdateBook(BookDTO bookDTO)
        {
            
            var existingEntity = await _bookListRepository.GetByIdAsync(bookDTO.Id);

            if (existingEntity == null)
            {
               
                throw new Exception("Book not found.");
            }

       
            existingEntity.Namesurname = bookDTO.Namesurname;
            existingEntity.AuthorId = bookDTO.AuthorId;

   
            await _bookListRepository.UpdateAsync(existingEntity);
        }
        public async Task DeleteBook(BookDTO bookDTO)
        {
           var deletedBook = await _bookListRepository.GetByIdAsync(bookDTO.Id);
            
            if (deletedBook == null)
            {

                throw new Exception("Book not found.");
            }

            await _bookListRepository.DeleteAsync(deletedBook);
        }

        
    }
}
