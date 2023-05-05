#include <stdio.h>
#include <conio.h>

// Adds support for math constants
#define _USE_MATH_DEFINES
#include <math.h>

/*
	Problema: 
		Dado un valor para el radio de un c�rculo, se debe devolver el �rea del mismo. 
	
	Algoritmo:
		- Inicio
		- Se pide a usuario que ingrese el radio del c�rculo
		- Se calcula el �rea del c�rculo como PI*r^2
		- Se muestra al usuario el valor del �rea del c�rculo
		- Fin
*/

int main() {
	
	float radius, circleArea;
	
	printf("A continuacion se permite calcular el area de un circulo a traves de su radio.\n");
	
	printf("Por favor ingresa el radio del circulo cuyo area quieras calcular en cm: \n");
	if(scanf("%f", &radius) != 1) {
		printf("Tenes que ingresar un numero! No una letra ni un simbolo...");
		
		return 1;
	}
	
	circleArea = M_PI * pow(radius,2);
	
	printf("El area del circulo cuyo radio es %.2f cm es: %.2f cm cuadrados.", radius, circleArea);
	
	getch();
	
	return 0;
}
