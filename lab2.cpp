//by WADIM https://github.com/devule
#include <iostream>
#include <vector>
#include <limits>
#include <string>
#include "Windows.h"
 
using namespace std;
 
#define INF numeric_limits<int>::max()
 
template<typename T>
T input(const string &prompt = "");
 
void dijkstra(vector<vector<int>> graph, int from) {
    const int n = graph.size();
    int distance[n], visited[n];
 
    for (int i = 0; i < n; i++) {
        distance[i] = INF;
        visited[i] = false;
    }
 
    visited[from] = true;
    distance[from] = 0;
 
    for (int i = 0; i < n - 1; i++) {
        int minIndex = 0, minValue = INF;
        for (int j = 0; j < n; j++) {
            if (!visited[j] && minValue > distance[j]) {
                minValue = distance[j];
                minIndex = j;
            }
        }
 
        visited[minIndex] = true;
 
        for (int j = 0; j < n; j++) {
            if (!visited[j] && distance[j] > distance[minIndex] + graph[minIndex][j]) {
                distance[j] = distance[minIndex] + graph[minIndex][j];
            }
        }
    }
 
    for (int i = 0; i < n; i++) {
        if(i == from) continue;
        cout << "Довжина шляху від вершини " << from + 1 << " до вершини " << i + 1 << ": " << distance[i] << endl;
    }
}
 
void floyd(vector<vector<int>> graph, int from) {
    const int n = graph.size();
    int distance[n];
 
    for (int i = 0; i < n; i++) {
        distance[i] = graph[from][i];
    }
 
    for(int k = 0; k < n; k++) {
        for(int j = 0; j < n; j++) {
            distance[j] = min(distance[j], distance[k] + graph[k][j]);
        }
    }
 
    for (int i = 0; i < n; i++) {
        if(i == from) continue;
        cout << "Довжина шляху від вершини " << from + 1 << " до вершини " << i + 1 << ": " << distance[i] << endl;
    }
}
 
int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
 
    const int n = input<int>("Введіть кількість вершин графа: ");
    vector<vector<int>> graph;
    graph.resize(n);
    for (int i = 0; i < n; i++) graph[i].resize(n);
 
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            do {
                cout << "Довжина шляху від вершини " << i + 1 << " до вершини " << j + 1 << ": ";
                graph[i][j] = graph[j][i] = input<int>("");
            } while (graph[i][j] < 1);
        }
    }
    cout << endl;
    int from = 0;
 
    while(from < 1) {
        from = input<int>("З якої вершини вести пошук? ");
    }
 
    cout << endl << "Алгоритм Дейкстри:" << endl;
    dijkstra(graph, from - 1);
 
    cout << endl << "Алгоритм Флойда Уоршела:" << endl;
    floyd(graph, from - 1);
 
    return 0;
}
 
template<typename T>
T input(const string &prompt) {
    if (!prompt.empty()) cout << prompt;
    T value;
 
    while (!(cin >> value)) {
        cout << "Введіть коректне значення: ";
 
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
 
    return value;
}
