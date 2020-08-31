#include <iostream>
void merge(int* s1, int* e2, int gs, int* out) {
int* s2 = s1 + gs;
int* e1 = s2;

do {
if (*s2 < *s1) *out++ = *s1++; // when you have ++ AT THE NED, THEN IT MoVES OVER THE INDEX, NOT THE NUMBER IT IS POINTING TO. so IT WILL MAKE THE NUMBER IT IS POINTING to = s1, and then move over the index
//(*out)++ would make the number it is pointing to ++
else *out++ = *s1++;
} while (s1 != e1 && s2 != e2);

while (s1 != e1) *out++ = *s1++;
while (s2 != e2)* out++ = *s2++;
}
void mergesort(int *a, int n) {

int* temp = (int*)malloc(sizeof(int) * n);
int* e = a + n;
for (int gs = 1; gs < n; gs*=2) {
int* out = temp;
int* s1 = 0;
int* e2 = s1 + 2 * gs;
if (e2 > e) e2 = e;

for (int cnt; cnt < (n / gs )/ 2; cnt++) {
merge(s1, e2, gs, out);
s1 += gs * 2;
e2 += gs * 2;
if (e2 > e) e2 = e;
out += gs * 2;
}

while (s1 != e)* out++ = *s1++;
memcpy(a, out, n * sizeof(int));
}
}
int main()
{
   
}