using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListViewStability
{
    public class DataTemplateModel
    {

        public string Name { get; set; }
        public string Contact { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }

        public static List<DataTemplateModel> GetData()
        {
            List<DataTemplateModel> ListTemplateData = new List<DataTemplateModel>() { };
            ListTemplateData.Add(new DataTemplateModel { Name = "Nancy", Contact = "(206) 555-985774", Id = "1", Image = "https://ej2.syncfusion.com/demos/src/grid/images/1.png", Category = "Experience" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Janet", Contact = "(206) 555-3412", Id = "2", Image = "https://ej2.syncfusion.com/demos/src/grid/images/3.png", Category = "Fresher" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Margaret", Contact = "(206) 555-8122", Id = "4", Image = "https://ej2.syncfusion.com/demos/src/grid/images/4.png", Category = "Experience" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Andrew ", Contact = "(206) 555-9482", Id = "5", Image = "https://ej2.syncfusion.com/demos/src/grid/images/2.png", Category = "Experience" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Steven", Contact = "(71) 555-4848", Id = "6", Image = "https://ej2.syncfusion.com/demos/src/grid/images/5.png", Category = "Fresher" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Michael", Contact = "(71) 555-7773", Id = "7", Image = "https://ej2.syncfusion.com/demos/src/grid/images/6.png", Category = "Experience" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Robert", Contact = "(71) 555-5598", Id = "8", Image = "https://ej2.syncfusion.com/demos/src/grid/images/7.png", Category = "Fresher" });
            ListTemplateData.Add(new DataTemplateModel { Name = "Laura", Contact = "(206) 555-1189", Id = "9", Image = "https://ej2.syncfusion.com/demos/src/grid/images/8.png", Category = "Experience" });

            return ListTemplateData;
        }
    }
    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public List<DataModel> Child { get; set; }
        public static List<DataModel> GetData()
        {
            List<DataModel> ListData = new List<DataModel>() { };
            ListData.Add(new DataModel
            { Id = "01", Text = "Music", Icon = "folder", Child = new List<DataModel>() { new DataModel { Id = "01-01", Text = "Gouttes.mp3", Icon = "file" } } });
            ListData.Add(new DataModel
            {
                Id = "02",
                Text = "Videos",
                Icon = "folder",
                Child = new List<DataModel>
                () {
        new DataModel { Id= "02-01", Text= "Naturals.mp4", Icon= "file" },
        new DataModel { Id= "02-02", Text= "Wild.mpeg", Icon= "file" },
        }
            });
            ListData.Add(new DataModel
            {
                Id = "03",
                Text = "Documents",
                Icon = "folder",
                Child = new List<DataModel>
                () {
            new DataModel { Id= "03-01", Text= "Environment Pollution.docx", Icon= "file" },
            new DataModel { Id= "03-02", Text= "Global Water, Sanitation, & Hygiene.docx", Icon= "file" },
            new DataModel { Id= "03-03", Text= "Global Warming.ppt", Icon= "file" },
            new DataModel { Id= "03-04", Text= "Social Network.pdf", Icon= "file" },
            new DataModel { Id= "03-05", Text= "Youth Empowerment.pdf", Icon= "file" }
            }
            });
            ListData.Add(
            new DataModel
            {
                Id = "04",
                Text = "Pictures",
                Icon = "folder",
                Child = new List<DataModel>
                () {
                new DataModel { Id= "04-01", Text= "Camera Roll", Icon= "folder", Child= new List<DataModel>
                    () {
                    new DataModel { Id= "04-01-01", Text= "WIN_20160726_094117.JPG", Icon= "file" },
                    new DataModel { Id= "04-01-02", Text= "WIN_20160726_094118.JPG", Icon= "file" },
                    new DataModel { Id= "04-01-03", Text= "WIN_20160726_094119.JPG", Icon= "file" } }
                    },
                    new  DataModel { Id= "04-02", Text= "Wind.jpg", Icon= "file" },
                    new DataModel { Id= "04-02", Text= "Stone.jpg", Icon= "file" },
                    new  DataModel { Id= "04-02", Text= "Home.jpg", Icon= "file" },
                    new DataModel { Id= "04-02", Text= "Bridge.png", Icon= "file" } }
            });
            ListData.Add(
            new DataModel
            {
                Id = "05",
                Text = "Downloads",
                Icon = "folder",
                Child = new List<DataModel>
                () {
                        new DataModel { Id= "05-01", Text= "UI-Guide.pdf", Icon= "file" },
                        new DataModel { Id= "05-02", Text= "Tutorials.zip", Icon= "file" },
                        new DataModel { Id= "05-03", Text= "Game.exe", Icon= "file" },
                        new DataModel { Id= "05-04", Text= "TypeScript.7z", Icon= "file" }, }
            });
            return ListData;
        }
        public static List<DataModel> GetVirtualData()
        {
            List<DataModel> ListDataVirtual = new List<DataModel>() { };
            ListDataVirtual.Add(new DataModel
            {
                Text = "Nancy",
                Id = "0",
                Icon = "file"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Andrew",
                Id = "1",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Janet",
                Id = "2",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Margaret",
                Id = "3",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Steven",
                Id = "4",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Laura",
                Id = "5",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Robert",
                Id = "6",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Michael",
                Id = "7",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Albert",
                Id = "8",
                Icon = "folder"
            });
            ListDataVirtual.Add(new DataModel
            {
                Text = "Nolan",
                Id = "9",
                Icon = "folder"
            });

            for (int i = 10; i < 1000; i++)
            {
                int index = new Random().Next(0, 10);
                ListDataVirtual.Add(new DataModel
                {
                    Text = ListDataVirtual[index].GetType().GetProperty("Text").GetValue(ListDataVirtual[index], null).ToString(),
                    Id = i.ToString(),
                    Icon = ListDataVirtual[index].GetType().GetProperty("Icon").GetValue(ListDataVirtual[index], null).ToString()
                });
            }
            return ListDataVirtual;
        }

    }

    public class simpleDataModel
    {
        public string Text { get; set; }
        public string Id { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }

        public static simpleDataModel[] GetSimpleData()
        {
            simpleDataModel[] Data = new simpleDataModel[]    {
        new simpleDataModel { Text = "One", Id = "list-01", Icon = "folder", Type = "Odd"},
        new simpleDataModel { Text = "Two", Id = "list-02", Type = "Even", Icon = "folder" },
        new simpleDataModel { Text = "Three", Id = "list-03", Type = "Odd" },
        new simpleDataModel { Text = "Four", Id = "list-04", Type = "Even" },
        new simpleDataModel { Text = "Five", Id = "list-05", Type = "Odd" },
        new simpleDataModel { Text = "Six", Id = "list-06", Type = "Even"}

};
            return Data;
        }

    }

}
