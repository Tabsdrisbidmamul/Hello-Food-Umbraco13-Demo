using HelloFood.Core.Services;
using HelloFood.Core.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Configuration;

namespace HelloFood.Web.Extensions
{
    public static class CustomBuilderExtensions
    {
        public static IUmbracoBuilder RegisterCustomServices(this IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<ISettingsService, SettingsService>();

            return builder;
        }

        public static IUmbracoBuilder AddCustomServices(this IUmbracoBuilder builder)
        {
            builder.RegisterCustomServices();

            return builder;
        }
    }
}
