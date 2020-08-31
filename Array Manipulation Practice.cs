#include <iostream>

void task1() {
int a[10] = { 1,2,3,4,5,6,7,8,9,10 };
int sum = 0;
for (int i = 0; i < 10; i++) {
sum += a[i];
}

printf("sum should be 55, now it is %d\n", sum);
}

void task2() {

int *a = (int*)malloc(10000000 * sizeof(int));
int *b = (int*)malloc(10000000 * sizeof(int));
for (int i = 1; i < 10000000 ; i++) {
a[i] = rand() % 11;
b[i] = rand() % 11;
}

int diff = 0;
for (int i = 0; i < 10000000; i++) {
diff += a[i] - b[i];
}

printf("Result is: %d\n", diff);
}

void task3() {
int *x = (int*)malloc(80000000*sizeof(int));
for (int i = 0; i < 80000000; i++) {
x[i] = rand() % 10;
}
int ave = 0;
for (int i = 1; i < 80000000; i++) {
ave += x[i];
}
ave = ave / 80000000;
printf("the average is %d. \n\n", ave);


int count =0;
int num = 0;

for (int i = 0; i <10; i++) {
for (int a = 0; a <  80000000; a++) {
if (x[a] == i) {
count++;
}
}
printf("the number %d appears %d times\n",num, count);
num++;
count = 0;
}

printf("\n\n");

int currnum = x[0];
int longest =0;
int current = 0;
int index = 0;

for (int i = 1; i < 80000000; i++) {
if (currnum == x[i] && currnum != x[i-2]) {
current++;
}
else if (currnum == x[i]) {
current++;
}
if (current > longest) {
longest = current;
index = i-(current-1);
}
currnum = x[i];
}

printf("The sequence starts at index: %d \n", index );
printf("The sequence is %d numbers long \n", longest);
}


void task4() {
// implementation 1:
int num = 0;
int count = 0;
printf("type your number:");
scanf("%d", &num);
for (int i = 32; i >0; i--) {
if ((num >> i) & 1) {
count++;
}
}
printf("implementation 1: %d \n", count);

//implementation 2:
int count2 = 0;
while (num)
{
count2 += num & 1;
num =num>> 1;
}
printf("implementation 2: %d \n", count2);

}


int main()
{
}
