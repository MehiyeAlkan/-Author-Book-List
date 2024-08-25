using DTOlayer.DTOs.AuthorDTO;
using LibraryService.Mapping.AuthorMapper;
using LibraryService.RepositoryClass;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Service
{

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorListRepository _authorRepository;

        public AuthorService(IAuthorListRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IAuthorListRepository Get_authorRepository()
        {
            return _authorRepository;
        }

        public async Task<List<AuthorDTO>> GetAllAuthor()
        {

            var list = await _authorRepository.GetAllAsync();
            return list.Select(AuthorDTOMapper.ToDTO).ToList();
        }

        public async Task<AuthorDTO> GetIdAuthor([FromRoute] int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            return AuthorDTOMapper.ToDTO(author);


        }

        public async Task<AuthorDTO> GetNIdAuthor(AuthorDTO authorDTO)
        {
            var author = await _authorRepository.GetByIdAsync(authorDTO.Id);

            return AuthorDTOMapper.ToDTO(author);

        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {

            var author = AuthorDTOMapper.ToEntity(authorDTO);

            await _authorRepository.AddAsync(author);


        }
        public async Task UpdateAuthor(AuthorDTO authorDTO)
        {
            var existingEntity = await _authorRepository.GetByIdAsync(authorDTO.Id);

            if (existingEntity == null)
            {
                throw new Exception("Author not found.");
            }


            existingEntity.Namesurname = authorDTO.Namesurname;



            await _authorRepository.UpdateAsync(existingEntity);
        }
        public async Task DeleteAuthor(AuthorDTO authorDTO)
        {
            var deletedEntity = await _authorRepository.GetByIdAsync(authorDTO.Id);

            if (deletedEntity == null)
            {
                throw new Exception("Author not found.");
            }
            await _authorRepository.DeleteAsync(deletedEntity);


        }

        
    }
}
