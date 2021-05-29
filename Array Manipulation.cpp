

using namespace std;
#include <iostream> 
void print_2d(int nums[4][4], int rows, int columns) {
for (int i = 0; i < rows; i++) {
for (int x = 0; x < columns; x++) {
printf("%d ", nums[i][x]);
}
printf("\n");
}
}

bool exists_2d(int n[4][5], int x) {
bool correct = false;
for (int i = 0; i < 4; i++) {
for (int z = 0; z < 5; z++) {
if (n[i][x] == x
) {
correct = true;
}
}
}
printf("%d", correct);
return(correct);
}

void perimeter(int n[4][5]) {
int p = 0;
for (int i = 0; i < 4; i++) {
for (int x = 0; x < 5; x++) {
if (i == 0 || i == 3) {
p = p + n[i][x];
}
if (i == 1 && x == 0) {
p = p + n[i][x];
}
if (i == 1 && x == 4) {
p = p + n[i][x];
}
if (i == 2 && x == 0) {
p = p + n[i][x];
}
if (i == 2 && x == 4) {
p = p + n[i][x];
}

}
}
printf("%d", p);
}

void diagonal(int nums[4][4]) {
int add = 0;
for (int i = 0; i < 4; i++) {
for (int z = 0; z < 4; z++) {
if (i == z) {
add = add + nums[i][z];
}
}
}
for (int i = 0; i < 4; i++) {
add = add + nums[i][3 - i];

}
printf("%d", add);
}

void rotate(int n[4][4], int z[4][4]) {
    print_2d(n, 4, 4);
    printf("\n\n");
    
    for (int i = 0; i < 4; i++) {
    for (int x = 0; x < 4; x++) {
    z[x][3 - i] = n[i][x];
    }
    }
    print_2d(z, 4, 4);
}


int main()
{
int nums[4][4] = { {1,5,0,-1}, {-2,3,10,5}, {3,10,11,0}, {-2,-5 - 1,0} };
int z[4][4] = { {}, {}, {}, {} };

}
