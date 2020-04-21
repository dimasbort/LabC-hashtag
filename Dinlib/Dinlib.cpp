#include "pch.h"
#include <math.h>
#include "Dinlib.h"

int __stdcall Sum(int a, int b) {
	return a + b;
}


int __stdcall Diff(int a, int b) {
	return a - b;
}


int __cdecl stepen(int a, int b) {
	int i = 1;
	for (int r = 1; r <= b; r++)
		i *= a;
	return i;
}

