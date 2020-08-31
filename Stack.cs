#include "pch.h"
#include <iostream>
#define MAX_LENGTH 256
enum TokenType {
TokenType_Error,
TokenType_Number,
TokenType_Operation
}; 

struct Token { 
TokenType type;
int number;
char operation;
};


Token GetNextToken(char** ppinput) {
Token ret = {}; 
char* in = *ppinput;

// skip all white-spaces
while(isspace(*in)) in++; 

if (isdigit(*in)) {
ret.type = TokenType_Number;
sscanf(in, "%d", &ret.number);
while (isdigit(*in)) in++; 
}

else if (*in == '+' || *in == '-' || *in == '*' || *in == '/' || *in == '(' || *in == ')'){ 
ret.type = TokenType_Operation; 
ret.operation = *in; 
in++; 
}

*ppinput += in - (*ppinput);

return ret;
}
int GetOperationPriority(char operation) {
     switch (operation) {
case '*':
case '/':
return 2;
case '+':
case '-':
return 1;
}
return -1;
}


int TransformInfixToPostfix(char* input, char* rpn) {
char* in = input;
char* out = rpn;
int len = strlen(input);

char stack[MAX_LENGTH];
int stack_pos = 0;

do {
Token token = GetNextToken(&in);

if (token.type == TokenType_Number) { 
int ch = sprintf(out, "%d ", token.number); 
out += ch; 
}
else if (token.type == TokenType_Operation) {
if (token.operation == ')') {
// push out all operations until open bracket
while(stack_pos){                     
char op = stack[--stack_pos];
if(op != '('){
int ch = sprintf(out, "%c ", op);
out += ch;
}                     
else {
break;
}
} 
}
else if(stack_pos && token.operation != '(' && stack[stack_pos-1] != '('){ 
// push out all operations with lower or equal priority
while(stack_pos && ( GetOperationPriority(stack[stack_pos-1]) >= GetOperationPriority(token.operation))){ 
char op = stack[--stack_pos];
if (op != '(') {
int ch = sprintf(out, "%c ", op);
out += ch; }
else                        
break; }
}

if (token.operation != ')') {
stack[stack_pos++] = token.operation;
}
}
else {
return (in - input); 
}
} while (in < input + len);

while (stack_pos) { char op = stack[--stack_pos];
if (op != '(') { 
int ch = sprintf(out, "%c ", op);
out += ch;
}
}

return -1;
}
void push(int*stack, int *stackpos, int val) {
stack[++(*stackpos)] = val;
}

char pop(int* stack, int *stackpos) {
return stack[(*stackpos)--];
}

int SolvePostfix(char* rpn) {
int n[MAX_LENGTH];
Token token;
int stack_pos = -1;
do {
token = GetNextToken(&rpn);
if (token.type == TokenType_Number) {
push(n, &stack_pos, token.number);
}
else if (token.type == TokenType_Operation) {
int op1 = pop(n, &stack_pos);
int op2 = pop(n, &stack_pos);
int res;
if (token.operation == '+') {
res = op1 + op2;
}
if (token.operation == '-') {
res = op2 - op1;
}
if (token.operation == '*') {
res = op1 * op2;
}
if (token.operation == '/') {
res = op2 / op1;
}
push(n, &stack_pos, res);
//printf("%d \n", op1);
//printf("%d \n", op2);
}
} while (token.type != TokenType_Error);
int res = n[0];
return res;


} 
int main(int argc, char* argv[]) {
char input[MAX_LENGTH];
char rpn[MAX_LENGTH];

printf("Enter your expression:\n ");
scanf("%255[^\n]s", input);

int ret = TransformInfixToPostfix(input, rpn);
if (ret != -1) {
printf("\n Error: Can't evaluate, error on %d position\n", ret);
return -1;
}

printf("\nYour expression in Reverse Polish Notation:\n %s \n\n", rpn);

int res = SolvePostfix(rpn);

printf("\n Result is: %d\n", res);
}
