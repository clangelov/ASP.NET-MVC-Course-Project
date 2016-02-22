namespace VinylC.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VinylC.Data;
    using VinylC.Data.Models;
    using VinylC.Data.Repositories;
    using VinylC.Services.Data.Contracts;

    public class PlaceService : IPlaceService
    {
        private readonly IRepository<Place> places;
        private readonly IRepository<Opinion> opinions;
        private readonly IRepository<Tag> tags;
        private readonly IVinylCDbContext dbContext;

        public PlaceService(IRepository<Place> places, IRepository<Opinion> opinions, IVinylCDbContext dbContext, IRepository<Tag> tags)
        {
            this.places = places;
            this.opinions = opinions;
            this.dbContext = dbContext;
            this.tags = tags;
        }

        public void AddNewOpinion(Opinion newOppinion)
        {
            this.opinions.Add(newOppinion);
            this.opinions.SaveChanges();
        }

        public void AddTags(int id, List<string> tagNames)
        {
            var placeFromDb = this.dbContext.Places.Find(id);
            var tagsFromDb = this.dbContext.Tags.ToList();

            if (placeFromDb.Tags.Count == 0)
            {                
                var tagsToAdd = new List<Tag>();

                foreach (var tag in tagNames)
                {
                    var tagFromDb = tagsFromDb.FirstOrDefault(t => t.Name == tag);

                    if (tagFromDb == null)
                    {
                        tagsToAdd.Add(new Tag { Name = tag });
                    }
                    else
                    {
                        tagsToAdd.Add(tagFromDb);
                    }
                }

                placeFromDb.Tags = tagsToAdd;
                this.dbContext.SaveChanges();
            }
            else
            {
                var tagsToAdd = new List<Tag>();

                foreach (var tag in tagNames)
                {
                    var tagFromDb = tagsFromDb.FirstOrDefault(t => t.Name == tag);

                    if (tagFromDb == null)
                    {
                        tagsToAdd.Add(new Tag { Name = tag });
                    }
                    else
                    {
                        tagsToAdd.Add(tagFromDb);
                    }
                }

                foreach (var item in tagsToAdd)
                {
                    if (placeFromDb.Tags.FirstOrDefault(t => t.Name == item.Name) == null)
                    {
                        placeFromDb.Tags.Add(item);
                    }
                }
            }

            this.dbContext.SaveChanges();
        }

        public IQueryable<Place> AllPlaces()
        {
            return this.places.All().OrderBy(p => p.Title);
        }

        public IQueryable<Place> AllByTag(int id)
        {
            return this.tags.All().Where(t => t.Id == id).SelectMany(p => p.Places);
        }
    }
}