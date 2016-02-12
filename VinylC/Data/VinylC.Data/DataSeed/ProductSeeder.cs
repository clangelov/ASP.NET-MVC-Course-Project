namespace VinylC.Data.DataSeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ProductSeeder : IDataSeeder
    {
        public void Seed(VinylCDbContext context)
        {
            const string authorUserName = "VinylReatailor";

            var isAuthorSeeded = context.Users.Any(u => u.UserName == authorUserName);

            if (!isAuthorSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(new User() { UserName = authorUserName, Email = "reatailor@master.com", Avatar = Avatar.AdminAvatar }, "123456");

                var author = context.Users.FirstOrDefault(u => u.UserName == authorUserName);

                var products = new List<Product>
                {
                   new Product
                   {
                       Title = "New iPhone 7",
                       Description = "According to Apple's traditional cadence, new iPhone models debut in the fall. The 6S and 6S Plus were unveiled on September 9 and hit store shelves on September 25, and we have every reason to expect the next major update to come around this same period in 2016",
                       Price = 999,
                       ReleaseDate = new DateTime(2016,9,25),
                       UserId = author.Id,
                       Picture = "/Content/Products/iphone-7.png"
                   },
                   new Product
                   {
                       Title = "Audio-Technica Wireless",
                       Description = "Bluetooth-compatible + fully automatic belt-driven turntable from Audio-Technica. Connects to wireless speakers, sound bars and headphones for an unforgettable listening experience, all with the high-quality performance you'd expect from Audio-Technica. Complete with both stereo phono and line-level pre-amp. Complete with two speeds - 33 1/3 and 45 rpm. To play outside of the US, please pair with a power converter",
                       Price = 180,
                       ReleaseDate = new DateTime(2016,4,21),
                       UserId = author.Id,
                       Picture = "/Content/Products/37762911.jpg"
                   },
                   new Product
                   {
                       Title = "Ion Duo Turntabl",
                       Description = "Totally portable, the Duo Deck from Ion is fully equipped to play both vinyl and cassettes, as well as transfer them as MP3s through iTunes to your computer with the included software. Plays + converts 33 1/13 + 45 records, as well as both normal + chrome cassette tapes.",
                       Price = 89,
                       ReleaseDate = new DateTime(2016,5,5),
                       UserId = author.Id,
                       Picture = "/Content/Products/38124186_000_b.jpg"
                   },
                   new Product
                   {
                       Title = "Fujifilm Instax Mini",
                       Description = "The newest addition to the Instax family, the Instax Mini 70 includes new shooting settings in a modern design. Includes hand strap so you can take it with you anywhere. Whether you already have an Instax and are looking to update, or are new to instant photography, the Mini 70 is the perfect camera for wherever your photography takes you. Makes a great gift idea, too!",
                       Price = 149,
                       ReleaseDate = new DateTime(2016,7,5),
                       UserId = author.Id,
                       Picture = "/Content/Products/3795345.jpg"
                   },
                   new Product
                   {
                       Title = "App-Enabled Droid",
                       Description = "Over the years, the magic of Star Wars™ has always lived on screen and in our imaginations. Thanks to our advancements in technology, we've made it possible to bring a new part of Star Wars: The Force Awakens™ into your home. Meet BB-8™ - the app-enabled Droid whose movements and personality are as authentic as they are advanced. Based on your interactions, BB-8™ will show a range of expressions and perk up when you give voice commands. Watch your Droid explore autonomously, guide BB-8™ yourself, or create and view holographic recordings. BB-8™ is more than a toy - it's your companion.",
                       Price = 151,
                       ReleaseDate = new DateTime(2016,3,5),
                       UserId = author.Id,
                       Picture = "/Content/Products/3676533d.jpg"
                   },
                   new Product
                   {
                       Title = "Hella Personal Film Fest. LP",
                       Description = "Open Mike Eagle is back, this time with producer Paul White, who you may know from his work with Danny Brown, Homeboy Sandman and Mos Def (Yasiin Bey).Hella Personal Film Festival is sharper than anything either artist has done before. Features are sparse and pointed, one from Aesop Rock and the other from Future Islands frontman, Hemlock Ernst",
                       Price = 15,
                       ReleaseDate = new DateTime(2016,3,25),
                       UserId = author.Id,
                       Picture = "/Content/Products/a1158245013_10.jpg"
                   }
                };

                foreach (var item in products)
                {
                    context.Products.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
