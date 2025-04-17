using Microsoft.Extensions.Configuration;

namespace Services.MappingProfiles
{
    internal class PictureUrlResolver (IConfiguration configuration)
        : IValueResolver<Product, ProductResponse, string>
    {
        public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{configuration["BaseUrl"]} {source.PictureUrl}";
            }
            return "";
        }
    }
}
