using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrjCinema.Data.Context;

namespace PrjCinema.Data.Repositories.ContextFactory
{
    public interface IContextFactory 
    {
        ProjectContext GetContext();
    }
}
