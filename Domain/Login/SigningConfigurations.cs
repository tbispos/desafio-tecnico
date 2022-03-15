using Domain.Interface.Login;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Login
{
    public class SigningConfigurations : ISigningConfigurations
    {
        public SecurityKey Key                       { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            // Gera sempre a mesma chave
            Key = new SymmetricSecurityKey
                       (Encoding.UTF8.GetBytes("a5ccd8bf5fda564c85f798a9cc7a9b6c0a54e6f2ed93efge454aef4ef70f55tt"));

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}
