using AuthenticationJWT.Domain.Interfaces;
using AuthenticationJWT.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace AuthenticationJWT.Application.Applications
{
    public class UserApp : IUser
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<User> _userRepository;
        public UserApp(IConfiguration configuration, IUserRepository<User> userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public User GetUser(int IdUser)
        {
            return (_userRepository.GetByUserId(IdUser));
        }
        void IUser.AddUser(User user)
        {
            _userRepository.Insert(user);
        }
    }
}

