using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcCalculateService.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(string login, string password);
    }
}
