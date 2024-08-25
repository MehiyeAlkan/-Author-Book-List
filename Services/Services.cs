using DTOlayer.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Services;


namespace Services
{
    public class Services
    {
        public class BookService : IBookService
        {
            private readonly IBookListRepository _bookListRepository;

            public BookService(IBookListRepository bookListRepository)
            {
                _bookListRepository = bookListRepository;
            }

            public void AddBook(BookDTO bookDTO)
            {
                var book = BookDTOMapper.ToEntity(bookDTO);
                _bookListRepository.Add(book);
            }
        }

    }
}