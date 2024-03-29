/*
	Consigna parcial:
	
		Elaborar programa para cobro de peaje:
			- Categoria auto = importe 1 (100)
			- Categoria camion = importe 2 (200)
			- El importe se paga por eje de acuerdo a la categoria del vehiculo.
			- Se debe mostrar el total a pagar y guardar en un historial.
			- Se deben poder cargar tantos cobros como se quiera hasta que se decida finalizar.
*/

#include <stdio.h>
#include <locale.h>
#include <conio.h>
#include <stdbool.h>

void clearInputBuffer() {
	while (getchar() != '\n');
}

int main() {
	float importeAuto, importeCamion, totalACobrar, importeLista, totalPeriodo = 0;;
	int tipoVehiculo, cantidadEjes, i = 0, opcionMenu;
	bool cargaEstaTerminada = false;
	
	FILE* importeAutoTxt = fopen(".\\importe1.txt", "r");
	FILE* importeCamionTxt = fopen(".\\importe2.txt", "r");
	FILE* historialTxtAppend = fopen(".\\historial.txt", "a");
	FILE* historialTxtRead = fopen(".\\historial.txt", "r");
	
	setlocale(LC_CTYPE, "Spanish");

	printf("Se inicia una nueva tanda de cobro de peajes.\n\n");
	
	// Verifica que se hayan encontrado los archivos
	if (importeAutoTxt == NULL || importeCamionTxt == NULL || historialTxtAppend == NULL || historialTxtRead == NULL) {
		printf("Uno de los archivos no se pudo abrir de manera exitosa. Se cerrar� el programa.");
		getch();
		return 1;
	}
	
	// Toma los valores de los archivos
	fscanf(importeCamionTxt,"%f", &importeCamion);
	fscanf(importeAutoTxt,"%f", &importeAuto);
	
	// Cierra la conexi�n a los archivos
	fclose(importeAutoTxt);
    fclose(importeCamionTxt);
	
	while (!cargaEstaTerminada) {
		// P�de al usuario la categor�a del veh�culo
		printf("Seleccione la categor�a correspondiente al veh�culo:\n1- Auto\n2- Cami�n\n");
		while(scanf("%d", &tipoVehiculo) != 1 || tipoVehiculo < 0 || tipoVehiculo > 2) {
			printf("El valor ingresado no es correcto, por favor ingresalo nuevamente...\n");
			clearInputBuffer();
		}
		clearInputBuffer();
		
		system("cls");
		
		// Pide al usuario la cantidad de ejes del veh�culo
		printf("Ingrese la cantidad de ejes del veh�culo:");
		while(scanf("%d", &cantidadEjes) != 1 || cantidadEjes < 0) {
			printf("El valor ingresado no es correcto, por favor ingresalo nuevamente...\n");
			clearInputBuffer();
		}
		clearInputBuffer();
		printf("%d", cantidadEjes);
		
		system("cls");
		
		// Calcula el total a cobrar de acuerdo al tipo de veh�culo
		totalACobrar = (tipoVehiculo == 1? importeAuto : importeCamion) * cantidadEjes;
		
		// Guarda el valor a cobrar en el historia y agrega un salto de l�nea
		fprintf(historialTxtAppend, "%.2f\n", totalACobrar);
		
		printf("Se cobrar�n $%.2f.\n\nPresione cualquier tecla para confirmar...\n", totalACobrar);
		getch();
		
		i++;
		
		system("cls");
		
		// Pide al usuario que elija como continuar
		printf("Se registraron %i cobros. Seleccione como continuar:\n1- Seguir cobrando\n2- Finalizar\n", i);
		while(scanf("%d", &opcionMenu) != 1 || opcionMenu < 0 || opcionMenu > 2) {
			printf("El valor ingresado no es correcto, por favor ingresalo nuevamente...\n");
			clearInputBuffer();
		}
		clearInputBuffer();
		
		system("cls");
		
		// Si el usuario elige salir se cambia la condici�n que controla el bucle
		if (opcionMenu == 2) {
			cargaEstaTerminada = true;
		}
	}
	
	fclose(historialTxtAppend); // Cierra buffer de escritura para reflejar cambio en txt
	printf("Se ha finalizado la cobranza.\n\n");
	
	// Muestra los registros de cobro almacenados
	printf("----COBROS REGISTRADOS AL CORRIENTE----\n");
	
    while(fscanf(historialTxtRead, "%f", &importeLista) == 1) {
		printf("$\t%.2f\n", importeLista);
		totalPeriodo += importeLista;
	}
	printf("---------------------TOTAL:\n$\t%.2f", totalPeriodo);
	
	fclose(historialTxtRead);
	
	return 0;
};
