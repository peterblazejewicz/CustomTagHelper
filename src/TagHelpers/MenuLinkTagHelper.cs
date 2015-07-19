
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTagHelper.TagHelpers
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [TargetElement("menulink", Attributes = "controller-name, action-name, menu-text")]
    public class MenuLinkTagHelper : TagHelper
    {

        public MenuLinkTagHelper(IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
        }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string MenuText { get; set; }

        public IUrlHelper urlHelper { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder sb = new StringBuilder();
            string menuUrl = urlHelper.Action(ActionName, ControllerName);
            output.TagName = "a";
            output.Attributes.Add("href", $"{menuUrl}");
            output.Content.SetContent(MenuText);
            var routeData = ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];
            if (String.Equals(ActionName, currentAction as string, StringComparison.OrdinalIgnoreCase)
                  && String.Equals(ControllerName, currentController as string, StringComparison.OrdinalIgnoreCase))
            {
                output.Attributes.Add("class", "mdl-navigation__link is-active");
            }
            else
            {
                output.Attributes.Add("class", "mdl-navigation__link");
            }
        }
    }
}