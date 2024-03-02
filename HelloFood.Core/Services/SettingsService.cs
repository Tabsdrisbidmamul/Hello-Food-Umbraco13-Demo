using HelloFood.Core.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;
using System.Linq;
using HelloFood.Core.Constants;

namespace HelloFood.Core.Services
{
    public sealed class SettingsService : ISettingsService
    {
        private readonly IUmbracoContextFactory _umbracoHelper;
        
        public SettingsService(IUmbracoContextFactory umbracoHelper) 
        {
            _umbracoHelper = umbracoHelper;
        }

        public IPublishedContent? GetSettings()
        {
            using var umbracoContextReference = _umbracoHelper.EnsureUmbracoContext();

            var contentQuery = umbracoContextReference.UmbracoContext.Content;

            var siteRoot = contentQuery?.GetAtRoot().FirstOrDefault();

            var settings = siteRoot?
                .Children
                .SingleOrDefault(x => x.ContentType.Alias == ContentAliases.Nodes.SettingsNode);

            return settings;
        }


    }
}
