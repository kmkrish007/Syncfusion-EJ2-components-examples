using System;

namespace WebApplication1.ViewModels
{
    public class DashLayoutViewModel
    {
        public DashLayoutViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public DashLayoutPositionViewModel Position
        {
            get;
            set;
        }

        public DashLayoutSizeViewModel Size
        {
            get;
            set;
        }

        public string Value { get; set; }
    }
}