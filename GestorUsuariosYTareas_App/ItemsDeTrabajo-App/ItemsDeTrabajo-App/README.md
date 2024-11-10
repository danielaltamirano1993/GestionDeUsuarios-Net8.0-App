Plan de Acci�n Actualizado
Tecnolog�as:

Usaremos .NET Core 3.1 o superior (o .NET 6/7/8 si te resulta c�modo y compatible con Visual Studio 2022).
C�digo en C#.
Estructura del Proyecto:

Crearemos dos soluciones:
Microservicio de �tems de Trabajo.
Microservicio de Gesti�n de Usuarios.

Cada microservicio tendr� una arquitectura de 3 capas:
Capa de Datos (Data Access Layer o DAL): Aqu� manejaremos el acceso a las bases de datos.
Capa de Servicios (Business Layer o BLL): Implementaremos la l�gica de negocio.
Capa de Controladores (API Layer o Presentation Layer): Aqu� exponemos los endpoints del microservicio.

Reglas de Asignaci�n de �tems:


Condiciones de asignaci�n:
Si la fecha de entrega est� pr�xima a vencer (menos de tres d�as), el �tem se asignar� al usuario con menos �tems de trabajo, sin importar su relevancia.
Si el �tem es altamente relevante y hay m�s de tres d�as antes de la fecha de entrega, se asignar� al usuario con menos �tems de trabajo y menos �tems relevantes.

Ejemplo:
En el caso con los usuarios A y B, el sistema asignar� un nuevo �tem altamente relevante y con fecha de entrega cercana al usuario B, dado que tiene menos �tems pendientes.
Paso 1: Configuraci�n del Proyecto en Visual Studio 2022
Paso 2: Dise�o de las Tablas en SQL Server 

