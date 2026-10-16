# Practica\_ORM\_EFCore



Nuestro repositorio contiene la solución del sistema de inventario para "Librería y Papelería Segovia" desarrollado como una aplicacion de escritorio en Window Forms, utilizando Visual Basic y Maria DB.



###### **Requisitos**

1. Ide: Visual Studio posterior a 2022.
2. Plataforma: .NET 10.0.
3. Base de datos: MariaDB / MySQL (administrado mediante HeidiSQL)
4. Paquete NuGet: Pomelo.EntityFrameworkCore.MySql versión 9.0.0.



Para la configuracion de la base de datos:

1. Abrir la carpeta 'database/' del repositorio y localizar el archivo 'libreria\_segovia.sql' .
2. Ejecutar todo el script en HeidiSQL para crear la base de datos con sus tablas.
3. Abrir el archivo de codigo en 'src/InventarioORM/ConexionBD.vb' y agregar tu usuario y contraseña reales de tu servidor local.



###### **Pasos para la ejecucion**

1. Abre el archivo de la solucion 'InventarioORM.sln' en Visual Studio.
2. Restaura los paquetes NuGet en caso de ser necesario.
3. Dale play para compilar y ejecutar.

