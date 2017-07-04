using System;
using System.Linq;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
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
        public bool IsUsuarioExiste(Usuario representaUsuario)
        {
            if (_usuarioRepository.GetAll().Any(u => u.Email == representaUsuario.Email || u.Cpf == representaUsuario.Cpf))
                return true;

            return false;
        }

        public bool IsEndereco(Endereco endereco)
        {
            if (endereco == null)
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
            //if (usuario.Endereco != null && usuario.EnderecoId != null)
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
    }
}
