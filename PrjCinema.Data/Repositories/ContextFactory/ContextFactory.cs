using PrjCinema.Data.Context;

namespace PrjCinema.Data.Repositories.ContextFactory
{
    public class ContextFactory : IContextFactory
    {
        private ProjectContext _context;

        public ContextFactory()
        {
            _context = new ProjectContext();
        }


        public ProjectContext GetContext()
        {
            return _context;
        }
    }
}
