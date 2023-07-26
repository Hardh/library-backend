namespace library_backend.Application.services;

public interface IAuthService
{
    public Task<string> login(string UserName, string Password);
}