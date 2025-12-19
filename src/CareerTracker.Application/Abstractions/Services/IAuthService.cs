public interface IAuthService
{
    // Define authentication-related methods here, e.g.:
    // Task<User> AuthenticateAsync(string username, string password);
    Task<RegisterResponse> RegisterAsync(RegisterRequest registerDto);
    Task<LoginResponse> LoginAsync(LoginRequest loginDto);
    string GenerateJwtToken(User user);
}