
#include <iostream>
#include <string.h>
using namespace std;
#define SEARCHSIZE 8
#include <vector>
#include<math.h>

/*
This function recursively checks the letter above it to see if it matches up with the next letter of the word it is trying to find. 
It then returns a boolean of whether or not to word was found.
@param integer x is the x coordinate of the two dimensional array that is being checked
@param integer y is the y coordinate of the two dimensional array that is being checked
@param character array is the two dimensional array that has the word search grid
@param integer num is the index of the letter the function is currently trying to find
@param character pointer word points to the beginning of the character array that is the word it is trying to find
*/
bool up(int x, int y, char** array, char examplearray[][8], int num, char* word) {
   
    if(num>strlen(word)-1){
        return true;
    }
    if(array != NULL && x < 0 || x >sqrt(sizeof(array)/sizeof(char)+1)-1 || y < 0 || y >sqrt(sizeof(array)/sizeof(char)+1)-1){
        return false;
    }
    else if (examplearray != NULL && x < 0 || x >SEARCHSIZE-1 || y < 0 || y >SEARCHSIZE-1) {
        return false;
    }
    if (array != NULL && array[x][y] == word[num]) {
        up(x - 1, y, array, NULL, num + 1, word);
    }
    else if (examplearray!=NULL && examplearray[x][y] == word[num]){
        up(x - 1, y, NULL, examplearray, num + 1, word);
    }
    else {
        return false;
    }
}
/*
This function recursively checks the letter below it to see if it matches up with the next letter of the word it is trying to find. 
It then returns a boolean of whether or not to word was found.
@param integer x is the x coordinate of the two dimensional array that is being checked
@param integer y is the y coordinate of the two dimensional array that is being checked
@param character array is the two dimensional array that has the word search grid
@param integer num is the index of the letter the function is currently trying to find
@param character pointer word points to the beginning of the character array that is the word it is trying to find
*/
bool down(int x, int y, char** array, char examplearray[][8], int num, char* word) {
    if (num > strlen(word) - 1) {
        return true;
    }
    if(array != NULL && x < 0 || x >sqrt(sizeof(array)/sizeof(char)+1)-1 || y < 0 || y >sqrt(sizeof(array)/sizeof(char)+1)-1){
        return false;
    }
    else if (examplearray != NULL && x < 0 || x >SEARCHSIZE-1 || y < 0 || y >SEARCHSIZE-1) {
        return false;
    }
    
    if (array != NULL && array[x][y] == word[num]) {
        down(x + 1, y, array, NULL, num + 1, word);
    }
    else if (examplearray!=NULL && examplearray[x][y] == word[num]){
        down(x + 1, y, NULL, examplearray, num + 1, word);
    }
    else {
        return false;
    }
}
/*
This function recursively checks the letter to the left of it to see if it matches up with the next letter of the word it is trying to find.
It then returns a boolean of whether or not to word was found.
@param integer x is the x coordinate of the two dimensional array that is being checked
@param integer y is the y coordinate of the two dimensional array that is being checked
@param character array is the two dimensional array that has the word search grid
@param integer num is the index of the letter the function is currently trying to find
@param character pointer word points to the beginning of the character array that is the word it is trying to find
*/
bool left(int x, int y, char** array, char examplearray[][8], int num, char* word) {
    if (num > strlen(word) - 1) {
        return true;
    }
    if(array != NULL && x < 0 || x >sqrt(sizeof(array)/sizeof(char)+1)-1 || y < 0 || y >sqrt(sizeof(array)/sizeof(char)+1)-1){
        return false;
    }
    else if (examplearray != NULL && x < 0 || x >SEARCHSIZE-1 || y < 0 || y >SEARCHSIZE-1) {
        return false;
    }
    if (array != NULL && array[x][y] == word[num]) {
        left(x, y - 1, array, NULL, num + 1, word);
    }
    else if (examplearray!=NULL && examplearray[x][y] == word[num]){
        left(x, y-1, NULL, examplearray, num + 1, word);
    }
    else {
        return false;
    }
}
/*
This function recursively  checks the letter to the right of it to see if it matches up with the next letter of the word it is trying to find. 
It then returns a boolean of whether or not to word was found. 
@param integer x is the x coordinate of the two dimensional array that is being checked
@param integer y is the y coordinate of the two dimensional array that is being checked
@param character array is the two dimensional array that has the word search grid
@param integer num is the index of the letter the function is currently trying to find
@param character pointer word points to the beginning of the character array that is the word it is trying to find
*/
bool right(int x, int y, char** array, char examplearray[][8], int num, char* word) {
    if (num > strlen(word) - 1) {
        return true;
    }
    if(array != NULL && (x < 0 || x >sqrt(sizeof(array)/sizeof(char)+1)-1 || y < 0 || y >sqrt(sizeof(array)/sizeof(char)+1)-1)){
        return false;
    }
    else if (examplearray != NULL && x < 0 || x >SEARCHSIZE-1 || y < 0 || y >SEARCHSIZE-1) {
        return false;
    }
    if (array != NULL && array[x][y] == word[num]) {
        right(x, y + 1, array, NULL, num + 1, word);
    }
    else if (examplearray!=NULL && examplearray[x][y] == word[num]){
        right(x, y +1, NULL, examplearray, num + 1, word);
    }
    else {
        return false;
    }
}
/*
This function looks for the first letter of the word and then calls all of the functions above to check whether or not the rest of the word is there. 
Then it prints whether or not the word was found and how to find the word. 
@param character pointer word points to the beginning of the character array that is the word it is trying to find
@param character array is the two dimensional array that has the word search grid
*/
void printAnswer(int endi, int endj, bool up1, bool down1, bool left1, bool right1, char* word){
    if(up1){
        cout << "The word starts at (" << endj << ", " << endi << ") (where the top left letter is 0, 0) \n" << "Then go up " << strlen(word)-1 << " spaces";
    }
    if(down1){
        cout << "The word starts at (" << endj << ", " << endi << ") (where the top left letter is 0, 0) \n" << "Then go down " << strlen(word)-1 << " spaces";
    }
    if(left1){
        cout << "The word starts at (" << endj << ", " << endi << ") (where the top left letter is 0, 0) \n" << "Then go left " << strlen(word)-1 << " spaces";
    }
    if(right1){
        cout << "The word starts at (" << endj << ", " << endi << ") (where the top left letter is 0, 0) \n" << "Then go right " << strlen(word)-1 << " spaces";
    }
    
}

