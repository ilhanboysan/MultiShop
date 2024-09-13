namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpcontextAccessor = contextAccessor;
        }

        public string GetuserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
