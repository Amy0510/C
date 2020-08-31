
#include <iostream>
struct node {
int data;
int age;
node *next;
};

class list {

node *head = NULL;
node *tail = NULL;

public:

void add_uninode(int num, int age ){ 
//check if list is empty
if(head==NULL){
node *t = new node;
t->data = num;
t->age = age;
t->next = NULL;
head = t;
tail = t;
}
else {
node *t = new node;
t->data = num;
t->age = age;
tail->next = t;
tail = t;
t = t->next;
}
}

void display() {
node *t = head;
while (t != NULL) 
{
printf("(data=%d ", t-> data);
printf("age=%d)", t->age);
printf(" -> ");
t = t->next;
}
}

void remove_last() {
node *t = head;
t=t->next
if (t->next->next==NULL) {

}
}
};

int main() 
{
printf("Unicorn nodes... \n");

list *l = new list;
l->add_uninode(5,2);
l->add_uninode(15,10);
l->add_uninode(-10, -1275346);

l->display();

return 0;
}