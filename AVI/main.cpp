#include <bits/stdc++.h>
#include "structs.h"

using namespace std;

Node *append(Node *head, Chunk *value) {
    Node *node = new Node();
    node->value = value;
    node->next = nullptr;

    if (head == nullptr) return node;
    Node *cur = head;
    while (cur->next != nullptr) cur = cur->next;
    cur->next = node;
    return head;
}

void appendChild(Chunk *parent, Chunk *child) {
    parent->children = append(parent->children, child);
    child->parent = parent;
}

Chunk *createRiff(const FourCC name) {
    Chunk *riff = new Chunk();
    memcpy(riff->name, name, 4);
    return riff;
}

Chunk *createList(const FourCC name, Chunk *parent) {
    Chunk *self = new Chunk();
    memcpy(self->name, name, 4);
    appendChild(parent, self);
    return self;
}

void createLeaf(const FourCC name, Chunk *parent, int4 size, const void *data) {
    Chunk *self = new Chunk();
    memcpy(self->name, name, 4);
    self->size = size;
    self->data = new ubyte[size];
    memcpy(self->data, data, size);
    appendChild(parent, self);
}

bool isLeaf(Chunk *chunk) { return chunk->children == nullptr; }
bool isRiff(Chunk *chunk) { return chunk->parent   == nullptr; }

int4 calcSize(Chunk *chunk) {
    if (isLeaf(chunk)) return 8 + chunk->size + (chunk->size % 2);
    int4 sum = 12;
    for (Node *kid = chunk->children; kid != nullptr; kid = kid->next)
        sum += calcSize(kid->value);
    return sum;
}

void write(Chunk *chunk, FILE *fd) {
    if (isLeaf(chunk)) {
        fwrite(chunk->name, 1, 4, fd);
        fwrite(&chunk->size, 4, 1, fd);
        fwrite(chunk->data, chunk->size, 1, fd);
        if (chunk->size % 2 == 1) fwrite("\0", 1, 1, fd);
    } else {
        fwrite(isRiff(chunk) ? "RIFF" : "LIST", 1, 4, fd);
        int4 size = calcSize(chunk) - 8;
        fwrite(&size, 4, 1, fd);
        fwrite(chunk->name, 1, 4, fd);
        for (Node *kid = chunk->children; kid != nullptr; kid = kid->next)
            write(kid->value, fd);
    }
}

const int fps = 25, width = 160, height = 100, cnt = 100;
const int frameSize = width * height * sizeof(RGB);
typedef RGB Picture[height][width];

AVIIndexEntry *genIndex() {
    int offset = 4;
    AVIIndexEntry *idx = new AVIIndexEntry[cnt];
    for (int i = 0; i < cnt; i++) {
        memcpy(idx[i].ckID, "00dc", 4);
        idx[i].dwFlags = 0x10;
        idx[i].dwChunkOffset = offset;
        idx[i].dwChunkLength = frameSize;
        offset += 8 + frameSize;
    }
    return idx;
}

ubyte randByte() {
    return rand() % 256;
}

void setBackground(Picture img, RGB color) {
    for (int r = 0; r < height; r++) {
        for (int c = 0; c < width; c++) {
            img[r][c] = color;
        }
    }
}

void addRectangle(Picture img, int r, int c, int h, int w, RGB color) {
    for (int i = r; i < r + h && i < height; i++) {
        for (int j = c; j < c + w && j < width; j++) {
            img[i][j] = color;
        }
    }
}

AVIMainHeader amh;
AVIStreamHeader ash;
BitmapInfoHeader bih;

int main() {
    Chunk *root = createRiff("AVI ");
    Chunk *hdrl = createList("hdrl", root);

    amh.dwTotalFrames = cnt;
    amh.dwStreams = 1;
    amh.dwWidth = width;
    amh.dwHeight = height;

    createLeaf("avih", hdrl, sizeof(amh), &amh);
    Chunk *strl = createList("strl", hdrl);

    memcpy(ash.fccType, "vids", 4);
    ash.dwScale = 1;
    ash.dwRate = fps;

    createLeaf("strh", strl, sizeof(ash), &ash);

    bih.biSize = sizeof(bih);
    bih.biWidth = width;
    bih.biHeight = height;
    bih.biPlanes = 1;
    bih.biBitCount = 24;

    createLeaf("strf", strl, sizeof(bih), &bih);
    Chunk *movi = createList("movi", root);

    Picture picture;

    for (int i = 0; i < cnt; i++) {
        // BEGIN GENERATE IMAGE
        setBackground(picture, RGB{128, 0, 0});
        addRectangle(picture, 0 + i, 50, 20, 20, RGB{0, 0, 255});
        addCircle(picture, 50, 50, 10, color);
        addRing(picture, 50, 50, 10, 20, color);
        // END GENERATE IMAGE
        
        Picture bmp;
        for (int r = 0; r < height; r++) {
            for (int c = 0; c < width; c++) {
                bmp[height - 1 - r][c] = picture[r][c];
            }
        }
        createLeaf("00dc", movi, sizeof(Picture), bmp);
    }

    createLeaf("idx1", root, cnt * sizeof(AVIIndexEntry), genIndex());

    FILE *fd = fopen("example.avi", "wb");
    write(root, fd);
    fclose(fd);

    return 0;
}
