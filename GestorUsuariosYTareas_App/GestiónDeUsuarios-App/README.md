Plan de Acción Actualizado Tecnologías:

Usaremos .NET Core 3.1 o superior (o .NET 6/7/8 si te resulta cómodo y compatible con Visual Studio 2022). Código en C#. Estructura del Proyecto:

Crearemos dos soluciones: Microservicio de Ítems de Trabajo. Microservicio de Gestión de Usuarios.

Cada microservicio tendrá una arquitectura de 3 capas: Capa de Datos (Data Access Layer o DAL): Aquí manejaremos el acceso a las bases de datos. Capa de Servicios (Business Layer o BLL): Implementaremos la lógica de negocio. Capa de Controladores (API Layer o Presentation Layer): Aquí exponemos los endpoints del microservicio.

Reglas de Asignación de Ítems:

Condiciones de asignación: Si la fecha de entrega está próxima a vencer (menos de tres días), el ítem se asignará al usuario con menos ítems de trabajo, sin importar su relevancia. Si el ítem es altamente relevante y hay más de tres días antes de la fecha de entrega, se asignará al usuario con menos ítems de trabajo y menos ítems relevantes.

Ejemplo: En el caso con los usuarios A y B, el sistema asignará un nuevo ítem altamente relevante y con fecha de entrega cercana al usuario B, dado que tiene menos ítems pendientes. Paso 1: Configuración del Proyecto en Visual Studio 2022 Paso 2: Diseño de las Tablas en SQL Server