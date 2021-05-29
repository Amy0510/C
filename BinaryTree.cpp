#include <iostream>
struct Node{
  int key;
  const char* val;
  Node* left;
  Node* right;
  Node* par;
};
Node* root;

Node* find (int key){
  Node* cur = root;
    while(cur != nullptr){
      if(key == cur->key)return cur;
      else if(key < cur->key) cur = cur->left;
      else cur = cur->right;
    }
    return nullptr;
}

const char* search(int key){
  Node* n = find(key);
  if(n == nullptr) return nullptr;
  return n->val;
}


//recursive search:
/*char* search(int key, Node* cur){
  if(cur == nullptr) return nullptr;
  if(key == cur-> key ) return cur-> val;
  else if(key < cur-> key) search(key, cur->left);
  else search(key, cur-> right);
  
}*/

void insert(int key, const char* val){
  //find the right spot
  Node* cur = root;
  Node* par = nullptr;
    while(cur != nullptr){
      if(key == cur->key){
        cur-> val = val;
        return;
      }
      par = cur;
      if(key < cur->key) cur = cur->left;
      else cur = cur->right;
    }
    //make new node
    Node* n = new Node();
    n->key = key;
    n->val = val;
    n->left = nullptr;
    n->right = nullptr;
    n-> par = par;
    //insert new node
    if(par != nullptr){
      if(key < par->key) par->left = n;
      else par->right = n;
    } else root = n;  
}

void remove(int key){
  Node* n = find(key);
  if (n->left && n-> right){
    //find succesor 
    Node* succ = n-> right;
    while(succ->left) succ = succ->left;
    //replace with succ
    n-> key = succ-> key;
    n-> val = succ->val;
    //if succ has kids, replace its spot w/ kid
    if(succ->right){
      if(succ == succ->par->right) succ->par->right = succ->right;
      else succ->par->left = succ->right;
    }
    n = succ;
  }
  else if(n-> left){
    //just replace with left child
    if(n == n->par->left) n->par->left = n->left;
    else n->par->right = n->left;
  }
  else if (n-> right){
    //just replace with right child
    if(n == n->par->left) n->par->left = n->right;
    else n->par->right = n->right;
  }
  delete n;
}

int main() {
  insert(1969, "moon landing");
  insert(1776, "Declaration of Independence");
  insert(1986, "Chernobyl Catastrophe");
  while(true){
    int year;
    scanf("%d", &year);
    printf("%s happened in %d\n", search(year), year);
  }
}