#include <iostream>

int main()
{
//Task 1
printf("Task 1\n");
int n = 4;
int m = 3;
int k = 3;

int*** arr = (int***)malloc(sizeof(int**) * n);
int idx= 1;
for (int i = 0; i < n; i++) {
 arr[i] = (int**)malloc(sizeof(int*) * m);
 for (int x = 0; x < m; x++) {
  arr[i][x] = (int*)malloc(sizeof(int) * k * k);
  for (int j = 0; j < k * k; j++) {
   arr[i][x][j] = idx;
   printf("%02d ", arr[i][x][j]);
  }
  idx++;
 }
}

printf("\n\n\n");
//Task 2
printf("Task 2\n");
for (int i = 0; i < n; i++) {
 for(int num = 0; num<k; num++){
  for (int j = 0; j < m; j++) {
   for (int y = 0; y < k; y++) {
    printf("%02d ", arr[i][j][y]);
   }
   printf("  ");
  }
  printf("\n");
 }
 printf("\n\n");
}

//Task 3
printf("\n\n\n");
printf("Task 3\n");
for (int i = 0; i < n/2; i++) {
 for (int j = 0; j < m; j++) {
 
  int** temp2 = arr[i];
  arr[i] = arr[n - 1 - i];
  arr[n - 1 - i] = temp2;

 
 }
}
for (int i = 0; i < n; i++) {
 for (int j = 0; j < m / 2; j++) {
  int* temp = arr[i][j];
  arr[i][j] = arr[i][m - 1 - j];
  arr[i][m - 1 - j] = temp;


 }
}
for (int i = 0; i < n; i++) {
 for (int j = 0; j < m; j++) {
  for (int y = 0; y < k*k; y++) {
   printf("%02d ", arr[i][j][y]);
  }
  printf("  ");
 }
 printf("\n");
}
}
