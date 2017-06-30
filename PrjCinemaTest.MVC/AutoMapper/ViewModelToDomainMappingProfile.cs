using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Relacoes;
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
            Mapper.CreateMap<AtuaSerieModelView, AtuaSerie>();
            Mapper.CreateMap<AtuaFilmeModelView, AtuaFilme>();
            Mapper.CreateMap<UsuarioModelView, Usuario>();
            Mapper.CreateMap<EnderecoModelView, Endereco>();
        }
    }
}
