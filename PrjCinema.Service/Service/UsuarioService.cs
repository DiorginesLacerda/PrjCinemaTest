using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGrupoAcessoService _grupoAcessoService;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, GrupoAcessoService grupoAcessoService)
        {
            _grupoAcessoService = grupoAcessoService;
            _usuarioRepository = usuarioRepository;
        }

        public bool IsEmailUsuarioExiste(Usuario representaUsuario)
        {
            if (_usuarioRepository.GetAll().Any(u => u.Email == representaUsuario.Email))
                return true;

            return false;
        }

        public string AlertUsuarioExiste(Usuario usuario, int escolha)
        {
            switch (escolha)
            {
                case 1:
                    return "Já Existe um usuário utilizando este email ou CPF, por favor tente novamente cadastrar usuário " + usuario.Nome;
                case 2:
                    return "Você não pode editar o usuário " + usuario.Nome + " com estes dados, alguem já possui este E-mail ou Cpf";
                case 3:
                    return "Por favor preencha um CPF válido e tente novamente.";
                default:
                    return "Ops algo errado não está certo";
            }
        }

        public IEnumerable<Usuario> UsuariosAtivos()
        {
            return _usuarioRepository.UsuariosAtivos();
        }

        public bool IsUsuarioExiste(Usuario representaUsuario)
        {
            if (_usuarioRepository.GetAll().Any(u => u.Email == representaUsuario.Email || u.Cpf == representaUsuario.Cpf))
                return true;

            return false;
        }

        public bool IsUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return true;
            }
            return false;
        }

        public void AddUsuario(Usuario usuario)
        {
            if (usuario.DataCadastro == null)
                throw new Exception(AlertUsuarioExiste(usuario, 0));
            if (IsCpf(usuario.Cpf))
                throw new Exception(AlertUsuarioExiste(usuario, 3));
            if (IsUsuarioExiste(usuario))
                throw new Exception(AlertUsuarioExiste(usuario, 1));
            //if (usuario.Usuario != null && usuario.UsuarioId != null)
            //    throw new Exception("Algo errado não está certo");

            _usuarioRepository.Add(usuario);
        }

        public void EditarUsuario(Usuario usuario)
        {
            if (IsUsuarioExiste(usuario))
                throw new Exception(AlertUsuarioExiste(usuario, 2));

            _usuarioRepository.Update(usuario);
        }

        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return true;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return false;
        }

        //public ICollection<Usuario> GetUsuarioDoGrupo(int id)
        //{
        //    var usuGrupoId = new List<int>();
        //    var usuarios = new List<Usuario>();
        //    foreach (var pG in _grupoAcessoService.GetById(id).Permissoes.OrderBy(x => x.Id))
        //    {
        //        usuGrupoId.Add(pG.Id);
        //    }
        //    foreach (var ids in usuGrupoId)
        //    {
        //        usuarios.Add(_usuarioRepository.GetById(ids));
        //    }
        //    return usuarios;
        //}

        public ICollection<Usuario> GetUsuariosFaltantesNoGrupo(int id)
        {
            List<int> usuGrupoId = new List<int>();
            var usuarios = new List<Usuario>();
            bool ok = false;
            int whatever = 0;

            foreach (var uG in _grupoAcessoService.GetById(id).Usuarios.OrderBy(x => x.Id))
            {
                usuGrupoId.Add(uG.Id);
            }
            foreach (var p in _usuarioRepository.GetAll().OrderBy(x => x.Id))
            {
                usuGrupoId.Add(p.Id);
            }
            usuGrupoId.Sort();
            for (int i = 0; i < usuGrupoId.Count; whatever++)
            {
                if (usuGrupoId.Count > i + 1)
                {
                    if (usuGrupoId[i] == usuGrupoId[i + 1])
                    {
                        usuGrupoId.Remove(usuGrupoId[i]);
                        ok = true;
                    }
                    else if (usuGrupoId[i] != usuGrupoId[i + 1])
                    {
                        ok = false;
                    }

                    if (ok)
                    {
                        usuGrupoId.Remove(usuGrupoId[i]);
                        continue;
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }
            foreach (var ids in usuGrupoId)
            {
                usuarios.Add(_usuarioRepository.GetById(ids));
            }
            return usuarios;
        }

        public IEnumerable<Usuario> BuscaUsuariosPorGrupoAcesso(int id)
        {

            return _usuarioRepository.GetAll().Where(u => u.GrupoAcesso.Any(x => x.Id == id));
        }

        public Usuario LoginUsuario(string email, string password)
        {
            var userLogin = _usuarioRepository.GetAll().FirstOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
            if (userLogin != null)
                return userLogin;

            throw new Exception("Algo errado não está certo !");
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            var userLogin = _usuarioRepository.GetAll().FirstOrDefault(a => a.Email.Equals(email));
            if (userLogin != null)
                return userLogin;

            throw new Exception("Algo errado não está certo !");

        }

        public void Add(Usuario obj)
        {
            _usuarioRepository.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            _usuarioRepository.Update(obj);
        }

        public void Desativar(Usuario obj)
        {
            obj.Removido = true;
            _usuarioRepository.Update(obj);
        }

        public void Ativar(Usuario obj)
        {
            obj.Removido = false;
            _usuarioRepository.Update(obj);
        }
    }
}
