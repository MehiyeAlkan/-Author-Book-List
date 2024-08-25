using DTOlayer.DTOs.BookDTO;
using LibraryService.Model;

namespace LibraryService.Mapping.BookMapper
{
    public static class BookDTOMapper
    {
        public static Book ToEntity(BookDTO bookDTO)
        {
            return new Book
            {
                Id = bookDTO.Id,
                Namesurname = bookDTO.Namesurname,
                AuthorId = bookDTO.AuthorId
            };
        }


        public static BookDTO ToDTO(Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                Namesurname = book.Namesurname,
                AuthorId = book.AuthorId
            };
        }

    }
}
