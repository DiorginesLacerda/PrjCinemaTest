using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Domain.Entities.Relacoes
{
    public class GrupoAcessoUsuario
    {
        public int GrupoAcessoId { get; set; }
        public virtual GrupoAcesso GrupoAcesso { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
