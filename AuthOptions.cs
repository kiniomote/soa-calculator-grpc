using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GrpcCalculateService
{
    public class AuthOptions
    {
        public const string ISSUER = "https://soa-calculator.herokuapp.com/"; // издатель токена
        public const string AUDIENCE = "https://soa-calculator-grpc.herokuapp.com/"; // потребитель токена
        const string KEY = "sedjfrwi23t62uw3je";   // ключ для шифрации
        public const int LIFETIME = 5; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
