// TerminalGraphics.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <chrono>
#include<thread>
using namespace std;
const int WIDTH = 211;
const int HEIGHT = 50;

typedef char screen[HEIGHT][WIDTH];

void display(screen s) {
    for (int r = 0; r < HEIGHT; r++) {
        for (int c = 0; c < WIDTH; c++) {
            printf("%c", s[r][c]);
        }

    }
}

void fill(screen s, char ch) {
    for (int r = 0; r < HEIGHT; r++) {
        for (int c = 0; c < WIDTH; c++) {
            s[r][c] = ch;
        }

    }
}
void sleep(int ms) {
    fflush(stdout);
    this_thread::sleep_for(chrono::milliseconds(ms));
}

const char BG = ' ';
int main()
{
    int c = WIDTH/2+1;
    int r = HEIGHT/2+1;
    screen s;
    fill(s, BG);
    s[r][c] = 'O';
    int vc = 2;
    int vr = 2;
    sleep(3000);
    display(s);
    while (true) {
        s[r][c] = BG;
        r = r + vr;
        c = c + vc;
        if (r == 0) {vr = 2; //go down
        }
        if (r == HEIGHT-2) {vr = -2; //go up
        }
        if (c == 0) {vc = 2; //go right
        }
        if (c == WIDTH - 2) {vc = -2; //go left
        }
        s[r][c] = 'O';
        display(s);
        sleep(1000);
        for (int i = 0; i < WIDTH; i++) {
            printf("-");
        }
    }
    
 
    

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
