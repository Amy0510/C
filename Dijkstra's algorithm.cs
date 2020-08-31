#include <iostream>
#include <vector>
#include <algorithm>
#define INF (1<<30)
#define v vector
#define len matrix.size



using namespace std;


void find(vector<vector<int>> matrix) {
vector<int> shortest(len, INF);
shortest[0] = 0;
vector<int> used(len, 0);
int cnt = 0;

while (cnt < 5) {
//find smallest distance node
int snodeind = -1;
for (int i = 0; i < len; i++) {
if (used[i]) continue;
if ((snodeind == -1) ||(shortest[i] <= shortest[snodeind])) snodeind = i;
}

//find smallest direct paths
for (int i = 0; i < len; i++) {
if (matrix[snodeind][i] != -1) shortest[i] = min(shortest[i], shortest[snodeind] + matrix[snodeind][i]);
}

//delete node
used[snodeind] = 1;

//repeat
cnt = 0;
for (int i = 0; i < len; i++) {
if (used[i] == 1) cnt++;
}

}
for (int i = 0; i < len; i++) {
printf("%d, ", shortest[i]);
}

}

int main(){

/*for (int i = 0; i < x; i++) {
vector<int> a;
for (int j = 0; j < x; j++) {
scanf_s("%d", &num);
a.push_back(num);
}
matrix.push_back(a);
}*/
//adjacency matrix
vector<vector<int>> matrix = { {-1,-1,4,-1,-1},
{7,-1,-1,-1,-1},
{-1,3,-1,1,-1},
{-1,-1,-1,-1,-1},
{-1,-1,-1,8,-1} };

find(matrix);

}

