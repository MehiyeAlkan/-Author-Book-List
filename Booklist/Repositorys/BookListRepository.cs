using LibraryService.Model;
using LibraryService.RepositoryClass;
using Microsoft.EntityFrameworkCore;


namespace LibraryService.Repositorys
{


    public class BookListRepository : IBookListRepository
    {
        public readonly AppDbContext _context;

        public BookListRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<IEnumerable<Book>> GetAuthorIdBookAsync(int authorId)

        {
            return await _context.Books
                                 .Where(b => b.AuthorId == authorId)
                                 .ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteAsync(Book book)
        {
            var deletedBook = await _context.Books.FindAsync(book.Id);
            if (deletedBook != null)
            {
                _context.Books.Remove(deletedBook);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}


