using Microsoft.AspNetCore.Identity;

namespace ecommerce.Identity
{
    public class LowerCaseLookupNormalizer : ILookupNormalizer
    {
        public string NormalizeName(string name)
        {
            return name?.ToLowerInvariant();
        }

        public string NormalizeEmail(string email)
        {
            return email?.ToLowerInvariant();
        }
    }
}
