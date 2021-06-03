using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTA
{
    class Graph
    {
        List<Vertex> V = new List<Vertex>();
        List<Edge> E = new();
        public int VertexCount => V.Count;
        public int EdgeCount => E.Count;
        public void AddVertex(Vertex vertex)
        {
            V.Add(vertex);
        }
        public void AddEdge(Vertex from, Vertex to, int weight, int road)
        {
            var edge = new Edge(from, to, weight, road);
            E.Add(edge);
        }
        public int[,] GetMatrix()
        {
            var matrix = new int[V.Count, V.Count];
            foreach (var edge in E)
            {
                int row = edge.From.Number - 1;
                int column = edge.To.Number - 1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }
        public int[,] GetMatrixByRoad()
        {
            var matrix = new int[V.Count, V.Count];
            foreach (var edge in E)
            {
                int row = edge.From.Number - 1;
                int column = edge.To.Number - 1;

                matrix[row, column] = edge.Road;
            }

            return matrix;
        }
        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();
            foreach (var edge in E)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }
        public bool BFS(Vertex v1, Vertex v2, bool stop)
        {

            var list = new List<Vertex>();
            list.Add(v1);
            for (int i = 0; i < list.Count; i++)
            {
                if (stop && list[i] == v2) break;
                var vertex = list[i];
                foreach (var v in GetVertexList(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
                Console.Write(list[i] + "->");
            }
            Console.Write("END");
            return list.Contains(v2);
        }
        public void SortByLongitude()
        {
            var result = V.OrderBy(x => x.Longitude);
            foreach(var v in result)
            {
                Console.WriteLine(v + " " + v.Longitude);
            }
        }
        public void SortByPopulation()
        {
            var result = V.OrderByDescending(x => x.Population);
            foreach(var v in result)
            {
                Console.WriteLine(v + " " + v.Population);
            }
        }
        private static readonly int NO_PARENT = -1;
        public void dijkstra(int[,] adjacencyMatrix, int startVertex)
        {
            int nVertices = adjacencyMatrix.GetLength(0);

            int[] shortestDistances = new int[nVertices];

            bool[] added = new bool[nVertices];

            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            shortestDistances[startVertex] = 0;

            int[] parents = new int[nVertices];

            parents[startVertex] = NO_PARENT;

            for (int i = 1; i < nVertices; i++)
            {
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    if (!added[vertexIndex] && shortestDistances[vertexIndex] < shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                added[nearestVertex] = true;

                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0 && ((shortestDistance + edgeDistance) < shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance + edgeDistance;
                    }
                }
            }
            printSolution(startVertex, shortestDistances, parents);
        }
      
        private void printSolution(int startVertex, int[] distances, int[] parents)
        {            
            int nVertices = distances.Length;
            Console.Write("{0,-12}{1,29}{2,19}\n", "Vertex", "Distance", "Path");

            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                if (vertexIndex != startVertex)
                {
                    Console.Write("\n" + V[startVertex] + " -> ");
                    Console.Write("{0, -20 }", V[vertexIndex]);
                    Console.Write("{0, -10}", distances[vertexIndex]);
                    printPath(vertexIndex, parents);
                    Console.Write("END");
                }
            }
        }
        private void printPath(int currentVertex, int[] parents)
        {
            if (currentVertex == NO_PARENT)
            {               
                return;
            }
            printPath(parents[currentVertex], parents);
            Console.Write(V[currentVertex] + "->");
        }
    }
}
