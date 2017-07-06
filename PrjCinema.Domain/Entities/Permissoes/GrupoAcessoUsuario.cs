namespace PrjCinema.Domain.Entities.Permissoes
{
    public class GrupoAcessoUsuario
    {
        public int Id { get; set; }
        public int GrupoAcessoId { get; set; }
        public virtual GrupoAcesso GrupoAcesso { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
