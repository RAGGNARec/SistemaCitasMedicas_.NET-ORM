CREATE DATABASE DBCitasMedicas;
GO

USE DBCitasMedicas;
GO

-- -----------------------------------------------------
-- Table Pacientes
-- -----------------------------------------------------
DROP TABLE IF EXISTS Paciente;
GO
CREATE TABLE Pacientes (
    idPaciente INT NOT NULL IDENTITY(1,1),
    nombre VARCHAR(45) NULL,
    apellido VARCHAR(45) NULL,
    cedula VARCHAR(15) NULL,
    direccion VARCHAR(80) NULL,
    telefono VARCHAR(13) NULL,
    correo VARCHAR(45) NULL,
    estado INT NULL,
    fechaNacimiento DATE NULL,
    CONSTRAINT PK_Pacientes PRIMARY KEY (idPaciente)
);
GO

-- -----------------------------------------------------
-- Table Consultorios
-- -----------------------------------------------------
DROP TABLE IF EXISTS Consultorio;
GO
CREATE TABLE Consultorios (
    idConsultorio INT NOT NULL IDENTITY(1,1),
    ubicacion VARCHAR(45) NULL,
    descripcion VARCHAR(45) NULL,
    estado INT NULL,
    CONSTRAINT PK_Consultorios PRIMARY KEY (idConsultorio)
);
GO

-- -----------------------------------------------------
-- Table Medicos
-- -----------------------------------------------------
DROP TABLE IF EXISTS Medico;
GO
CREATE TABLE Medicos (
    idMedico INT NOT NULL IDENTITY(1,1),
	idConsultorio INT NOT NULL,
    nombre VARCHAR(45) NULL,
    apellido VARCHAR(45) NULL,
    direccion VARCHAR(45) NULL,
    telefono VARCHAR(45) NULL,
    correo VARCHAR(45) NULL,
    codigoMedico VARCHAR(45) NULL,
    estado INT NULL,
    CONSTRAINT PK_Medicos PRIMARY KEY (idMedico),
    CONSTRAINT FK_Medicos_Consultorios FOREIGN KEY (idConsultorio) REFERENCES Consultorios(idConsultorio) ON DELETE CASCADE
);
GO

-- -----------------------------------------------------
-- Table Especialidades
-- -----------------------------------------------------
DROP TABLE IF EXISTS Especialidad;
GO
CREATE TABLE Especialidades (
    idEspecialidad INT NOT NULL IDENTITY(1,1),
    nombre VARCHAR(45) NULL,
    descripcion VARCHAR(45) NULL,
    estado INT NULL,
    CONSTRAINT PK_Especialidades PRIMARY KEY (idEspecialidad)
);
GO

-- -----------------------------------------------------
-- Table Horarios
-- -----------------------------------------------------
DROP TABLE IF EXISTS Horario;
GO
CREATE TABLE Horarios (
    idHorario INT NOT NULL IDENTITY(1,1),
    fecha DATE NULL,
    horaInicio TIME NULL,
    horaFin TIME NULL,
    descripcion VARCHAR(45) NULL,
    estado INT NULL,
    CONSTRAINT PK_Horarios PRIMARY KEY (idHorario)
);
GO

-- -----------------------------------------------------
-- Table Horario_Medico
-- -----------------------------------------------------
DROP TABLE IF EXISTS Horario_Medico;
GO
CREATE TABLE HorarioMedicos (
    idHorarioMedico INT NOT NULL IDENTITY(1,1),
    idHorario INT NOT NULL,
    idMedico INT NOT NULL,
    CONSTRAINT PK_Horario_Medico PRIMARY KEY (idHorarioMedico),
    CONSTRAINT FK_Horario_Medico_Horarios FOREIGN KEY (idHorario) REFERENCES Horarios(idHorario) ON DELETE CASCADE,
    CONSTRAINT FK_Horario_Medico_Medicos FOREIGN KEY (idMedico) REFERENCES Medicos(idMedico) ON DELETE CASCADE
);
GO

-- -----------------------------------------------------
-- Table Citas
-- -----------------------------------------------------
DROP TABLE IF EXISTS cita;
GO
CREATE TABLE Citas (
    idCita INT NOT NULL IDENTITY(1,1),
    fechaRegistro DATE NULL,
    descripcion VARCHAR(45) NULL,
    estado INT NULL,
    estadoCita CHAR(1) NULL,
    idPaciente INT NOT NULL,
    idHorarioMedico INT NOT NULL,
    horaCita TIME NULL,
    CONSTRAINT PK_Citas PRIMARY KEY (idCita),
    CONSTRAINT FK_Citas_Pacientes FOREIGN KEY (idPaciente) REFERENCES Pacientes(idPaciente) ON DELETE CASCADE,
    CONSTRAINT FK_Citas_Horario_Medico FOREIGN KEY (idHorarioMedico) REFERENCES HorarioMedicos(idHorarioMedico) ON DELETE CASCADE
);
GO


-- -----------------------------------------------------
-- Table Especialidad_Medico
-- -----------------------------------------------------
DROP TABLE IF EXISTS Especialidad_Medico;
GO
CREATE TABLE EspecialidadMedicos (
    idMedicoEspecialidad INT NOT NULL IDENTITY(1,1),
    idEspecialidad INT NOT NULL,
    idMedico INT NOT NULL,
    CONSTRAINT PK_Especialidad_Medico PRIMARY KEY (idMedicoEspecialidad),
    CONSTRAINT FK_Especialidad_Medico_Especialidades FOREIGN KEY (idEspecialidad) REFERENCES Especialidades(idEspecialidad) ON DELETE CASCADE,
    CONSTRAINT FK_Especialidad_Medico_Medicos FOREIGN KEY (idMedico) REFERENCES Medicos(idMedico) ON DELETE CASCADE
);
GO
