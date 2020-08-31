#include "pch.h"
#include <iostream>


struct computer {
int reg[10];
int mem[256];
};

void Excecute(computer *ppc, unsigned char *pprog, int len) {
int cur_pos = 0;
while(cur_pos<len) {
//parse first byte
int opcode = pprog[cur_pos] >> 4;
int optype = pprog[cur_pos++] & 0x0F;
// depending on op.code, read extra bytes and execute operation
switch (opcode) {
case 0:
case 1:
case 2:
case 3:
{
int op1 = pprog[cur_pos] >> 4;
int op2 = pprog[cur_pos++] & 0x0F;

if (opcode == 0) {
ppc->reg[optype] = ppc->reg[op1] + ppc->reg[op2];

}
else if (opcode == 1) {
ppc->reg[optype] = ppc->reg[op1] - ppc->reg[op2];
}
else if (opcode == 2) {
ppc->reg[optype] = ppc->reg[op1] * ppc->reg[op2];
}
else {
ppc->reg[optype] = ppc->reg[op1] / ppc->reg[op2];
}
}
break;

case 4:
{
int idx1 = pprog[cur_pos++];
int idx2 = pprog[cur_pos++];

if (optype == 0) {
ppc->reg[idx2] = ppc->reg[idx1];

}
else if (optype == 1) {
ppc->reg[idx2] = ppc->mem[idx1];
}
else {
ppc->mem[idx2] = ppc->reg[idx1];
}
}
break;
};
};
}

int main()
{

unsigned char prog1[] = {//move reg[0]<-- mem[0]
//[4|1] [0][0]
0x41,0x00, 0x00,
// move reg [1]<-- mem[1]  
0x41, 0x01,0x01,
// add reg[2]= reg[0]+reg[1] 
0x02, 0x01,
// mov mem[2]<-- reg[2]};
0x42, 0x02, 0x02 };

computer pc1;
pc1.mem[0] = 5;
pc1.mem[1] = 7;

Excecute(&pc1, prog1, sizeof(prog1));
printf("Result: %d", pc1.mem[2]);
}

/* op. code
0=add
1=sub
2=mul
3=div
4=mov

op.code 0-3
[op.code|dst-reg] [op1-reg] [op2-reg]

op.code 4
op.type
0 -  [src reg]{dst-reg]
1 -  [src-mem][dst-reg]
2 -  [src-reg][src-mem]
*/
