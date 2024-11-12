Add-Migration InitialCreate

Update-Database



JSON de ejemplo


DATOS PARA PROBAR LA FUNCIONALIDAD
INSERT INTO Usuarios (NombreUsuario)
VALUES ('Usuario1'), ('Usuario2'), ('Usuario3');


INSERT INTO ItemsDeTrabajo (Titulo, Descripcion, FechaEntrega, Relevancia, UsuarioId)
VALUES ('Tarea de prueba', 'Descripción de prueba', '2024-11-13', 'Alta', 1);


{
  "titulo": "Desarrollar nueva funcionalidad",
  "descripcion": "Desarrollar la nueva funcionalidad para la app de gestión de tareas.",
  "fechaEntrega": "2024-11-15T00:00:00Z",
  "relevancia": "Alta",
  "usuarioId": 1,
  "usuario": {
    "usuarioId": 1,
    "nombreUsuario": "Juan Pérez",
    "itemsDeTrabajoPendientes": []
  }
}


