using AutoMapper;
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
        }
    }

}

