namespace VinylC.Services.Web
{
    using Ganss.XSS;
    using VinylC.Services.Web.Contracts;

    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}
