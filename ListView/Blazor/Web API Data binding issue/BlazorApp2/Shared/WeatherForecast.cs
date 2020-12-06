using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Shared
{
   
    public class WeatherForecast
    {
        public static List<WeatherForecast> order = new List<WeatherForecast>();
        public static List<WeatherForecast> order1 = new List<WeatherForecast>();
        public WeatherForecast()
        {

        }
        public WeatherForecast(int Id, string Name, List<WeatherForecast> Child)
        {
            this.Id = Id;
            this.Name = Name;
            this.Child = Child;
        }
        public static List<WeatherForecast> GetAllRecords()
        {
            if (order.Count == 0)
            {
                order1.Add(new WeatherForecast(6, "Child", null));
                order.Add(new WeatherForecast(1, "Africa" ,order1 ));
                order.Add(new WeatherForecast(2, "Asia", order1));
                order.Add(new WeatherForecast(3, "Europe", null));
                order.Add(new WeatherForecast(4, "India", null));
                order.Add(new WeatherForecast(5, "Italy", null));
                order.Add(new WeatherForecast(6, "China", null));
            }
            return order;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<WeatherForecast> Child { get; set; }

    }
    }


