using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>,IEnderecoRepository
    {
        public EnderecoRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
        //public void Add(Endereco obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<Endereco> GetAll()
        //{
        //    return GetAll();
        //}

        //public Endereco GetById(int id)
        //{
        //    return GetById(id);
        //}

        //public void Remove(Endereco obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Endereco obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
