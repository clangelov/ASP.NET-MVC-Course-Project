namespace VinylC.Web.MVC.Infrastructure.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute() : base(typeof(DateTime), DateTime.UtcNow.ToString(), DateTime.Now.AddYears(2).ToString())
        { }
    }
}