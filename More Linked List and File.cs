#include "pch.h"
#include <iostream>

struct node {
int val;
node *pnext;
};

void addnode(node *p, node **pphead) {
if (*pphead == nullptr) {
*pphead = p;
}
else {
node *pstart = *pphead;
while (pstart->pnext) {
pstart = pstart->pnext;
}
pstart->pnext = p;
}
}

int main()
{
node *phead = nullptr;
for (int i = 0; i < 100; i++) {
node *p = (node *)malloc(sizeof(node));
p->val = rand() % 100;
p->pnext = nullptr;
addnode( p, &phead);
}
node a2;
a2.val = 2;
a2.pnext = nullptr;

node a1;
a1.val = 1;
a1.pnext = &a2;

node a0;
a0.val = 0;
a0.pnext = &a1;

node *phead = &a0;

node *pstart = phead; 

while(pstart) {
printf("%d, ", pstart->val);
pstart = pstart->pnext; 
}

const char *str = "my string";
FILE*f = fopen("myfile.txt", "wb");
int len = strlen(str);
fwrite(&len, sizeof(len), 1, f);
fwrite(str, len, 1, f);
fclose(f);


}
