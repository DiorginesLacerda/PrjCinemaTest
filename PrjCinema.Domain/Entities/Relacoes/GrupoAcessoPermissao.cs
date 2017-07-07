using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Domain.Entities.Relacoes
{
    public class GrupoAcessoPermissao
    {
        public int GrupoAcessoId { get; set; }
        public virtual GrupoAcesso GrupoAcesso { get; set; }
        public int PermissaoId { get; set; }
        public virtual Permissao Permissao { get; set; }
    }
}
