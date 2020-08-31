#include <iostream>
#include <time.h>
void countsort(int* array, int n) {
int size[100] ={};

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

int main()
{
int n = 200000000;

int* a = (int*)malloc(sizeof(int) * n);

for (int i = 0; i < n; i++) {
 a[i] = rand() % 100;

}
clock_t start = clock();
countsort(a, n);

clock_t stop = clock();
double duration = (double)(stop - start) / CLOCKS_PER_SEC;
printf("%lf \n", duration);
int cnt = (n * 5) + (1) + (100 * 2) + (n * 5);
printf("%d", cnt);
}