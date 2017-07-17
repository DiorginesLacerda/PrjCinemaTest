using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.MVC.Models;

namespace PrjCinema.MVC.AutoMapper
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<AtorModelView, Ator>();
            Mapper.CreateMap<FilmeModelView, Filme>();
            Mapper.CreateMap<SerieModelView, Serie>();
            Mapper.CreateMap<UsuarioModelView, Usuario>();
            Mapper.CreateMap<EnderecoModelView, Endereco>();
            Mapper.CreateMap<GrupoAcessoModelView, GrupoAcesso>();
            Mapper.CreateMap<PermissaoModelView, Permissao>();
            Mapper.CreateMap<OperacaoModelView, Operacao>();
        }
    }
}
