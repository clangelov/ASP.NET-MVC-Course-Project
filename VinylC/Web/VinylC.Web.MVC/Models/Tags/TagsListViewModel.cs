namespace VinylC.Web.MVC.Models.Tags
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class TagsListViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}