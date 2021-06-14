using System;

namespace BlazorApp1.Shared
{
    public interface IMainSideBarMobileHandler
    {
        event EventHandler<bool> OnToggledChanged;

        void Toggled();
    }

    public class MainSideBarMobileHandler : IMainSideBarMobileHandler
    {
        private bool isSidebarToggled = false;

        public event EventHandler<bool> OnToggledChanged;

        public void Toggled()
        {
            this.isSidebarToggled = !this.isSidebarToggled;
            if (this.OnToggledChanged != null)
            {
                OnToggledChanged(this, this.isSidebarToggled);
            }
        }
    }
}
