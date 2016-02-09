namespace VinylC.Web.MVC.Models.Articles
{
    using System;
    using System.Web;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class ArticlesListViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Contetnt { get; set; }

        public DateTime PostedOn { get; set; }

        public User User { get; set; }

        public string ImageUrl { get; set; }
    }
}