using AuthenticationJWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationJWT.Domain.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        User GetByUserId(int IdUser);
        User GetByUserName(string UserName);
    }
}