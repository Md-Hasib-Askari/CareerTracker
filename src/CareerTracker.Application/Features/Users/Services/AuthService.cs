

using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtOptions, ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtOptions.Value;
        _logger = logger;
    }

    public string GenerateJwtToken(User user)
    {
        _logger.LogInformation("Generating JWT token for user {UserId}", user.Id);
        Console.WriteLine("Generating JWT token...");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_jwtSettings.Key)
        );

        _logger.LogInformation("Using JWT key: {JwtKey}", _jwtSettings.Key);
        _logger.LogInformation("Using ExpiryMinutes: {ExpiryMinutes}", _jwtSettings.ExpiryMinutes);

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(email: loginDto.Email, ct: CancellationToken.None);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");

        return new LoginResponse
        {
            Status = "Success",
            Message = "Login successful",
            Token = GenerateJwtToken(user)
        };
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(email: registerDto.Email, ct: CancellationToken.None);
        if (existingUser != null)
            throw new InvalidOperationException("Email already exists.");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var newUser = new User
        {
            Email = registerDto.Email,
            PasswordHash = hashedPassword,
        };

        await _userRepository.AddAsync(newUser, CancellationToken.None);

        return new RegisterResponse
        {
            Status = "Success",
            Message = "Registration successful"
        };
    }

}
