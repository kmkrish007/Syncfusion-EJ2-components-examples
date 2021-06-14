using BlazorApp1.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Shared
{
    partial class ToolbarItemMainSidebarToggle
    {
        [Inject]
        public IMainSideBarMobileHandler mainSideBarMobileHandler { get; set; }

        public void Toggle()
        {
            this.mainSideBarMobileHandler.Toggled();
        }
    }
}