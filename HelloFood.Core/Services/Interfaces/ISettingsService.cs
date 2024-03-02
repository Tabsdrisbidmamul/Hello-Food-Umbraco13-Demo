using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;


namespace HelloFood.Core.Services.Interfaces
{
    public interface ISettingsService
    {
        IPublishedContent? GetSettings();
    }
}
