use templateDB;
go


select * from Servicios;


CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador �nico del usuario
    Nombre VARCHAR(50) NOT NULL,              -- Primer nombre del usuario
    Apellido VARCHAR(50) NOT NULL,            -- Apellido del usuario
    Telefono VARCHAR(20),                     -- N�mero de tel�fono (opcional)
    Email VARCHAR(100) NOT NULL UNIQUE,       -- Correo electr�nico �nico
    Usuario VARCHAR(50) NOT NULL UNIQUE,      -- Alias o nombre para iniciar sesi�n
    Contrasena VARCHAR(255) NOT NULL,           -- Contrase�a cifrada
    FechaNacimiento DATE,                     -- Fecha de nacimiento
    Rol VARCHAR(20) NOT NULL DEFAULT 'Usuario', -- Rol por defecto
    Activo BIT DEFAULT 1,                     -- Si el usuario est� activo
    FechaRegistro DATETIME DEFAULT GETDATE()  -- Fecha de creaci�n del usuario
);

INSERT INTO Usuarios (Nombre, Apellido, Telefono, Email, Usuario, Contrasena, FechaNacimiento, Rol, Activo)
VALUES 
('Juan', 'Ruiz', '123456789', 'juan.ruiz@example.com', 'jruiz', 'HASH_CONTRASENA_JUAN', '1990-01-15', 'Admin', 1),
('Lourdes', 'Rojas', '987654321', 'lou.rojas@example.com', 'lrojas', 'HASH_CONTRASENA_ANA', '1995-05-10', 'Usuario', 1),
('Karina', 'Amaral', NULL, 'kari.amaral@example.com', 'kamaral', 'HASH_CONTRASENA_CARLOS', '1988-11-25', 'Usuario', 0);


select * from Usuarios;