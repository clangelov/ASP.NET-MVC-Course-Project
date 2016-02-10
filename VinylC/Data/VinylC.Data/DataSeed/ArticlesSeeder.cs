namespace VinylC.Data.DataSeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using VinylC.Common.Constants;
    using VinylC.Data.Models;

    public class ArticlesSeeder : IDataSeeder
    {
        public static Random Rand = new Random();

        public void Seed(VinylCDbContext context)
        {
            const string authorUserName = "Vst@ryTeller";

            var isAuthorSeeded = context.Users.Any(u => u.UserName == authorUserName);

            if (!isAuthorSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(new User() { UserName = authorUserName, Email = "story@master.com", Avatar = Avatar.AdminAvatar }, "123456");

                var author = context.Users.FirstOrDefault(u => u.UserName == authorUserName);

                var categories = new List<AtricleCategory>
                {
                    new AtricleCategory() { Name = "Music" },
                    new AtricleCategory() { Name = "History" },
                    new AtricleCategory() { Name = "Places" },
                    new AtricleCategory() { Name = "Persons" },
                    new AtricleCategory() { Name = "Equipment" },
                    new AtricleCategory() { Name = "Events" }
                };

                foreach (var item in categories)
                {
                    context.AtricleCategories.Add(item);
                }

                var articles = new List<Article>
                {
                    new Article() {
                        Contetnt = "There are few artists in hip-hop who have ever truly matched their hype. Twenty years ago today, on April 19, 1994, Nasir \"Nas\" Jones became one of them. On that day he released his highly-anticipated debut album, \"Illmatic.\" And while the project didn't initially sell well, the 20-year-old Queensbridge native's music made an impact with the right crowd; namely, die-hard rap fans, industry insiders and most importantly, his peers. It was difficult to listen to the album for the first time and not be blown away. Escobar season was about to begin.",
                        ImageUrl = "http://ebid.s3.amazonaws.com/upload_big/1/2/3/1405024178-12177-9126.jpg",
                        UserId = author.Id,
                        Title = "Nas, 'Illmatic' At 20",
                        AtricleCategory = categories[0],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "Kendrick Lamar has an Andre 3000 like quality to his delivery. Has good songs to ride to, blaze to, and of course some tunes that you could play in the club and dance to. I encourage you to listen to Bitch Don't Kill my vibe with an open mind after a long day at work and see if you ain't feelin it. He represents a kid who made it out of the struggle and wants to take a stand against it without judging. You can tell Kendrick Lamar is more concerned with creating good music rather than making a comercial album. He also is a good story teller.",
                        ImageUrl = "https://thisindustrythingofours.files.wordpress.com/2012/10/20121023-131008.jpg",
                        UserId = author.Id,
                        Title = "Kendrick Lamar smashing new Album",
                        AtricleCategory = categories[0],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "Detroit royalty, Phat Kat, and Hieroglyphics legend Casual, come together to form ''Ron Jon Bovi.'' Features Hieroglyphics members Opio and Phesto, Guilty Simpson, Chosen F3Ws Cold Showda, and Saafir. Available in two different versions, on black vinyl and on red vinyl.This epic collaboration between two of hip-hop's most respected legends from different sides of the country came about somewhat via chance. One afternoon Phat Kat was on the phone with long time friend and collaborator, Unjust (Hieroglyphics Imperium producer), who shared that he had been working on some tracks with iconic Hieroglyphics Crew and West Coast pioneer Casual. Kat: ''man...how ill would it be if we did a project together?'' This left the rest to Unjust and the stars began to align. Unjust handpicked some choice beats of his, sent them to Kat and Casual, and within a few short weeks this insanely powerful body of work was complete. It sounds exactly how you think it would -- relentless, urgent, mean, honest and gritty.",
                        ImageUrl = "http://www.accesshiphop.com/images/covers/26567_b.jpg",
                        UserId = author.Id,
                        Title = "Ron Bon Jovi is realisng a new album",
                        AtricleCategory = categories[0],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "A gramophone record (phonograph record in American English) or vinyl record, commonly known as a \"record\", is an analog sound storage medium in the form of a flat polyvinyl chloride (previously shellac) disc with an inscribed, modulated spiral groove. The groove usually starts near the periphery and ends near the center of the disc. Phonograph records are generally described by their diameter in inches (12\", 10\", 7\"), the rotational speed in rpm at which they are played (16 2⁄3, 33 1⁄3, 45, 78), and their time capacity resulting from a combination of those parameters(LP – long playing 33 1⁄3 rpm, SP – 78 rpm single, EP – 12 - inch single or extended play, 33 or 45 rpm); their reproductive quality or level of fidelity(high - fidelity, orthophonic, full - range, etc.), and the number of audio channels provided(mono, stereo, quad, etc.).",
                        ImageUrl = "http://www.thevinylfactory.com/wp-content/uploads/2013/05/gramophone-diagram21.png",
                        UserId = author.Id,
                        Title = "Gramophone record History",
                        AtricleCategory = categories[1],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "The invention of the 33 1/3 long-playing record had its beginnings in the invention of the 78-rpm shellac disc. During the early part of the twentieth century, recording companies struggled to get beyond the three and four minute playing barriers that had been in place since the phonograph’s inception. In the 1920s, the Big Three laboratories (Columbia, Edison, and Victor) extended the playing time to seven or eight minutes, while Western Electric managed to push the limit to ten minutes in order to match the length of reel films. The sound quality was not as good on these longer-playing discs as it was on the shorter-playing discs and so nothing beyond that was produced in the 1930s..",
                        ImageUrl = "http://www.edc-presswerk.de/fileadmin/_processed_/csm_Grammophone_ddc3501963.jpg",
                        UserId = author.Id,
                        Title = "The Invention of vinyl",
                        AtricleCategory = categories[1],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "Carl Cox (born 29 July 1962, Barbados) is a British house, techno, DJ and producer. In the 1980s Cox was a hardcore/rave DJ, and eventually became a mainstay DJ in the electronica industry. He performed at numerous clubs and also served as a monthly DJ for BBC Radio One's Essential Mix. Cox formed two record labels and now performs on his own stage yearly at various music festivals. He was voted the No. 1 Rave DJ in 1992 and No. 1 DJ in the World in 1996 and 1997 by DJ Magazine. He is an eleven time DJ Awards winner, three time International Dance Music Awards winner and an NME Award winning artist. He is currently ranked the No. 1 Global Techno and Techno House DJ by the DJ List.",
                        ImageUrl = "http://zone1.ibizaspotlightsl.netdna-cdn.com/sites/default/files/article-images/97537/coupon-1403713372.jpg",
                        UserId = author.Id,
                        Title = "Carl Cox Profile",
                        AtricleCategory = categories[3],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "Eric San (born 1974), who records under the name Kid Koala, is a Canadian DJ, turntablist, musician and an author of graphic novels. He is signed to the British record label Ninja Tune, is a member of alternative hip hop supergroup Deltron 3030, and The Slew with Dynamite D and former members of the Australian rock band Wolfmother, bassist and keyboardist Chris Ross and drummer Myles Heskett. He has also made appearances with many other artists from Amon Tobin to the Preservation Hall Jazz Band and has made contributions to Lovage, Peeping Tom, Gorillaz and numerous other projects.",
                        ImageUrl = "http://www.thisiscabaret.com/wp-content/uploads/2012/10/kidkoala-koalasuit-liveatninjatunexxlondon-by_emmagutteridge.jpg",
                        UserId = author.Id,
                        Title = "A real DJ Guru",
                        AtricleCategory = categories[3],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "Ant is a hip hop producer whose full name is Anthony Davis. He is best known as being one half of the hip hop group Atmosphere, but has worked with many other artists and projects, mostly with Rhymesayers Entertainment, such as Brother Ali, I Self Devine, Felt and The Dynospectrum. He has also released two solo albums, Melodies and Memories, and Melodies and Memories 85–89.Ant started to become interested in DJing at a very young age. He would watch his father DJ in the army while he would picture himself as Grandmaster Flash. Years later he would start to use producing and DJing as much more than a hobby. The first CD that he worked on was Comparison by Beyond, later known by Sab the Artist, in 1996. While producing that album, he met Sean Daley (Slug) and they later worked togethe.",
                        ImageUrl = "http://images.publicradio.org/content/2011/04/15/20110415_atmosphere2_33.jpg",
                        UserId = author.Id,
                        Title = "Mineapolis Golden Boy",
                        AtricleCategory = categories[3],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "Military manoeuvres come no more complicated. Merely considering a 'top secret' review involving a panel of seven or so listeners is to court disaster, as 'secrets' and 'journalists' are mutually incompatible. But we knew, as the only British hi-fi magazine surviving from 1972, that it was down to us to mark a momentous occasion: 25 years of the controversial, notorious Linn Sondek LP12. Linn, we knew, would be celebrating with the gorgeous, highly desirable, limited-edition LP12 bearing suitable anniversary cosmetics gracing our front cover. We, on the other hand, decided to ring in the changes by gauging the LP12's entire evolution in one searing, never-before-performed comparison test.",
                        ImageUrl = "http://cdn.stereophile.com/images/1007linn143389.jpg",
                        UserId = author.Id,
                        Title = "Linn LP12 Turntable Reviewed",
                        AtricleCategory = categories[4],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "We've played B&W's 684s for comparative purposes plenty of times since they comfortably retained their five-star status in a Group Test back in November 2008. This, however, is their first major test since then. But this is the company whose PV1 subwoofer has won six What Hi-Fi? Sound and Vision Awards on the spin, so we shouldn't be startled by the longevity of some B&W products. Can they retain their favoured status?Visually, they remain quite dramatic – bug-eyed yellow drivers, asymmetrical tweeter arrangement and soft-touch front baffle – but the overall standard of finish is nothing special.",
                        ImageUrl = "http://www.minhembio.com/bilder/bild/?pic_id=302735.jpg",
                        UserId = author.Id,
                        Title = "Big in size and sound, the 684s Speakers",
                        AtricleCategory = categories[4],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "If you cranked up the volume (through difficult loudspeakers) and played some challenging music, then the amplifier would show signs of discomfort. So, for listeners who preferred a smooth hi-fi type presentation, the NAIT with its warts-and-all honesty was never going to be a front-runner.Now there is a much improved replacement for the NAIT 5i: the NAIT 5i, with an italic 'i ' as opposed to the mark one version (hardly the most attention grabbing change of nomenclature). The exterior is equally undemonstrative, with the addition of a tiny, auto-switching input socket on the fascia for connecting an iPod or MP3 player.",
                        ImageUrl = "http://www.hificorner.co.uk/media/catalog/product/cache/1/image/800x800/9df78eab33525d08d6e5fb8d27136e95/c/d/cd5si_-_creative_image_single_black.jpg",
                        UserId = author.Id,
                        Title = "Naim NAIT 5i review",
                        AtricleCategory = categories[4],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "The Sundance Film Festival, a program of the Sundance Institute, is an American film festival that takes place annually in Utah. With 46,731 attendees in 2012, it is the largest independent film festival in the United States.[1] Held in January in Park City, Salt Lake City, and Ogden, as well as at the Sundance Resort, the festival is a showcase for new work from American and international independent filmmakers. The festival comprises competitive sections for American and international dramatic and documentary films, both feature-length films and short films, and a group of out-of-competition sections, including NEXT, New Frontier, Spotlight, and Park City At Midnight. The 2016 Sundance Film Festival took place January 21 to January 31, 2016.",
                        ImageUrl = "https://screencraft.org/wp-content/uploads/2016/01/2016-Sundance.jpg",
                        UserId = author.Id,
                        Title = "Sundance Film Festival",
                        AtricleCategory = categories[5],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                     new Article() {
                        Contetnt = "On a Saturday in March, medical marijuana patients and advocates celebrate the legalization movement at the annual Smokeout Festival. Held each year at the NOS Events Center in San Bernardino, the Smokeout Festival features a massive expo, live music on three stages, and the chance for medical marijuana patients to legally smoke out at a festival.With an expo featuring the latest hemp products and vendors offering everything from legal advice to art, there’s something for potheads of all sorts at the Smokeout Festival. Past featured performers include Sublime with Rome, Korn, Cypress Hill, Thievery Corporation, and Low End Theory.",
                        ImageUrl = "http://cdn.snowboarding.transworld.net/files/2010/10/img_9668.jpg",
                        UserId = author.Id,
                        Title = "Event? Smoke Out Festival",
                        AtricleCategory = categories[5],
                        PostedOn = DateTime.Now.AddDays(Rand.Next(-8, 0))}
                };                

                foreach (var item in articles)
                {
                    context.Articles.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
