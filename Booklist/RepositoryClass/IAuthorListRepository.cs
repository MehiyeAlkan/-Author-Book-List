using LibraryService.Model;

namespace LibraryService.RepositoryClass
{
    public interface IAuthorListRepository


    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(Author author);
    }



}
