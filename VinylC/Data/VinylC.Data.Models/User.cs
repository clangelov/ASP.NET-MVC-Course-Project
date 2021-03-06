﻿namespace VinylC.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Article> atricles;
        private ICollection<Comment> comments;
        private ICollection<Product> products;
        private ICollection<Rating> ratings;

        public User()
        {
            this.atricles = new HashSet<Article>();
            this.comments = new HashSet<Comment>();
            this.products = new HashSet<Product>();
            this.ratings = new HashSet<Rating>();
        }

        [RegularExpression(ModelConstants.ValidateUrl)]
        public string Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;             
        }

        public virtual ICollection<Article> Articles
        {
            get { return this.atricles; }
            set { this.atricles = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
