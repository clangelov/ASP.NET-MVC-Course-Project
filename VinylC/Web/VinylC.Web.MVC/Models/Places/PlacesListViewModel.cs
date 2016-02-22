namespace VinylC.Web.MVC.Models.Places
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;
    using Tags;

    public class PlacesListViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public IEnumerable<TagsListViewModel> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Place, PlacesListViewModel>()
                .ForMember(m => m.Longitude, opt => opt.MapFrom(x => x.GeoLocation.Longitude))
                .ForMember(m => m.Latitude, opt => opt.MapFrom(x => x.GeoLocation.Latitude));
        }
    }
}