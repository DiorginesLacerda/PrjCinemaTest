using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrjCinema.Data.Context;
using PrjCinema.Data.Repositories;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void InsertFilmeTest()
        {
            RepositoryBase<Filme> repositoryFilme = new FilmeRepository();
            Filme representaFilme = new Filme();

            //construcao do filme
            representaFilme.Categoria = Categoria.Ficção;
            representaFilme.Descricao = "É uma ficção";
            representaFilme.Duracao = 1.60f;
            representaFilme.Lancamento = DateTime.Now;
            representaFilme.Nacionalidade = Nacionalidade.USA;
            representaFilme.Titulo = "Star Wars";

            //add o filme
            repositoryFilme.Add(representaFilme);
        }

        [TestMethod]
        public void InsertAtorTest()
        {
            RepositoryBase<Ator> repositoryAtor = new AtorRepository();

            Ator representaAtor = new Ator();

            //construcao do ator
            representaAtor.Nome = "Mark Hamill";
            representaAtor.DataNascimento = DateTime.Now;
            representaAtor.Nacionalidade = Nacionalidade.USA;


            //add o ator
            repositoryAtor.Add(representaAtor);
        }

        [TestMethod]
        public void InsertAtuacao()
        {
            var repositoryAtuaFilme = new AtuaFilmeRepository();
          
            var atuaFilme = new AtuaFilme();

            //get ator e filme
            atuaFilme.FilmeId = 1;
            atuaFilme.AtorId = 4;
           

            //add atuacao
            repositoryAtuaFilme.Add(atuaFilme);


        }

        [TestMethod]
        public void GetAtuacao()
        {
            var filmeRepository =new AtuaFilmeRepository();
            
            Debug.WriteLine("Funciona ?");
            var listaAtorFilme = filmeRepository.BuscaAtorPorFilme(1);
            foreach (var listaAtor in listaAtorFilme)
            {
                Debug.WriteLine(listaAtor.Ator.Nome);
            } 

            
            
           
        }





    }
}
