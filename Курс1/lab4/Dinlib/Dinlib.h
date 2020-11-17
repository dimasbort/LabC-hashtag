#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif

extern "C" int MATHLIBRARY_API __stdcall Sum(int a, int b);

extern "C" int MATHLIBRARY_API __stdcall Diff(int a, int b);

extern "C" int MATHLIBRARY_API __cdecl stepen(int a, int b);