#include <iostream>

int main()
{
/*for (int i = 0; i < n; i++) {
 for (int j = 0; j < n; j++) {
  if (i == 0 || i == n - 1 || j == 0 || j == n - 1) {
   a[(i * n) + j] = 1;
  }
  else {
   a[(i * n) + j] = 0;
  }

  if (i == 20 && j == 50) {
   int tt = 0;
  }
 }
}

for (int i = 0; i < n; i++) {
 for (int j = 0; j < n; j++) {
  printf("%d", a[(i * n) + j]);
 }
 printf("\n");
}*/

int n = 50;
int m = 5;
int* a = (int*)malloc(n * n*sizeof(int));
int idx = 0;

for (int i = 0; i < n/m; i++) {
 for (int j = 0; j < n/m; j++) {

  for (int k = 0; k < m; k++) {
   for (int x = 0; x < m; x++) {
    a[(((i*m)*n) + (j*m)) + ((k*n) + x)] = idx;
   
   }
  }
  idx++;
 }
}
for (int i = 0; i < n; i++) {
 for (int j = 0; j < n; j++) {
  printf("%02d", a[(i * n) + j]);
 }
 printf("\n");
}

}
