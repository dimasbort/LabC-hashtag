#include "pch.h"
#include "framework.h"
#include "Dinlib.h"


int __stdcall Sum(int a, int b) {
	return a + b;
}


int __stdcall Diff(int a, int b) {
	return a - b;
}

int __stdcall Composition(int a, int b) {
	return a * b;
}

int __stdcall Division(int a, int b) {
	return a / b;
}