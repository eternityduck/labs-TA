//by WADIM https://github.com/devule
#include <iostream>
#include <list>
#include <stack>
#include <limits>
 
using namespace std;
 
template <typename T>
T input(const string& prompt = "");
 
class Graph {
    int V;
    list<int> *adj;
 
    void fillOrder(int v, bool visited[], stack<int> &Stack);
 
    void DFSUtil(int v, bool visited[]);
 
public:
    explicit Graph(int V);
 
    void addEdge(int v, int w);
 
    void printSCCs();
 
    Graph getTranspose();
};
 
Graph::Graph(int V) {
    this->V = V;
    adj = new list<int>[V];
}
 
void Graph::DFSUtil(int v, bool visited[]) {
    visited[v] = true;
    cout << v + 1 << " ";
 
    list<int>::iterator i;
    for (i = adj[v].begin(); i != adj[v].end(); ++i)
        if (!visited[*i])
            DFSUtil(*i, visited);
}
 
Graph Graph::getTranspose() {
    Graph g(V);
    for (int v = 0; v < V; v++) {
        list<int>::iterator i;
        for (i = adj[v].begin(); i != adj[v].end(); ++i) {
            g.adj[*i].push_back(v);
        }
    }
    return g;
}
 
void Graph::addEdge(int v, int w) {
    adj[v].push_back(w);
}
 
void Graph::fillOrder(int v, bool visited[], stack<int> &Stack) {
    visited[v] = true;
 
    list<int>::iterator i;
    for (i = adj[v].begin(); i != adj[v].end(); ++i)
        if (!visited[*i])
            fillOrder(*i, visited, Stack);
 
    Stack.push(v);
}
 
void Graph::printSCCs() {
    stack<int> Stack;
 
    bool *visited = new bool[V];
    for (int i = 0; i < V; i++)
        visited[i] = false;
 
    for (int i = 0; i < V; i++)
        if (!visited[i])
            fillOrder(i, visited, Stack);
 
    Graph gr = getTranspose();
 
    for (int i = 0; i < V; i++)
        visited[i] = false;
 
    while (!Stack.empty()) {
        int v = Stack.top();
        Stack.pop();
 
        if (!visited[v]) {
            gr.DFSUtil(v, visited);
            cout << endl;
        }
    }
}
 
int main() {
    int vertices, links;
    do vertices = input<int>("Кількість вершин графа (> 1): ");
    while(vertices < 2);
    do links = input<int>("Кількість зв'язків між вершинами (>= 1): ");
    while(links < 2);
 
    Graph graph(vertices);
 
    for(int i = 0; i < links; i++) {
        int from, to;
        cout << "Зв'язок " << i+1 << ":" << endl;
        do from = input<int>("Від вершини (>= 1): ");
        while(from < 1);
        do to = input<int>("До вершини (>= 1): ");
        while(to < 1 || to == from);
 
        graph.addEdge(--from, --to);
        cout << endl;
    }
 
    cout << endl << "Результат роботи алгоритму:" << endl << endl;
    graph.printSCCs();
 
    return 0;
}
 
template <typename T>
T input(const string& prompt) {
    if(!prompt.empty()) cout << prompt;
    T value;
 
    while(!(cin >> value)) {
        cout << "Введіть коректне значення: ";
 
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
 
    return value;
}
