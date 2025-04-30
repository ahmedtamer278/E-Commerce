using System.Data;

namespace Services
{
    public class ServiceManager(IMapper mapper , IUnitOfWork unitOfWork , IBasketRepository basketRepository ,
        UserManager<ApplicationUser> userManager ,
        IOptions<JWTOptions> options)
        : IServiceManager
    {
        private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));

        private readonly Lazy<IBasketService> _basketService = new Lazy<IBasketService>(() => new BasketService(basketRepository, mapper));
        private readonly Lazy<IAuthenticationService> _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager , options , mapper));
        public IProductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;

        public IAuthenticationService AuthenticationService
            => _authenticationService.Value;
    }
}
