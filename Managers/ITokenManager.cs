using Proiect_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);

    }
}
