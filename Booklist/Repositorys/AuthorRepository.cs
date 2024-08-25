using LibraryService.Model;
using LibraryService.RepositoryClass;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Repositorys
{

    public class AuthorRepository : IAuthorListRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
     
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            var deletedauthor = await _context.Authors.FindAsync(author.Id);
            if (deletedauthor != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

    }


}

