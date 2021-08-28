// gcc -shared unmanaged.c -o unmanaged.dll
//
// See also:
//   https://renenyffenegger.ch/notes/development/languages/C-Sharp/call-dll/index
//

#include <windows.h>

__declspec(dllexport) int StrA(char* txt) {
    MessageBoxA(0, txt, "StrA", 0);
    return 42;
}

__declspec(dllexport) int StrW(wchar_t* txt) {
    MessageBoxW(0, txt, L"StrW", 0);
    return 99;
}

__declspec(dllexport) void PtrDWord(DWORD* num) {
    char buf[20];
    _itoa(*num, buf, 10);
    MessageBoxA(0, buf, "PtrDWord", 0);
    *num = 42;
}
