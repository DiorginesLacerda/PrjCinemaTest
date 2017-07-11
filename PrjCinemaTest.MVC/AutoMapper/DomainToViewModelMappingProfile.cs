using AutoMapper;
using PrjCinema.Domain.Entities;
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
            Mapper.CreateMap<Filme, FilmeModelView>();
            Mapper.CreateMap<Serie, SerieModelView>();
            Mapper.CreateMap<Usuario, UsuarioModelView>();
            Mapper.CreateMap<Endereco, EnderecoModelView>();
        }
    }

}

