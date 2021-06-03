using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTA
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }

        public int Weight { get; set; }
        public int Road { get; set; }

        public Edge(Vertex from, Vertex to, int weight, int road) => (From, To, Weight, Road) = (from, to, weight, road);

        public override string ToString()
        {
            return $"({From}; {To})";
        }

    }
}
