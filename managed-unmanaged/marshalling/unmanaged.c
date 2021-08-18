// gcc -shared unmanaged.c -o unmanaged.dll
//
// See also:
//   https://renenyffenegger.ch/notes/development/languages/C-Sharp/call-dll/index
//

#include <windows.h>

__declspec(dllexport) int passStringA(char* txt) {
    MessageBoxA(0, txt, "passStringA", 0);
    return 42;
}

__declspec(dllexport) int passStringW(wchar_t* txt) {
    MessageBoxW(0, txt, L"passStringW", 0);
    return 99;
}
