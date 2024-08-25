using DTOlayer.DTOs.BookDTO;

namespace LibraryService.Service
{
    public interface IBookService

    {
        Task<List<BookDTO>> GetAllBook();
      
        Task<BookDTO> GetIdBook(int id);
        Task<BookDTO> GetNIdBook(BookDTO bookDTO);
        Task AddBook(BookDTO bookDTO);
        Task UpdateBook(BookDTO bookDTO);
        Task DeleteBook(BookDTO bookDTO);

        Task<List<BookDTO>> GetAuthorIdBook(int authorId);


    }
}