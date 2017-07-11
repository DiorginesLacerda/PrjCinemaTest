using System;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface ITEntity : ICloneable
    {
        int Id { get; set; }
        bool Removido { get; set; }
    }
}
