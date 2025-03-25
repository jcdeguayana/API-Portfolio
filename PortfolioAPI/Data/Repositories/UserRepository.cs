using PortfolioAPI.Entities;
using PortfolioAPI.Models;
using System.Net;

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

        public void AddUser(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();

        }


    }
}
