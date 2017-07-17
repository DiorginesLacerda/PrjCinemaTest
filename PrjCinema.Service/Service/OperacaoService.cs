using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;
        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        public void Add(Operacao obj)
        {
            _operacaoRepository.Add(obj);
        }

        public Operacao GetById(int id)
        {
            return _operacaoRepository.GetById(id);
        }

        public ICollection<Operacao> GetAll()
        {
            return _operacaoRepository.GetAll();
        }

        public void Update(Operacao obj)
        {
            _operacaoRepository.Update(obj);
        }

        public void Remove(Operacao obj)
        {
            _operacaoRepository.Remove(obj);
        }

        public void Dispose()
        {
            _operacaoRepository.Dispose();
        }
    }
}