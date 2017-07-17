using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrjCinema.Data.Repositories;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Entities.SerieFilme;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void InsertUsuario()
        {
            // var usuariBase = new UsuarioRepository();
            var representaUsuario = new Usuario();

            representaUsuario.Nome = "Gerente";
            representaUsuario.Cpf = "583.258.167-91";
            representaUsuario.Password = "gerente";
            representaUsuario.Email = "gerente@gerente.com";
            representaUsuario.Telefone = "(51) 99111-1111";
            representaUsuario.Genero = Genero.Fem;


            // usuariBase.Add(representaUsuario);
        }

        [TestMethod]
        public void InsertOperacao()
        {
            var operacao = new Operacao();
            //OperacaoRepository repository = new OperacaoRepository();

            operacao.NomeOperacao = "Adicionar";

            //repository.Add(operacao);

        }




        [TestMethod]
        public void InsertFilmeTest()
        {
            //RepositoryBase<Filme> repositoryFilme = new FilmeRepository();
            //Filme representaFilme = new Filme();

            ////construcao do filme
            //representaFilme.Categoria = Categoria.Ficção;
            //representaFilme.Descricao = "É uma ficção";
            //representaFilme.Duracao = "1600";
            //representaFilme.Lancamento = DateTime.Now;
            //representaFilme.Nacionalidade = Nacionalidade.USA;
            //representaFilme.Titulo = "Star Wars";

            ////add o filme
            //repositoryFilme.Add(representaFilme);
        }

        [TestMethod]
        public void InsertAtorTest()
        {
            //RepositoryBase<Ator> _atorRepository = new AtorRepository();
            //Ator representaAtor = new Ator();
            //try
            //{
            //    //construcao do ator
            //    representaAtor.Nome = "Algum ator famoso";
            //    representaAtor.DataNascimento = DateTime.Now;
            //    representaAtor.Nacionalidade = Nacionalidade.USA;
            //    //if (AtorExiste(representaAtor))
            //    //{
            //    //    throw new Exception("Este ator ja existe");
            //    //}
            //    //add o ator
            //    _atorRepository.Add(representaAtor);

            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e);
            //    throw;
            //}

        }

        public bool AtorExiste(Ator representaAtor)
        {
            // AtorRepository _atorRepository = new AtorRepository();

            //if (_atorRepository.GetAll().Any(u => u.Nome == representaAtor.Nome &&
            //                                      u.DataNascimento == representaAtor.DataNascimento &&
            //                                      u.Nacionalidade == representaAtor.Nacionalidade))
            //{
            //    return true;
            //}

            return false;
        }

        public bool AtuacaoExiste(int idAtor, int idFilme)
        {
            //var atuaFilme = new FilmeRepository();
            //var filmes = atuaFilme.BuscaFilmesPorAtor(idAtor);
            //if (filmes.Any(u => u.Id == idFilme))
            //{
            //    return true;
            //}
            return false;
        }

        [TestMethod]
        public void InsertAtuacao()
        {


            //var _atorRep = new AtorRepository();
            //var _filmeRep = new FilmeRepository();
            //try
            //{
            //    var filme = _filmeRep.GetById(1);
            //    var ator = _atorRep.GetById(1);

            //    //get ator e filme
            //    filme.FilmeAtores.Add(ator);
            //    //ator.AtorFilmes.Add(filme);
            //    //if (AtuacaoExiste(1, 1))
            //    //{
            //    //    throw new Exception("Ja existe");
            //    //}

            //    _filmeRep.Update(filme);
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e);
            //    throw;
            //}



        }

        //    [TestMethod]
        //    public void GetAtuacao()
        //    {
        //        var filmeRepository = new FilmeRepository();

        //        Debug.WriteLine("Funciona ?");
        //        var listaAtorFilme = filmeRepository.BuscaAtorPorFilme(1);
        //        foreach (var listaAtor in listaAtorFilme)
        //        {
        //            Debug.WriteLine(listaAtor.Ator.Nome);
        //        }
        //    }

        //    [TestMethod]
        //    public void AddPermissao()
        //    {
        //        var permissaoRepository = new PermissaoRepository();
        //        var permissao = new Permissao();
        //        permissao.Nome = "Permissao Gerente";
        //        permissao.Operacoes = new List<Operacao>
        //        {
        //            Operacao.Adicionar, Operacao.AtivarInativar, Operacao.Deletar, Operacao.Editar, Operacao.Visualizar
        //        };

        //        permissaoRepository.Add(permissao);
        //    }

        //    [TestMethod]
        //    public void AddGrupo()
        //    {
        //        var grupoAcessoRepository = new GrupoAcessoRepository();
        //        //var _usuarioRepository = new UsuarioRepository();
        //        var grupoAcesso = new GrupoAcesso();
        //        // var permissaoRepository = new PermissaoRepository();
        //        // var usuario = _usuarioRepository.GetById(9);
        //        grupoAcesso.Nome = "GerenteCompleto";
        //        grupoAcesso.Perfil = Perfil.Gerente;
        //        // var permissao = permissaoRepository.GetById(1);

        //        //grupoAcesso.Permissoes = new List<Permissao>
        //        //{
        //        //    permissao
        //        //}; 

        //        //grupoAcesso.Usuarios = new List<Usuario>
        //        //{
        //        //    usuario
        //        //};

        //        grupoAcessoRepository.Add(grupoAcesso);
        //    }



        //    [TestMethod]
        //    public void AddPermissaoGrupo()
        //    {
        //        var repository = new GrupoAcessoPermissaoRepository();

        //        var grupoAcesso = new GrupoAcessoPermissao();
        //        try
        //        {
        //            //get
        //            grupoAcesso.GrupoAcessoId = 2;
        //            grupoAcesso.PermissaoId = 3;

        //            //add 
        //            repository.Add(grupoAcesso);
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine(e);
        //            throw;
        //        }
        //    }

        //    [TestMethod]
        //    public void AddUsuarioGrupo()
        //    {
        //        var repository = new GrupoAcessoUsuarioRepository();

        //        var grupoAcesso = new GrupoAcessoUsuario();
        //        try
        //        {
        //            //get
        //            grupoAcesso.GrupoAcessoId = 2;
        //            grupoAcesso.UsuarioId = 10;

        //            //add 
        //            repository.Add(grupoAcesso);
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine(e);
        //            throw;
        //        }
        //    }

        //    [TestMethod]
        //    public void MostraPermissoes()
        //    {
        //        var repository = new GrupoAcessoPermissaoRepository();
        //        foreach (var permissao in repository.ListaPermissaoPorGrupo(1))
        //        {
        //            Debug.WriteLine(permissao.Permissao.Operacoes);
        //        }
        //    }

    }
}
