#include <iostream>

void fractal(int i, int j, int size, int arr[64][64]) {

bool br = false;
for (int x = i; x < i + size; x++) {
 for (int y = j; y < j + size; y++) {
  if (arr[x][y] == 0) {
   arr[x][y] = 1;
  }
  else if (arr[x][y] == 1) {
   br = true;
  }
 
 }
 if (br == true) {
  break;
 }
}
size /= 2;

if (arr[i - size][j - size] == 0) {
 fractal(i - size, j - size, size, arr);
}
if (arr[i + size *2][j + size *2] == 0) {
 fractal(i + size * 2, j + size * 2, size, arr);
}
if (arr[i + size*2][j - size] == 0) {
 fractal(i + size * 2, j - size, size, arr);
}
if (arr[i - size][j + size*2] == 0) {
 fractal(i - size, j + size * 2, size, arr);
}






}
int main()
{
int arr[64][64] = {};
fractal(24, 24, 16, arr);

 for (int x = 0; x < 64; x++) {
  printf("\n");
  for (int y = 0; y < 64; y++) {
   printf("%d", arr[x][y]);
  }
 }

}