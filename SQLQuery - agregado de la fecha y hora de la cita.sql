use templateDB;
go

ALTER TABLE Turnos
ADD FechaCita DATE NOT NULL DEFAULT GETDATE(), -- Usar la fecha actual como predeterminada
    HoraCita TIME NOT NULL DEFAULT '09:00';   -- Usar un horario predeterminado (ejemplo: 09:00 AM)

EXEC sp_help 'Turnos';

ALTER TABLE Turnos
DROP CONSTRAINT DF_Turnos_FechaCita; -- Nombre del constraint generado automáticamente por SQL Server

ALTER TABLE Turnos
DROP CONSTRAINT DF_Turnos_HoraCita;


SELECT name
FROM sys.default_constraints
WHERE parent_object_id = OBJECT_ID('Turnos');
ALTER TABLE Turnos
DROP CONSTRAINT DF__Turnos__FechaCit__73852659;

ALTER TABLE Turnos
DROP CONSTRAINT DF__Turnos__HoraCita__74794A92;


UPDATE Turnos
SET FechaCita = GETDATE(), -- Asigna una fecha válida (la fecha actual en este caso)
    HoraCita = '09:00' -- Asigna una hora válida
WHERE FechaCita IS NULL OR HoraCita IS NULL;


ALTER TABLE Turnos
ALTER COLUMN FechaCita DATE NOT NULL;

ALTER TABLE Turnos
ALTER COLUMN HoraCita TIME NOT NULL;


INSERT INTO Turnos (IdUsuario, Estado, ImporteTotal) 
VALUES (1, 'Pendiente', 100.00); -- Esto debería fallar porque falta FechaCita y HoraCita

INSERT INTO Turnos (IdUsuario, Estado, ImporteTotal, FechaTurno, FechaCita, HoraCita)
VALUES (1, 'Pendiente', 100.00, GETDATE(), '2025-04-01', '10:00');

select * from Turnos;