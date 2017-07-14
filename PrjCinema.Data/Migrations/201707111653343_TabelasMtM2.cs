namespace PrjCinema.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TabelasMtM2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FilmeAtor", newName: "AtuaFilmes");
            RenameTable(name: "dbo.SerieAtor", newName: "AtuaSeries");
            RenameTable(name: "dbo.PermissaoGrupoAcesso", newName: "GrupoAcessosPermissoes");
            RenameTable(name: "dbo.UsuarioGrupoAcesso", newName: "GrupoAcessosUsuarios");
            RenameColumn(table: "dbo.AtuaFilmes", name: "Filme_Id", newName: "IdAtoresFK");
            RenameColumn(table: "dbo.AtuaFilmes", name: "Ator_Id", newName: "IdFilmesFK");
            RenameColumn(table: "dbo.AtuaSeries", name: "Serie_Id", newName: "IdAtoresFK");
            RenameColumn(table: "dbo.AtuaSeries", name: "Ator_Id", newName: "IdFilmesFK");
            RenameColumn(table: "dbo.GrupoAcessosPermissoes", name: "Permissao_Id", newName: "IdPermiessoesFK");
            RenameColumn(table: "dbo.GrupoAcessosPermissoes", name: "GrupoAcesso_Id", newName: "IdGrupoAcessosFK");
            RenameColumn(table: "dbo.GrupoAcessosUsuarios", name: "Usuario_Id", newName: "IdUsuariosFK");
            RenameColumn(table: "dbo.GrupoAcessosUsuarios", name: "GrupoAcesso_Id", newName: "IdGrupoAcessosFK");
            RenameIndex(table: "dbo.AtuaFilmes", name: "IX_Ator_Id", newName: "IX_IdFilmesFK");
            RenameIndex(table: "dbo.AtuaFilmes", name: "IX_Filme_Id", newName: "IX_IdAtoresFK");
            RenameIndex(table: "dbo.AtuaSeries", name: "IX_Ator_Id", newName: "IX_IdFilmesFK");
            RenameIndex(table: "dbo.AtuaSeries", name: "IX_Serie_Id", newName: "IX_IdAtoresFK");
            RenameIndex(table: "dbo.GrupoAcessosPermissoes", name: "IX_GrupoAcesso_Id", newName: "IX_IdGrupoAcessosFK");
            RenameIndex(table: "dbo.GrupoAcessosPermissoes", name: "IX_Permissao_Id", newName: "IX_IdPermiessoesFK");
            RenameIndex(table: "dbo.GrupoAcessosUsuarios", name: "IX_GrupoAcesso_Id", newName: "IX_IdGrupoAcessosFK");
            RenameIndex(table: "dbo.GrupoAcessosUsuarios", name: "IX_Usuario_Id", newName: "IX_IdUsuariosFK");
            DropPrimaryKey("dbo.AtuaFilmes");
            DropPrimaryKey("dbo.AtuaSeries");
            DropPrimaryKey("dbo.GrupoAcessosPermissoes");
            DropPrimaryKey("dbo.GrupoAcessosUsuarios");
            AddPrimaryKey("dbo.AtuaFilmes", new[] { "IdFilmesFK", "IdAtoresFK" });
            AddPrimaryKey("dbo.AtuaSeries", new[] { "IdFilmesFK", "IdAtoresFK" });
            AddPrimaryKey("dbo.GrupoAcessosPermissoes", new[] { "IdGrupoAcessosFK", "IdPermiessoesFK" });
            AddPrimaryKey("dbo.GrupoAcessosUsuarios", new[] { "IdGrupoAcessosFK", "IdUsuariosFK" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GrupoAcessosUsuarios");
            DropPrimaryKey("dbo.GrupoAcessosPermissoes");
            DropPrimaryKey("dbo.AtuaSeries");
            DropPrimaryKey("dbo.AtuaFilmes");
            AddPrimaryKey("dbo.GrupoAcessosUsuarios", new[] { "Usuario_Id", "GrupoAcesso_Id" });
            AddPrimaryKey("dbo.GrupoAcessosPermissoes", new[] { "Permissao_Id", "GrupoAcesso_Id" });
            AddPrimaryKey("dbo.AtuaSeries", new[] { "Serie_Id", "Ator_Id" });
            AddPrimaryKey("dbo.AtuaFilmes", new[] { "Filme_Id", "Ator_Id" });
            RenameIndex(table: "dbo.GrupoAcessosUsuarios", name: "IX_IdUsuariosFK", newName: "IX_Usuario_Id");
            RenameIndex(table: "dbo.GrupoAcessosUsuarios", name: "IX_IdGrupoAcessosFK", newName: "IX_GrupoAcesso_Id");
            RenameIndex(table: "dbo.GrupoAcessosPermissoes", name: "IX_IdPermiessoesFK", newName: "IX_Permissao_Id");
            RenameIndex(table: "dbo.GrupoAcessosPermissoes", name: "IX_IdGrupoAcessosFK", newName: "IX_GrupoAcesso_Id");
            RenameIndex(table: "dbo.AtuaSeries", name: "IX_IdAtoresFK", newName: "IX_Serie_Id");
            RenameIndex(table: "dbo.AtuaSeries", name: "IX_IdFilmesFK", newName: "IX_Ator_Id");
            RenameIndex(table: "dbo.AtuaFilmes", name: "IX_IdAtoresFK", newName: "IX_Filme_Id");
            RenameIndex(table: "dbo.AtuaFilmes", name: "IX_IdFilmesFK", newName: "IX_Ator_Id");
            RenameColumn(table: "dbo.GrupoAcessosUsuarios", name: "IdGrupoAcessosFK", newName: "GrupoAcesso_Id");
            RenameColumn(table: "dbo.GrupoAcessosUsuarios", name: "IdUsuariosFK", newName: "Usuario_Id");
            RenameColumn(table: "dbo.GrupoAcessosPermissoes", name: "IdGrupoAcessosFK", newName: "GrupoAcesso_Id");
            RenameColumn(table: "dbo.GrupoAcessosPermissoes", name: "IdPermiessoesFK", newName: "Permissao_Id");
            RenameColumn(table: "dbo.AtuaSeries", name: "IdFilmesFK", newName: "Ator_Id");
            RenameColumn(table: "dbo.AtuaSeries", name: "IdAtoresFK", newName: "Serie_Id");
            RenameColumn(table: "dbo.AtuaFilmes", name: "IdFilmesFK", newName: "Ator_Id");
            RenameColumn(table: "dbo.AtuaFilmes", name: "IdAtoresFK", newName: "Filme_Id");
            RenameTable(name: "dbo.GrupoAcessosUsuarios", newName: "UsuarioGrupoAcesso");
            RenameTable(name: "dbo.GrupoAcessosPermissoes", newName: "PermissaoGrupoAcesso");
            RenameTable(name: "dbo.AtuaSeries", newName: "SerieAtor");
            RenameTable(name: "dbo.AtuaFilmes", newName: "FilmeAtor");
        }
    }
}
