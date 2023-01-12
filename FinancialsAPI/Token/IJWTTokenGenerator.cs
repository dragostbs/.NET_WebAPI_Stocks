using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Token
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(IdentityUser user);
    }
    
}
