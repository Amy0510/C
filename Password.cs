#include <iostream>

#include <time.h>

bool same(int* answer, int* password, int num) {

       for (int i = 0; i < num; i++) {

              if (answer[i] != password[i]) {

                     return false;

              }

       }

       return true;

}

void password(int num) {

       int* password = (int*)malloc(sizeof(int) * num);

       for (int i = 0; i < num; i++) {

              password[i] = rand() % 10;

              printf("%d ", password[i]);

       }

       printf("\n");

 

       int* answer = (int*)malloc(sizeof(int) * num);

       memset(answer, 0, (sizeof(int) * num));

 

       while (!(same(answer, password, num))){

              int i = 0;

              answer[i] ++;

              while (answer[i] > 9) {

                     answer[i] = 0;

                     answer[++i]++;

 

              }

             

       }

       for (int i = 0; i < num; i++) {

              printf("%d ", answer[i]);

       }

       printf("\n");

}

 

int main()

{

 

       int num = 3;

       clock_t start = clock();

       password(num);

       clock_t stop = clock();

       double duration = ((double)(stop - start)) / CLOCKS_PER_SEC;

       printf("\nTime: %d", duration);

 

}