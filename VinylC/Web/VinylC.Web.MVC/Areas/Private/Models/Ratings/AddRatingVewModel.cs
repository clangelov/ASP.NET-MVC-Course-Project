namespace VinylC.Web.MVC.Areas.Private.Models.Ratings
{
    using System.ComponentModel.DataAnnotations;
    using VinylC.Common.Constants;
    using VinylC.Data.Models;
    using VinylC.Web.MVC.Infrastructure.Mappings;

    public class AddRatingVewModel : IMapFrom<Rating>
    {
        public AddRatingVewModel()
        {
        }

        public AddRatingVewModel(int product, string user)
        {
            this.ProductId = product;
            this.UserId = user;
        }

        public int Id { get; set; }

        [Range(ModelConstants.MinRating, ModelConstants.MaxRating)]
        public float Value { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }
    }
}