void opening(bool beginning, char** WordSearchPuzzle);
void WordSearch(char* word, char** array, char examplearray[][8]) {
    bool up1 = false;
    bool down1 = false;
    bool left1 = false;
    bool right1 = false;
    int size;
    if(array != NULL) size = sqrt(sizeof(array)/sizeof(char)+1);
    else if (examplearray != NULL) size = SEARCHSIZE;
    for (int j = 0; j < size-1; j++) {
        for (int i = 0; i < size-1; i++) {
            int endi;
            int endj;
            if (array != NULL && array[i][j] == word[0]) {
                endi = i;
                endj = j;
                up1 = up(i - 1, j, array, NULL, 1, word);
                down1 = down(i + 1, j, array, NULL, 1, word);
                left1 = left(i, j - 1, array, NULL, 1, word);
                right1 = right(i, j + 1, array,NULL, 1, word);
            }
            else if(examplearray != NULL && examplearray[i][j] == word[0]){
               endi = i;
                endj = j;
                up1 = up(i - 1, j, NULL, examplearray, 1, word);
                down1 = down(i + 1, j, NULL, examplearray, 1, word);
                left1 = left(i, j - 1, NULL, examplearray, 1, word);
                right1 = right(i, j + 1, NULL, examplearray, 1, word); 
            }
            if (up1 || down1 || left1 || right1) {
                printf("Word found!\n");
                printAnswer(endj, endi, up1, down1, left1, right1, word);
                if(array != NULL){
                    opening(false, array);
                }
                else if(examplearray != NULL){
                    opening(false, NULL);
                }
            }
            
        }
    }

    printf("\nWord not found :(");
    if(array != NULL){
        opening(false, array);
    }
    else if(examplearray != NULL){
        opening(false, NULL);
    }
}

void opening(bool beginning, char** WordSearchPuzzle){

    char word[256];
    char WordSearchExample[SEARCHSIZE][SEARCHSIZE] = { {'s', 'j', 'c', 'a', 'm', 'p', 'm', 'c'},
                                                       {'w', 'g', 'l', 'a', 'm', 'c', 'h', 'm'},
                                                       {'i', 'j', 'm', 'm', 'p', 'y', 'y', 'z'},
                                                       {'m', 'v', 'k', 'b', 'e', 'a', 'c', 'h'},
                                                       {'s', 'u', 'm', 'm', 'e', 'r', 'm', 's'},
                                                       {'m', 'h', 'o', 't', 'e', 'b', 'h', 'u'},
                                                       {'k', 'o', 'i', 'g', 'u', 'f', 'u', 'n'},
                                                       {'w', 'a', 't', 'e', 'r', 'o', 'q', 'e'}};
    
    if(beginning){
        int input;
        cout << "Welcome to the Word Search calculator!\nPlease input the number of your answer\n 1.Use example puzzle\n 2.Input your own puzzle\n";
        cin >> input;
        if(input == 1){
            cout<< "Here is your example puzzle:\n";
           for (int i = 0; i < SEARCHSIZE; i++) {
                for (int x = 0; x < SEARCHSIZE; x++) {
                    cout << WordSearchExample[i][x] << ", ";
                }
            cout << "\n";
            } 
            cout << "What word would you like to find?\n";
            cin >> word;
            WordSearch(word, NULL, WordSearchExample);
            
        }
        else if (input == 2){
            int size;
            cout << "Please input the dimension of your word search (ony one number, must be a square)\n";
            cin >> size;
            char** WordSearchPuzzle = (char**)malloc(sizeof(char*) * size);
            for (int i = 0; i < size; i++) {
                WordSearchPuzzle[i] = (char*)malloc(sizeof(char) * size);
            }
            cout << "Type in all of the letters in your word search with an enter after each one\n";
            for(int i = 0; i<size; i++){
                for(int j =0; j<size; j++){
                    cin >> WordSearchPuzzle[i][j];
                }
            }
            cout << "Here is your puzzle:\n";
            for(int i = 0; i<size; i++){
                for(int j =0; j<size; j++){
                    cout << WordSearchPuzzle[i][j] << ", ";
                }
                cout << "\n";
            }
            cout << "What word would you like to find?\n";
            cin >> word;
            WordSearch(word, WordSearchPuzzle, NULL);
             
        }
        else{
            cout << "That is not a viable answer, please try again!\n\n";
            opening(true, NULL);
        }
    }
    else if(WordSearchPuzzle != NULL){
        cout << "\n\nWhat word would you like to find?\n";
        cin >> word;
        WordSearch(word, WordSearchPuzzle, NULL);
    }
    else{
        cout << "\n\nWhat word would you like to find?\n";
        cin >> word;
        WordSearch(word, NULL, WordSearchExample);
    }
    
    
   
}
/*
This is a search program that finds a user inputed word in a word search problem and tells the user where to find that word. 
*/
int main() {
    
    
   opening(true, NULL);  
}