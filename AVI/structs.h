typedef unsigned int int4;
typedef unsigned char ubyte;
typedef char FourCC[4];
typedef int4 DWORD;
typedef DWORD LONG;
typedef unsigned short WORD;

struct Chunk;
struct Node {
    Chunk* value;
    Node *next;
};

struct Chunk {
    FourCC name;
    Chunk *parent;
    int4 size;
    ubyte *data;
    Node *children;
};

struct AVIMainHeader {
    DWORD  dwMicroSecPerFrame;
    DWORD  dwMaxubytesPerSec;
    DWORD  dwPaddingGranularity;
    DWORD  dwFlags;
    DWORD  dwTotalFrames;
    DWORD  dwInitialFrames;
    DWORD  dwStreams;
    DWORD  dwSuggestedBufferSize;
    DWORD  dwWidth;
    DWORD  dwHeight;
    DWORD  dwReserved[4];
};

struct AVIStreamHeader {
    FourCC fccType;
    FourCC fccHandler;
    DWORD  dwFlags;
    WORD   wPriority;
    WORD   wLanguage;
    DWORD  dwInitialFrames;
    DWORD  dwScale;
    DWORD  dwRate;
    DWORD  dwStart;
    DWORD  dwLength;
    DWORD  dwSuggestedBufferSize;
    DWORD  dwQuality;
    DWORD  dwSampleSize;
    struct {
        WORD left;
        WORD top;
        WORD right;
        WORD bottom;
    }  rcFrame;
};

struct BitmapInfoHeader {
    DWORD biSize;
    LONG  biWidth;
    LONG  biHeight;
    WORD  biPlanes;
    WORD  biBitCount;
    FourCC biCompression;
    DWORD biSizeImage;
    LONG  biXPelsPerMeter;
    LONG  biYPelsPerMeter;
    DWORD biClrUsed;
    DWORD biClrImportant;
};

struct AVIIndexEntry {
    FourCC ckID;
    DWORD dwFlags;
    DWORD dwChunkOffset;
    DWORD dwChunkLength;
};

struct RGB {
    ubyte b;
    ubyte g;
    ubyte r;
};
