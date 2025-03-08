use templateDB;
go


select * from Servicios;


CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador único del usuario
    Nombre VARCHAR(50) NOT NULL,              -- Primer nombre del usuario
    Apellido VARCHAR(50) NOT NULL,            -- Apellido del usuario
    Telefono VARCHAR(20),                     -- Número de teléfono (opcional)
    Email VARCHAR(100) NOT NULL UNIQUE,       -- Correo electrónico único
    Usuario VARCHAR(50) NOT NULL UNIQUE,      -- Alias o nombre para iniciar sesión
    Contrasena VARCHAR(255) NOT NULL,           -- Contraseña cifrada
    FechaNacimiento DATE,                     -- Fecha de nacimiento
    Rol VARCHAR(20) NOT NULL DEFAULT 'Usuario', -- Rol por defecto
    Activo BIT DEFAULT 1,                     -- Si el usuario está activo
    FechaRegistro DATETIME DEFAULT GETDATE()  -- Fecha de creación del usuario
);

INSERT INTO Usuarios (Nombre, Apellido, Telefono, Email, Usuario, Contrasena, FechaNacimiento, Rol, Activo)
VALUES 
('Juan', 'Ruiz', '123456789', 'juan.ruiz@example.com', 'jruiz', 'HASH_CONTRASENA_JUAN', '1990-01-15', 'Admin', 1),
('Lourdes', 'Rojas', '987654321', 'lou.rojas@example.com', 'lrojas', 'HASH_CONTRASENA_ANA', '1995-05-10', 'Usuario', 1),
('Karina', 'Amaral', NULL, 'kari.amaral@example.com', 'kamaral', 'HASH_CONTRASENA_CARLOS', '1988-11-25', 'Usuario', 0);


select * from Usuarios;