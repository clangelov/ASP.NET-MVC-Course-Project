namespace VinylC.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using VinylC.Data.Models;

    public interface IPlaceService
    {
        IQueryable<Place> AllPlaces();

        void AddNewOpinion(Opinion newOppinion);

        void AddTags(int id, List<string> tagNames);
    }
}
