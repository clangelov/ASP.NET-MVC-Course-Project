﻿namespace VinylC.Services.Web.Contracts
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
