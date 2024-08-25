using DTOlayer.DTOs.AuthorDTO;


namespace LibraryService.Service
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthor();
      
        Task<AuthorDTO> GetIdAuthor(int id);
        Task<AuthorDTO> GetNIdAuthor(AuthorDTO authorDTO);
        Task AddAuthor(AuthorDTO authorDTO);
        Task UpdateAuthor(AuthorDTO authorDTO);
        Task DeleteAuthor(AuthorDTO authorDTO);

    }
}