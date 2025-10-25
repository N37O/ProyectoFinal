
CREATE TABLE Departamento (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL
);

INSERT INTO Departamento (nombre)
VALUES ('RRHH'), ('Almacén'), ('Ventas');

CREATE TABLE Cargo (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    nivel NVARCHAR(50),
    salarioBase DECIMAL(10,2) NOT NULL
);

INSERT INTO Cargo (nombre, nivel, salarioBase)
VALUES 
    ('Jefe', 'Alto', 1200.00),
    ('Gerente', 'Medio', 900.00),
    ('Empleado', 'Básico', 600.00);

CREATE TABLE Empleado (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombreCompleto NVARCHAR(200) NOT NULL,
    DUI NVARCHAR(10) UNIQUE NOT NULL,
    Telefono NVARCHAR(10),
    Estado NVARCHAR(20) NOT NULL,
    departamentoId INT NOT NULL,
    cargoId INT NOT NULL,
    FOREIGN KEY (departamentoId) REFERENCES Departamento(id),
    FOREIGN KEY (cargoId) REFERENCES Cargo(id)
);



CREATE TABLE Asistencia (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fecha DATE NOT NULL,
    horaEntrada TIME NOT NULL,
    horaSalida TIME NOT NULL,
    estado NVARCHAR(20),  -- Ej: 'Presente', 'Ausente', 'Justificado'
    nota NVARCHAR(500),
    empleadoId INT NOT NULL,
    FOREIGN KEY (empleadoId) REFERENCES Empleado(id),
    UNIQUE (fecha, empleadoId)
);


