using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrjCinema.Data.Repositories;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
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

        [TestMethod]
        public void AddPermissao()
        {
            var permissaoRepository = new PermissaoRepository();
            var permissao = new Permissao();
            permissao.Nome = "Nova Permissao";
            permissao.Operacoes = new List<Operacao>
            {
                Operacao.Adicionar, Operacao.AtivarInativar, Operacao.AtribuirPermissao, Operacao.Deletar, Operacao.Editar, Operacao.Visualizar
            };

            permissaoRepository.Add(permissao);
        }

        [TestMethod]
        public void AddGrupo()
        {
            var grupoAcessoRepository = new GrupoAcessoRepository();
            //var _usuarioRepository = new UsuarioRepository();
            var grupoAcesso = new GrupoAcesso();
            // var permissaoRepository = new PermissaoRepository();
            // var usuario = _usuarioRepository.GetById(9);
            grupoAcesso.Nome = "Adminstrador Completo";
            grupoAcesso.Perfil = Perfil.Adminstrador;
            // var permissao = permissaoRepository.GetById(1);

            //grupoAcesso.Permissoes = new List<Permissao>
            //{
            //    permissao
            //}; 

            //grupoAcesso.Usuarios = new List<Usuario>
            //{
            //    usuario
            //};

            grupoAcessoRepository.Add(grupoAcesso);
        }

        [TestMethod]
        public void AddPermissoesGrupo()
        {
            var _grupoAcessoRepository = new GrupoAcessoRepository();
            //var _usuarioRepository = new UsuarioRepository();
            var grupoAcesso = _grupoAcessoRepository.GetById(1);
            var _permissaoRepository = new PermissaoRepository();
            var permissao = _permissaoRepository.GetById(4);



            //grupoAcesso.Permissoes = new List<Permissao>
            //{
            //    permissao
            //};

            //grupoAcesso.Usuarios = new List<Usuario>
            //{
            //    usuario
            //};
            //Debug.WriteLine(grupoAcesso.Permissoes.ToString());
            //_grupoAcessoRepository.Update(grupoAcesso);
        }
        
        [TestMethod]
        public void AddPermissaoGrupo()
        {
            var repository = new GrupoAcessoPermissaoRepository();

            var grupoAcesso = new GrupoAcessoPermissao();
            try
            {
                //get
                grupoAcesso.GrupoAcessoId = 1;
                grupoAcesso.PermissaoId = 2;

                //add 
                repository.Add(grupoAcesso);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        [TestMethod]
        public void AddUsuarioGrupo()
        {
            var repository = new GrupoAcessoUsuarioRepository();

            var grupoAcesso = new GrupoAcessoUsuario();
            try
            {
                //get
                grupoAcesso.GrupoAcessoId = 1;
                grupoAcesso.UsuarioId = 9;

                //add 
                repository.Add(grupoAcesso);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        [TestMethod]
        public void MostraPermissoes()
        {
            var repository = new GrupoAcessoPermissaoRepository();
            foreach (var permissao in repository.ListaPermissaoPorGrupo(1))
            {
                Debug.WriteLine(permissao.Permissao.Operacoes);
            }
        }
    }
}
