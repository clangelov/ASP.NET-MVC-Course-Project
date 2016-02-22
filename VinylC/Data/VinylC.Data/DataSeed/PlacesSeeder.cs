namespace VinylC.Data.DataSeed
{
    using System.Collections.Generic;
    using System.Linq;
    using VinylC.Data.Models;

    public class PlacesSeeder : IDataSeeder
    {
        public void Seed(VinylCDbContext context)
        {
            const string RandomDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum consequat neque non blandit pulvinar. Mauris faucibus nisl ipsum, nec mollis arcu ultricies eu. Quisque convallis aliquet blandit. Nam sodales odio lectus, quis fermentum lacus condimentum ullamcorper.";

            if (!context.Places.Any())
            {
                var places = new List<Place>
                {
                   new Place
                   {
                       Title = "Motto Club Sofia",
                       Description = RandomDescription,
                       GeoLocation = new GeoLocation
                       {
                           Longitude = 42.6936663,
                           Latitude = 23.3285904
                       }
                   },
                   new Place
                   {
                       Title = "Telerik Academy",
                       Description = RandomDescription,
                       GeoLocation = new GeoLocation
                       {
                           Longitude = 42.651293,
                           Latitude = 23.3797739
                       }
                   },
                   new Place
                   {
                       Title = "Casa de Cuba",
                       Description = RandomDescription,
                       GeoLocation = new GeoLocation
                       {
                           Longitude = 42.6771541,
                           Latitude = 23.3209239
                       }
                   },
                   new Place
                   {
                       Title = "J J Murphys",
                       Description = RandomDescription,
                       GeoLocation = new GeoLocation
                       {
                           Longitude = 42.6904616,
                           Latitude = 23.317243
                       }
                   },
                   new Place
                   {
                       Title = "Stadium Vasil Levski",
                       Description = RandomDescription,
                       GeoLocation = new GeoLocation
                       {
                           Longitude = 42.6871052,
                           Latitude = 23.3353798
                       }
                   }
                };
                
                foreach (var item in places)
                {
                    context.Places.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
