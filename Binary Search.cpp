
#include <iostream>
int indexof(int nums[], int x) {
    int index = -1;
    for (int i = 0; i < 5; i++) {
        if (nums[i] == x) {
            index = i;
        }
    }
    return index;
}

int binary_search(int nums[], int y, int from, int to) {
    if (from > to) {
        return -1;
    }
    int m = (from + to)/2;
    if (nums[m] == y) {
        return m;
    }
    else if (nums[m] > y) {
        return binary_search(nums, y, from, m - 1);
    }
    else if (nums[m]< y){
        return binary_search(nums, y, m+1, to);
    }
}

int search_insert_index(int nums[], int y, int from, int to) {
    if (to < y) {
        return to;
    }
    if (from > y) {
        return -1;
    }
    int m = (from + to) / 2;
    if (nums[m] < y && nums[m + 1] >= y) {
        return m;
    }
    else {
        if (nums[m] > y) {
            return search_insert_index(nums, y, from, m - 1);
        }
        else if (nums[m] < y) {
            return search_insert_index(nums, y, m + 1, to);
        }
    }
}


int main()
{
    int nums[] = {1,3,5,10,15};
    printf("%d", search_insert_index(nums,4,0,4));
}

