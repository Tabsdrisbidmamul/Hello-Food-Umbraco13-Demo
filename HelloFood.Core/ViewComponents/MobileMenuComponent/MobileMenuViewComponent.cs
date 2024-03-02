using HelloFood.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace HelloFood.Core.ViewComponents.MobileMenuComponent
{
    public sealed class MobileMenuViewComponent: ViewComponent
    {
        private readonly ISettingsService _settingsService;

        public MobileMenuViewComponent(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IViewComponentResult Invoke()
        {
            var settings = _settingsService.GetSettings();

            if(settings == null || !settings.HasProperty(Constants.ContentAliases.PropertyAliases.HeaderLinks)) 
            {
                return View(new MobileMenuViewComponentModel());
            }

            var headerLinks = settings.Value<IEnumerable<Link>>(Constants.ContentAliases.PropertyAliases.HeaderLinks);

            if(headerLinks == null || !headerLinks.Any()) 
            {
                return View(new MobileMenuViewComponentModel()); 
            }

            return View(new MobileMenuViewComponentModel
            {
                Links = headerLinks.ToList(),
                Cta = headerLinks.LastOrDefault()
            });
        }
    }
}
