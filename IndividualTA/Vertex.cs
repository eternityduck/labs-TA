using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTA
{
    class Vertex
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Population { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
        public Vertex(int number, string name, double latitude, double longtitude, double population)
            => (Number, Name, Latitude, Longitude, Population) = (number, name, latitude, longtitude, population);

    }
}
