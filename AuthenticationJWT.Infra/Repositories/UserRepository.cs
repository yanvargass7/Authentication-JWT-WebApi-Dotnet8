using AuthenticationJWT.Domain.Interfaces;
using AuthenticationJWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationJWT.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository<User>
    {
        public User GetByUserId(int IdUser)
        {
            using AppDBContext context = new();
            return context.User.Where(m => m.Id == IdUser)
                                      .FirstOrDefault();
        }

        public User GetByUserName(string UserName)
        {
            using AppDBContext context = new();
            return context.User.Where(m => m.UserName == UserName)
                                      .FirstOrDefault();
        }
    }
}

