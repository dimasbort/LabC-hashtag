#ifdef DINLIB_EXPORTS
#define DINLIB_API __declspec(dllexport)
#else
#define DINLIB_API __declspec(dllimport)
#endif


extern "C" DINLIB_API int __stdcall Sum(int a, int b);

extern "C" DINLIB_API int __stdcall Diff(int a, int b);

extern "C" DINLIB_API int __stdcall Composition(int a, int b);


extern "C" DINLIB_API int __stdcall Division(int a, int b);