using AuthenticationJWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationJWT.Domain.Interfaces
{
    public interface IToken
    {
        string GenerateToken(User user);
    }
}
