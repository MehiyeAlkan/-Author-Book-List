using LibraryService.Model;

namespace LibraryService.RepositoryClass
{
    public interface IBookListRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task<IEnumerable<Book>> GetAuthorIdBookAsync(int authorId);
    }

}
