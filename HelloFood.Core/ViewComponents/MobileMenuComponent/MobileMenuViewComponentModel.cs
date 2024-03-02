using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace HelloFood.Core.ViewComponents.MobileMenuComponent
{
    public sealed class MobileMenuViewComponentModel
    {
        public List<Link>? Links { get; set; } = null;
        public Link? Cta { get; set; } = null;
    }
}
