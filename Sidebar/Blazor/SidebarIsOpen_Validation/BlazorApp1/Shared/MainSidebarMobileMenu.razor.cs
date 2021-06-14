using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Syncfusion.Blazor.Navigations;
using System.Collections.Generic;

namespace BlazorApp1.Shared
{
    public partial class MainSidebarMobileMenu
    {

        public List<MenuMobileItemDto> MainMobileMenuItems;

        protected override void OnInitialized()
        {
            this.InitMainMobileMenuItems();

            base.OnInitialized();
        }

        private void InitMainMobileMenuItems()
        {
            this.MainMobileMenuItems = new List<MenuMobileItemDto>{
                new MenuMobileItemDto {
                    Text = "Home",
                    IconCss = "fas fa-home",
                    Url = "/"
                },
                new MenuMobileItemDto {
                    Text = "Search",
                    IconCss = "fas fa-search"
                },
                new MenuMobileItemDto
                {
                    Text = "Smartlist",
                    IconCss = "fas fa-filter"
                },
                new MenuMobileItemDto
                {
                    Text = "Object",
                    IconCss = "fas fa-cube",
                    Url = "/objectitem/widgeteditor"
                },
                new MenuMobileItemDto
                {
                    Text = "Favorits",
                    IconCss = "fas fa-heart",
                    Items = new List<MenuMobileItemDto> {
                        new MenuMobileItemDto{ Text = "Favorits" },
                        new MenuMobileItemDto{ Text = "Last visited" },
                        new MenuMobileItemDto{ Text = "Most opened" }
                    }
                },
                new MenuMobileItemDto
                {
                    Text = "Workspaces",
                    IconCss = "fas fa-briefcase",
                    Items = new List<MenuMobileItemDto> {
                        new MenuMobileItemDto{ Text = "Workspace Favorit A", IconCss = "fas fa-user", Url="/workspacehome"},
                        new MenuMobileItemDto{ Text = "Workspace Favorit B" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit C" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit D" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit E" },
                        new MenuMobileItemDto{ Separator = true },
                        new MenuMobileItemDto{ Text = "AllWorkspaces", Url = "/workspaceoverview", IconCss="fas fa-briefcase" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit 1" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit 2" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit 3" },
                        new MenuMobileItemDto{ Text = "Workspace Favorit 4" },
                    }
                },
                new MenuMobileItemDto
                {
                    Text = "Counter",
                    IconCss = "fas fa-plus",
                    Url = "counter"
                },
                new MenuMobileItemDto
                {
                    Text = "Fetch Data",
                    IconCss = "fas fa-database",
                    Url = "fetchdata"
                }
            };
        }

        private void beforeOpenHandler(BeforeOpenCloseMenuEventArgs<MenuMobileItemDto> e)
        {
            if (e.ParentItem.Text == "Workspaces")
            {
                e.ScrollHeight = 500;
            }

        }
    }

    public class MenuMobileItemDto
    {
        public string Text { get; set; }
        public string IconCss { get; set; }
        public string Url { get; set; }
        public bool Separator { get; set; }
        public List<MenuMobileItemDto> Items { get; set; }
    }
}
