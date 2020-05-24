using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithMaps.Modelo
{
  
    public class PropertyType
    {
        public string TypeName { get; set; }
        public string Name { get; set; }
    }

    public class Property
    {
        public string Id { get; set; }
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
