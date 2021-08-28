// gcc -shared unmanaged.c -o unmanaged.dll
//
// See also:
//   https://renenyffenegger.ch/notes/development/languages/C-Sharp/call-dll/index
//

#include <windows.h>

__declspec(dllexport) int StrA(const char*    txt_in, char*    txt_out) {
    MessageBoxA(0, txt_in, "StrA", 0);
    strcpy(txt_out, "This text was copied from StrA");
    return 42;
}

__declspec(dllexport) int StrW(const wchar_t* txt_in, wchar_t* txt_out) {
    MessageBoxW(0, txt_in, L"StrW", 0);
    wcscpy(txt_out, L"This text was assigned in StrW");
    return 99;
}

__declspec(dllexport) void PtrDWord(DWORD* num) {
    char buf[20];
    _itoa(*num, buf, 10);
    MessageBoxA(0, buf, "PtrDWord", 0);
    *num = 42;
}
