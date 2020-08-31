#include "pch.h"
#include <iostream>

#pragma pack(1)

struct BITMAPFILEHEADER {
unsigned short bftype; //BM
unsigned int bfsize;//
unsigned int dwReserved;
unsigned int bOffBits;//sizeof(BFH) + sizeof(BIH)
};


struct BITMAPINFOHEADER {
unsigned int biSize;//40
int biWidth;//
int biHeight;//
unsigned short biplanes;//1
unsigned short biBitcount;//24
unsigned int biCompresion;
unsigned int biImageSize;
unsigned char bzeros[16];
};

bool makeline(int b, float m, int x, int y ) {
unsigned char R, G, B;
if (y > m*x + b) {

return true;
}
else {

return false;

}
}
void makeflag(int x, int y, FILE*f) {
unsigned char R, G, B;
//y = mx + b;


if(makeline(63,.6,x,y)) {
R = 0;
G = 0;
B = 0;
}
else if (y < .6*x + 253) {
R = 0;
G = 0;
B = 255;
}

else {
R = 255;
G = 205;
B = 0;
}

fwrite(&B, 1, 1, f);
fwrite(&G, 1, 1, f);
fwrite(&R, 1, 1, f);
}


int main()
{
FILE * f = fopen("germanflag.bmp", "wb");
BITMAPFILEHEADER bfh = { };
BITMAPINFOHEADER bih = { };

bfh.bftype = 0x4D42;
bfh.bfsize = sizeof(bfh) + sizeof(bih) + (512 * 315 * 3);
bfh.bOffBits = sizeof(bfh) + sizeof(bih);

bih.biSize = sizeof(bih);
bih.biWidth = 512;
bih.biHeight = -315;
bih.biplanes = 1;
bih.biBitcount = 24;
bih.biImageSize = 512 * 315 * 3;

fwrite(&bfh, sizeof(bfh), 1, f);
fwrite(&bih, sizeof(bih), 1, f);



for (int y = 0; y < 315; y++) {
for (int x = 0; x < 512; x++) {
makeflag(x, y, f);
}
}

fclose(f);

}

bool circle = false;
for (int x = 0; x < 315; x++) {
for (int y = 0; y < 512; y++) {
unsigned char R, G, B;
int newx = y - 256;
int newy = x - 157;
if (newx*newx + newy*newy <= 10000) {
circle = true;
}
else {
circle = false;
}

if (circle) {

R = 255;
G = 0;
B = 0;

}
else {

R = 220;
G = 220;
B = 220;

}

fwrite(&B, 1, 1, f);
fwrite(&G, 1, 1, f);
fwrite(&R, 1, 1, f);
}

}


for (int i = 0; i < 315; i++) {
for (int j = 0; j < 170; j++) {
unsigned char R, G, B;
R = 0;
G = 255;
B = 0;
fwrite(&B, 1, 1, f);
fwrite(&G, 1, 1, f);
fwrite(&R, 1, 1, f);
}
for (int j = 0; j < 170; j++) {
unsigned char R, G, B;
R = 255;
G = 255;
B = 255;
fwrite(&B, 1, 1, f);
fwrite(&G, 1, 1, f);
fwrite(&R, 1, 1, f);
}
for (int j = 0; j < 172; j++) {
unsigned char R, G, B;
R = 255;
G = 0;
B = 0;
fwrite(&B, 1, 1, f);
fwrite(&G, 1, 1, f);
fwrite(&R, 1, 1, f);
}

}


