using Shared.Models;
/*
 * Vi bruger returtyper af opgave, selvom intet i dette tilfælde vil være asynkront.
 * Men skulle vi ønske at forbedre os På eksemplet, f.eks. ved at tilføje en database,
 * ville dette kræve asynkron kode, så det er bedre at være klar.
 */
namespace WebAPI.Services;
public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);

    Task RegisterUser(User user);
}