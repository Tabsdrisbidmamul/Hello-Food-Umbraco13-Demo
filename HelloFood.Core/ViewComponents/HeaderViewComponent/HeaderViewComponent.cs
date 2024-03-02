using HelloFood.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;


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

            if (settings == null) return View();

            if (!settings.HasProperty("headerLinks")) return View();

            var links = settings.Value<IEnumerable<Link>>("headerLinks");

            return View(new HeaderViewComponentModel
            {
                Title = links?.FirstOrDefault()?.Name
            });
        }
    }
}
