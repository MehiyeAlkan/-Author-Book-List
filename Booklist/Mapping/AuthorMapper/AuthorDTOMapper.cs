using DTOlayer.DTOs.AuthorDTO;
using DTOlayer.DTOs.BookDTO;
using LibraryService.Model;

namespace LibraryService.Mapping.AuthorMapper
{
    public static class AuthorDTOMapper
    {
        public static Author ToEntity(AuthorDTO authorDTO)
        {
            return new Author
            {
                Id = authorDTO.Id,
                Namesurname = authorDTO.Namesurname
                
            };
        }


        public static AuthorDTO ToDTO(Author author)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                Namesurname = author.Namesurname
                
            };
        }
    }
}
