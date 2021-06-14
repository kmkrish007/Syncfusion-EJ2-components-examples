using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Navigations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public partial class MainSidebarMobile
    {
        SfSidebar sidebarObj;

        [Inject]
        public IMainSideBarMobileHandler mainSideBarMobileHandler { get; set; }

        [Parameter]
        public bool SidebarToggle { get; set; }

        [Parameter]
        public bool isChecked { get; set; }

        [Parameter]
        public bool showCheckBox { get; set; }

        [Parameter]
        public bool ListCheckBox { get; set; }

        [Parameter]
        public EventCallback<bool> SidebarToggleChanged { get; set; }


        public void Close()
        {
            SidebarToggle = false;
        }
        List<MusicAlbum> Albums = new List<MusicAlbum>();
        protected override void OnInitialized()
        {
            mainSideBarMobileHandler.OnToggledChanged += OnMainSideBarMobileHandlerToggledChanged;
            base.OnInitialized();

            Albums.Add(new MusicAlbum
            {
                Id = 1,
                Name = "Discover Music",
            });
            Albums.Add(new MusicAlbum
            {
                Id = 2,
                Name = "Hot Singles"
            });
        }

        //public void OnToggleChanged(object sender, bool e)
        //{
        //  //  this.sidebarObj.IsOpen = e;
        //    //SidebarToggle = e;
        //   // this.StateHasChanged();
        //}
        private void OnMainSideBarMobileHandlerToggledChanged(object sender, bool e)
        {
         //   SidebarToggle = e;
            this.sidebarObj.IsOpen = e;
            //isChecked = true;
            //showCheckBox = true;
            //ListCheckBox = true;
           // this.StateHasChanged();
        }

        public void Toggle()
        {
            SidebarToggle = true;
            //isChecked = true;
            //showCheckBox = true;
            //ListCheckBox = true;
        }
        public class MusicAlbum
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        }
}
