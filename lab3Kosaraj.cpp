#include <iostream>
#include <list>
#include <stack>
#include <limits>
 
using namespace std;
 
template <typename T>
T input(const string& prompt = "");
 
class Graph
{
    int V;
    list<int> *adj;
 
    void SCCUtil(int u, int disc[], int low[],
                 stack<int> *st, bool stackMember[]);
public:
    explicit Graph(int V);
    void addEdge(int v, int w);
    void SCC();
};
 
Graph::Graph(int V)
{
    this->V = V;
    adj = new list<int>[V];
}
 
void Graph::addEdge(int v, int w)
{
    adj[v].push_back(w);
}
 
void Graph::SCCUtil(int u, int disc[], int low[], stack<int> *st,
                    bool stackMember[])
{
    static int time = 0;
 
    disc[u] = low[u] = ++time;
    st->push(u);
    stackMember[u] = true;
 
    list<int>::iterator i;
    for (i = adj[u].begin(); i != adj[u].end(); ++i)
    {
        int v = *i;
 
        if (disc[v] == -1)
        {
            SCCUtil(v, disc, low, st, stackMember);
            low[u] = min(low[u], low[v]);
        }
 
        else if (stackMember[v])
            low[u] = min(low[u], disc[v]);
    }
 
    int w;
    if (low[u] == disc[u])
    {
        while (st->top() != u)
        {
            w = (int) st->top();
            cout << w+1 << " ";
            stackMember[w] = false;
            st->pop();
        }
        w = (int) st->top();
        cout << w+1 << "\n";
        stackMember[w] = false;
        st->pop();
    }
}
 
void Graph::SCC()
{
    int *disc = new int[V];
    int *low = new int[V];
    bool *stackMember = new bool[V];
    auto *st = new stack<int>();
 
    for (int i = 0; i < V; i++)
    {
        disc[i] = -1;
        low[i] = -1;
        stackMember[i] = false;
    }
 
    for (int i = 0; i < V; i++)
        if (disc[i] == -1)
            SCCUtil(i, disc, low, st, stackMember);
}
 
int main()
{
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
    graph.SCC();
 
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
 
