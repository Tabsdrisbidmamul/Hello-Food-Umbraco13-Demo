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

            if (settings == null || !settings.HasProperty("headerLinks")) 
            { 
                return View(new HeaderViewComponentModel()); 
            }

            var links = settings.Value<IEnumerable<Link>>("headerLinks");

            if (links == null)
            {
                return View(new HeaderViewComponentModel());
            }

            return View(new HeaderViewComponentModel
            {
                Links = links.ToList()
            });
        }
    }
}
