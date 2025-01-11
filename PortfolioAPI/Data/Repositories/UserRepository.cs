using PortfolioAPI.Entities;

namespace PortfolioAPI.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User? Authenticate(string User, string Password)
        {
            User? UserToAuthenticate = _context.Users.FirstOrDefault(a=>a.UserName == User && a.Password==Password);
            return UserToAuthenticate;
        }
    }
}
