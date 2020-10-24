// ConsoleApplication5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stdio.h>

using namespace std;

typedef unsigned int int32;
typedef unsigned short int16;
typedef unsigned char int8;

struct RGB {
    int8 b;
    int8 g;
    int8 r;
};

struct BMP{
    //ASSUME DEPTH IS ALWAYS 24 bits/pixel
    int32 width;
    int32 height;
    RGB* pixels; // array of RGBs 

};

void write32(int32 x, FILE*h) {fwrite(&x, 4, 1, h);}
void write16(int16 x, FILE* h) {fwrite(&x, 2, 1, h);}
void write8(int8 x, FILE* h) {fwrite(&x, 1, 1, h);}

void write(const char* fileName, BMP img) {
    int padding = (4 - (img.width * 3) % 4) % 4;

    //HEADER
    FILE* h = fopen(fileName, "wb");
    const char* BM = "BM";
    write8('B', h);
    write8('M', h);
    write32(14+40+ img.height * (img.width + padding), h); // CHANGE SIZE LATER
    write32(0, h);
    write32(14 + 40, h);

    //BITMAP INFOHEADER
    write32(40, h);
    write32(img.width, h);
    write32(img.height, h);
    write16(1, h);
    write16(24, h);//DEPTH
    write32(0, h); // NO COMPRESSION
    write32(0, h); // RAW BITMAP DATA SIZE PADDING INCLUDED
    write32(0, h);
    write32(0, h);
    write32(0, h);
    write32(0, h);

    //PIXEL ARRAY
    for (int r = img.height-1; r >= 0; r--) {
        for ( int c = 0; c < img.width; c++) {
            RGB pixel = img.pixels[c + r * img.width];
            fwrite(&pixel, sizeof(RGB), 1, h);
        }
        for (int p = 0; p < padding; p++) {
            write32(0, h);
        }
    }
    fclose(h);
}

int32 read32From(int offset, FILE* h) {
    int32 result;
    fseek(h, offset, SEEK_SET); 
    fread(&result, 4, 1, h);
    return result;
}
int8 read8From(int offset, FILE* h) {
    int8 result;
    fseek(h, offset, SEEK_SET);
    fread(&result, 1, 1, h);
    return result;
}

const int WIDTH_OFFSET = 18;
const int HEIGHT_OFFSET = 22;
const int DATA_OFFSET_OFFSET = 10;

/*BMP read(const char* fileName){
    BMP img;
    FILE* h = fopen(fileName, "rb");
    img.width = read32From(WIDTH_OFFSET, h);
    img.height = read32From(HEIGHT_OFFSET, h);
    int32 dataoffset = read32From(DATA_OFFSET_OFFSET, h);

    img.pixels = new RGB[img.width * img.height];
    int padding = (4 - (img.width * 3) % 4) % 4;
    for (int r = 0; r < img.height; r++) {
        for (int c = 0; c < img.width; c++) {

            int r_ = img.height - 1 - r;
            int c_ = c;
            int offset = dataoffset + 3 * (c_ + r_ * (img.width + padding));
            img.pixels[c + r * img.width].b = read8From(offset, h);
            img.pixels[c + r * img.width].g = read8From(offset + 1, h);
            img.pixels[c + r * img.width].r = read8From(offset + 2, h);
        }
    }
    fclose(h);
    return img;
}*/
BMP read(const char* fileName) {
    BMP img;
    FILE* h = fopen(fileName, "rb");
    img.width = read32From(WIDTH_OFFSET, h);
    img.height = read32From(HEIGHT_OFFSET, h);
    int32 dataOffset = read32From(DATA_OFFSET_OFFSET, h);

    img.pixels = new RGB[img.width * img.height];
    int padding = (4 - (img.width * 3) % 4) % 4;
    for (int r = 0; r < img.height; r++) {
        for (int c = 0; c < img.width; c++) {
            // extract pixel as [r, c]
            // put it in the img.data [r, c]
            // r = 0 -> img.height - 1
            // r = img.heigth - 1 -> 0
            // img.data[c + r * img.width];
            int r_ = img.height - 1 - r;
            int c_ = c;
            int offset = dataOffset + 3 * (c_ + r_ * (img.width + padding));
            img.pixels[c + r * img.width].b = read8From(offset, h);
            img.pixels[c + r * img.width].g = read8From(offset + 1, h);
            img.pixels[c + r * img.width].r = read8From(offset + 2, h);
        }
    }
    fclose(h);
    return img;
}

int8 randByte() { return rand() % 256; }

RGB randomRGB() { return  RGB { randByte(), randByte(), randByte() };}

void addNoise(BMP img) {
    for (int r = 0; r < img.height; r++) {
        for (int c = 0; c < img.width; c++) {
            img.pixels[c + r * img.width] = randomRGB();
        }
    }
}

int main()
{
    /*BMP img;
    img.width = 100;
    img.height = 100;
    img.pixels = new RGB[100 * 100];
    for (int i = 0; i < 100 * 100; i++) {
        img.pixels[i].r = 255;
        img.pixels[i].b = 0;
        img.pixels[i].g = 0;
    }
    write("red.bmp", img);*/
   
    BMP img = read("mazda.bmp");
    addNoise(img);
    write("newMazda.bmp", img);
    delete[] img.pixels;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
