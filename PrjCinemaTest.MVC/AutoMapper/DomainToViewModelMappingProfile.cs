using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.MVC.Models;

namespace PrjCinema.MVC.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Ator, AtorModelView>();
            Mapper.CreateMap<Tela, TelaModelView>();
            Mapper.CreateMap<Filme, FilmeModelView>();
            Mapper.CreateMap<Serie, SerieModelView>();

            Mapper.CreateMap<Usuario, UsuarioModelView>().ForMember(x => x.GrupoAcesso, opt => opt.Ignore());
            Mapper.CreateMap<Endereco, EnderecoModelView>();
            Mapper.CreateMap<GrupoAcesso, GrupoAcessoModelView>().ForMember(x => x.Permissoes, opt => opt.Ignore()); ;
            Mapper.CreateMap<Permissao, PermissaoModelView>();
            Mapper.CreateMap<Operacao, OperacaoModelView>();
        }
    }

}

