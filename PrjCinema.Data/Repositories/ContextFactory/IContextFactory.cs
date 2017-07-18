using PrjCinema.Data.Context;

namespace PrjCinema.Data.Repositories.ContextFactory
{
    public interface IContextFactory 
    {
        ProjectContext GetContext();
    }
}
