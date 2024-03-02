using HelloFood.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;

namespace HelloFood.Core.ViewComponents.HeaderViewComponent
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly ISettingsService _settingsService;

        public HeaderViewComponent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IViewComponentResult Invoke()
        {
            var settings = _settingsService.GetSettings();

            if (settings == null || !settings.HasProperty(Constants.ContentAliases.PropertyAliases.HeaderLinks)) 
            { 
                return View(new HeaderViewComponentModel()); 
            }

            var headerLinks = settings.Value<IEnumerable<Link>>(Constants.ContentAliases.PropertyAliases.HeaderLinks);

            if (headerLinks == null || !headerLinks.Any())
            {
                return View(new HeaderViewComponentModel());
            }

            return View(new HeaderViewComponentModel
            {
                Links = headerLinks.ToList()
            });
        }
    }
}
