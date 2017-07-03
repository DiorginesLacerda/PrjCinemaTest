using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrjCinema.Data.Context;
using PrjCinema.Data.Repositories;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void InsertUsuario()
        {
            var usuariBase = new UsuarioRepository();
            var representaUsuario = new Usuario();

            representaUsuario.Nome = "Leyla";
            representaUsuario.Cpf = "028.741.970-33";
            representaUsuario.DataCadastro = DateTime.Now;
            representaUsuario.Email = "leyla@leyla.com";
            representaUsuario.Telefone = "(51) 99111-1111";
            representaUsuario.Genero = Genero.Fem;
            representaUsuario.Perfil = Perfil.Adminstrador;

            usuariBase.Add(representaUsuario);
        }


        [TestMethod]
        public void InsertFilmeTest()
        {
            RepositoryBase<Filme> repositoryFilme = new FilmeRepository();
            Filme representaFilme = new Filme();

            //construcao do filme
            representaFilme.Categoria = Categoria.Ficção;
            representaFilme.Descricao = "É uma ficção";
            representaFilme.Duracao = "1600";
            representaFilme.Lancamento = DateTime.Now;
            representaFilme.Nacionalidade = Nacionalidade.USA;
            representaFilme.Titulo = "Star Wars";

            //add o filme
            repositoryFilme.Add(representaFilme);
        }

        [TestMethod]
        public void InsertAtorTest()
        {
            RepositoryBase<Ator> _atorRepository = new AtorRepository();
            Ator representaAtor = new Ator();
            try
            {
                //construcao do ator
                representaAtor.Nome = "Algum ator famoso";
                representaAtor.DataNascimento = _atorRepository.GetById(1).DataNascimento;
                representaAtor.Nacionalidade = Nacionalidade.USA;
                if (AtorExiste(representaAtor))
                {
                    throw new Exception("Este ator ja existe");
                }
                //add o ator
                _atorRepository.Add(representaAtor);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }

        public bool AtorExiste(Ator representaAtor)
        {
            AtorRepository _atorRepository = new AtorRepository();

            if (_atorRepository.GetAll().Any(u => u.Nome == representaAtor.Nome && u.DataNascimento == representaAtor.DataNascimento && u.Nacionalidade == representaAtor.Nacionalidade))
            {
                return true;
            }

            return false;
        }

        public bool AtuacaoExiste(int idAtor, int idFilme)
        {
            AtuaFilmeRepository atuaFilme = new AtuaFilmeRepository();
            var filmes = atuaFilme.ListaFilmePorAtor(idAtor);
            if (filmes.Any(u => u.FilmeId == idFilme))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public void InsertAtuacao()
        {
            var repositoryAtuaFilme = new AtuaFilmeRepository();

            var atuaFilme = new AtuaFilme();
            try
            {
                //get ator e filme
                atuaFilme.FilmeId = 1;
                atuaFilme.AtorId = 1;
                if (AtuacaoExiste(atuaFilme.AtorId, atuaFilme.AtorId))
                {
                    throw new Exception("Ja existe");
                }
                //add atuacao
                repositoryAtuaFilme.Add(atuaFilme);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }



        }

        [TestMethod]
        public void GetAtuacao()
        {
            var filmeRepository = new AtuaFilmeRepository();

            Debug.WriteLine("Funciona ?");
            var listaAtorFilme = filmeRepository.BuscaAtorPorFilme(1);
            foreach (var listaAtor in listaAtorFilme)
            {
                Debug.WriteLine(listaAtor.Ator.Nome);
            }




        }





    }
}
