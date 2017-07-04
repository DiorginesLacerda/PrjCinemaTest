using PrjCinema.Domain.Entities;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        bool IsLogin(string email, string password);


        

    }
}