using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class EnderecoService: ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
            :base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
    }
}
