namespace VinylC.Services.Data
{
    using System.Linq;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class PlaceService : IPlaceService
    {
        private readonly IRepository<Place> places;

        public PlaceService(IRepository<Place> places)
        {
            this.places = places;
        }

        public IQueryable<Place> AllPlaces()
        {
            return this.places.All().OrderBy(p => p.Title);
        }
    }
}
