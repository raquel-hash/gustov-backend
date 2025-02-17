using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UserRepository
    {
        private readonly GustovDbContext _context;

        public UserRepository(GustovDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await _context.User.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username);
        }

        public async Task AddUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
