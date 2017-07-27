using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class TelaService : ITelaService
    {
        private readonly ITelaRepository _telaRepository;
        public TelaService(ITelaRepository telaRepository)
        {
            _telaRepository = telaRepository;
        }

        public void Add(Tela obj)
        {
            _telaRepository.Add(obj);
        }

        public Tela GetById(int id)
        {
            return _telaRepository.GetById(id);
        }

        public ICollection<Tela> GetAll()
        {
            return _telaRepository.GetAll();
        }

        public void Update(Tela obj)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Tela obj)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}