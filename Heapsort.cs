#include <iostream>
#include <time.h>
using namespace std;

void heapifyTD(int* arr, int start, int end) {
int left = (start * 2) + 1;
int right = (start * 2) + 2;
if (left <= end && arr[start] < arr[left] || right <= end && arr[start] < arr[right]) {
if (right <= end && arr[left] < arr[right]) {
swap(arr[start], arr[right]);
heapifyTD(arr, right, end);
}
else if (left <= end) {
swap(arr[start], arr[left]);
heapifyTD(arr, left, end);
}
}
}
void heapifyBU(int* arr, int start, int end) {
while (end != start) {
if (arr[end] > arr[(end - 1) / 2]) {
swap(arr[end], arr[(end - 1) / 2]);
}
end = (end - 1) / 2;
}
}
void heapsort(int* arr, int size) {
//make original max heap: keep adding more from array and running heapify on it
for (int i = 1; i < size; i++) {
heapifyBU(arr, 0, i);
}
printf("max heap array:");
for (int i = 0; i < size; i++) {
printf("%d, ", arr[i]);
}
printf("\n\n");
//swap
for (int i = size - 1; i > 0; i--) {
swap(arr[0], arr[i]);
for (int i = 0; i < size; i++) {
printf("%d, ", arr[i]);
}
printf("\n");
heapifyTD(arr, 0, i - 1);
for (int i = 0; i < size; i++) {
printf("%d, ", arr[i]);
}
printf("\n\n");
}

}
int main()
{
srand(time(NULL));
int size = 5;
int* arr = new int[size];
for (int i = 0; i < size; i++) {
arr[i] = rand() % 10;
}
printf("original array:");
for (int i = 0; i < size; i++) {
printf("%d, ", arr[i]);
}
printf("\n");

heapsort(arr, size);

for (int i = 0; i < size; i++) {
printf("%d, ", arr[i]);
}
}
//relationship from parent to child: left:2n+1; Right:2n+2
  //relationship from child to parent: left:(k-1)/2, Rigth:(k-2)/