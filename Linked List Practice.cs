#include "pch.h"
#include <iostream>
#define MAX_LEN 100
using namespace std;

struct Friend {
char name[MAX_LEN];
Friend *next;
Friend *prev;

Friend(char inputname[MAX_LEN], Friend *innext, Friend *inprev) {
next = innext;
prev = inprev;
strcpy(name, inputname);
}
};

Friend *head = NULL;
Friend *tail = NULL;

void addtotail(char name[MAX_LEN]) {
if (head == NULL) {
head = new Friend(name, NULL, NULL);
tail = head;
}
else {
Friend *newfriend = new Friend(name, NULL, tail);
tail->next = newfriend;
tail = newfriend;
}
printf("added %s to tail\n", name);
}

void printallfriends() {
Friend* current = head;
while (current != NULL) {
printf("%s, ", current->name);
current = current->next;
} 
printf("\n\n");


}

bool printnextfriend(){
if (head == NULL) {
return false;
}
else {
Friend *temphead = head;
printf("%s has been taken off the list\n\n", temphead->name);
head = temphead ->next;
delete temphead;
return true;
}
}


int main()
{
   //get names
printf("Enter names: \n");
char friend_name[MAX_LEN];

while (cin.getline(friend_name, MAX_LEN)) {
if (friend_name[0] == '\0') {
break;
}
else {
addtotail(friend_name);
}
}

printallfriends();

int answer = 0;
while (answer != 3) {
printf("would you like to take the first friend off the list? \n 1. yes \n 2.no\n 3.exit\n");
scanf("%d", &answer);

if (answer == 1) {
printnextfriend();
printf("your new list is: ");
printallfriends();
}
else {
printf("ok");
}
}

}
