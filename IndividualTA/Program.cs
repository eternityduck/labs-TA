using System;
using System.Threading;
using System.Threading.Tasks;
namespace IndividualTA
{
    class Program
    {

        static void Main(string[] args)
        {
            var graph = new Graph();

            var v1 = new Vertex(1, "Rivne", 50.6199, 26.25162, 243934);
            var v2 = new Vertex(2, "Vinnytsia", 49.2328, 28.481, 370834);
            var v3 = new Vertex(3, "Kyiv", 50.4501, 30.5234, 2884000);
            var v4 = new Vertex(4, "Nizhyn", 51.048, 31.8869, 68007);
            var v5 = new Vertex(5, "Poltava", 49.58827, 34.55142, 284942);
            var v6 = new Vertex(6, "Dnipro", 48.27, 34.58, 966400);
            var v7 = new Vertex(7, "Horlivka", 48.33576, 38.05325, 245746);
            var v8 = new Vertex(8, "Makeevka", 48.04782, 37.92576, 345685);
            var v9 = new Vertex(9, "Donetsk", 48.01588, 37.80285, 918536);
            var v10 = new Vertex(10, "Zaporizhzhia", 47.82289, 35.19031, 746749);
            var v11 = new Vertex(11, "Energodar", 47.49865, 34.6574, 53343);
            var v12 = new Vertex(12, "Nikolaev", 46.97503, 31.99458, 486267);
            var v13 = new Vertex(13, "Odessa", 46.48253, 30.72331, 993120);
            var v14 = new Vertex(14, "Kropyvnytsky", 48.5132, 32.2597, 226491);
            var v15 = new Vertex(15, "Cherkasy", 49.4285, 32.0621, 279074);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4); 
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);
            graph.AddVertex(v9);
            graph.AddVertex(v10);
            graph.AddVertex(v11);
            graph.AddVertex(v12);
            graph.AddVertex(v13);
            graph.AddVertex(v14);
            graph.AddVertex(v15);

            graph.AddEdge(v1, v2, 316, 4);
            graph.AddEdge(v1, v4, 478, 0);
            graph.AddEdge(v1, v3, 328, 0);
            graph.AddEdge(v2, v1, 316, 2);
            graph.AddEdge(v2, v3, 261, 5);
            graph.AddEdge(v2, v13, 446, 6);
            graph.AddEdge(v2, v15, 342, 7);
            graph.AddEdge(v3, v2, 261, 8);
            graph.AddEdge(v3, v1, 328, 4);
            graph.AddEdge(v3, v4, 151, 3);
            graph.AddEdge(v3, v15, 195, 7);
            graph.AddEdge(v4, v1, 478, 0);
            graph.AddEdge(v4, v3, 151, 4);
            graph.AddEdge(v4, v15, 238, 2);
            graph.AddEdge(v4, v5, 301, 3);
            graph.AddEdge(v5, v4, 301, 1);
            graph.AddEdge(v5, v15, 242, 1);
            graph.AddEdge(v5, v6, 347, 3);
            graph.AddEdge(v5, v7, 408, 5);
            graph.AddEdge(v5, v14, 248, 6);
            graph.AddEdge(v6, v5, 347, 8);
            graph.AddEdge(v6, v7, 264, 10);
            graph.AddEdge(v6, v14, 322, 3);
            graph.AddEdge(v6, v9, 261, 4);
            graph.AddEdge(v6, v11, 134, 5);
            graph.AddEdge(v7, v5, 408, 2);
            graph.AddEdge(v7, v6, 264, 1);
            graph.AddEdge(v7, v8, 40, 9);
            graph.AddEdge(v7, v9, 64, 9);
            graph.AddEdge(v8, v7, 40, 8);
            graph.AddEdge(v8, v9, 16, 9);
            graph.AddEdge(v9, v8, 16, 8);
            graph.AddEdge(v9, v7, 64, 8);
            graph.AddEdge(v9, v6, 261, 3);
            graph.AddEdge(v9, v10, 229, 4);
            graph.AddEdge(v10, v9, 229, 5);
            graph.AddEdge(v10, v11, 122, 6);
            graph.AddEdge(v10, v13, 517, 7);
            graph.AddEdge(v11, v10, 122, 6);
            graph.AddEdge(v11, v6, 134, 5);
            graph.AddEdge(v11, v14, 449, 7);
            graph.AddEdge(v11, v12, 298, 4);
            graph.AddEdge(v12, v11, 298, 5);
            graph.AddEdge(v12, v14, 181, 3);
            graph.AddEdge(v12, v13, 134, 4);
            graph.AddEdge(v13, v12, 134, 3);
            graph.AddEdge(v13, v15, 442, 5);
            graph.AddEdge(v13, v2, 446, 3);
            graph.AddEdge(v13, v10, 517, 5);
            graph.AddEdge(v14, v12, 181, 4);
            graph.AddEdge(v14, v11, 449, 5);
            graph.AddEdge(v14, v6, 322, 8);
            graph.AddEdge(v14, v5, 248, 5);
            graph.AddEdge(v14, v15, 129, 3);
            graph.AddEdge(v15, v14, 129, 5);
            graph.AddEdge(v15, v13, 442, 4);
            graph.AddEdge(v15, v5, 242, 5);
            graph.AddEdge(v15, v4, 238, 4);
            graph.AddEdge(v15, v3, 195, 4);
            graph.AddEdge(v15, v2, 342, 2);

            var matrix = graph.GetMatrix();
            var roadMatrix = graph.GetMatrixByRoad();
            for(int i = 0; i < graph.VertexCount; i++)
            {
                
                for(int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(" " + matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("_________________________________");
            Console.WriteLine();

            //GetVertex(graph, v1);
            long start = DateTime.Now.Ticks;
            graph.BFS(v3, v15, false);
            Console.WriteLine("\nTime:" + (DateTime.Now.Ticks - start));
            Console.WriteLine();
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            start = DateTime.Now.Ticks;
            graph.BFS(v3, v15, true);
            Console.WriteLine("\nTime:" + (DateTime.Now.Ticks - start));
            Console.WriteLine();
            Console.WriteLine("_________________________________");
           
            graph.dijkstra(matrix, 1);
            
            Console.WriteLine();
            Console.WriteLine("_________________________________");
            Console.WriteLine();
            
            graph.dijkstra(roadMatrix, 1);
            
            Console.WriteLine("\n");
            start = DateTime.Now.Ticks;
            graph.SortByPopulation();
            Console.WriteLine("\nTime:" + (DateTime.Now.Ticks - start));
            Console.WriteLine("\n");
            start = DateTime.Now.Ticks;
            graph.SortByLongitude();
            Console.WriteLine("\nTime:" + (DateTime.Now.Ticks - start));

        }
        static void GetVertex(Graph graph, Vertex vertex)
        {
            Console.WriteLine(vertex.Name + ": ");
            foreach (var v in graph.GetVertexList(vertex))
            {
                Console.Write(v.Name + " ");
            }
            Console.ReadLine();
        }
    }
    
}
