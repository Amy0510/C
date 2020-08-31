#include <iostream>
#include <time.h>

void countsort(int* array, int n) {
int size[100] = {};

for (int i = 0; i < n; i++) {
 size[array[i]]++;

}
//+ N*5
int cnt = 0;// +1
for (int i = 0; i < 100; i++) {
 //100*2
 for (int x = 0; x < size[i]; x++) {
  //n* 100*2
  array[cnt] = i;
  //2
  cnt++;
  //1
 }
}
}

void bubblesort(int* array, int n) {
int count = 1;//1
__int64 op =0;//1
printf("%I64d\n", op);

while (count > 0) {
 count = 0;//1
 for (int i = 0; i < n - 1; i++) {//2*n
  if (array[i] > array[i + 1]) {//4
   int x = array[i + 1];//2
   array[i + 1] = array[i];//4
   array[i] = x; //2

   count++;//1
   op += 13;
  }
 }
 op++; //1

}

printf("%I64d\n", op);

}


int main() {
/*printf("Count Sort: \n\n");

int n = 10000;
int* a = (int*)malloc(sizeof(int) * n);
int num = n;
for (int i = 0; i < n; i++) {
 a[i] = rand() % 100;
}




clock_t start = clock();
countsort(a, n);
clock_t stop = clock();

long long cnt = (n * 5) + (1) + (100 * 2) + (n * 5);
printf("%d\n\n", cnt);

double duration = (double)(stop - start) / CLOCKS_PER_SEC;
printf("%lf \n", duration);

*/
printf("\n\n\n\n\n\n\n Bubble Sort: \n\n\n");

int n = 100000;
int* arr = (int*)malloc(sizeof(int) * n);

int num = n;
for (int i = 0; i < n; i++) {
 arr[i] = num;
 num--;
}

clock_t start = clock();
bubblesort(arr, n);
clock_t stop = clock();


double duration = (double)(stop - start) / CLOCKS_PER_SEC;
printf("%lf \n", duration);
//cnt = (13 * n) + (2 * n) + (1);
//printf("%d\n\n", cnt);

}
