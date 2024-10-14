-- Otorgar propiedad de la base de datos al usuario sa
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'persona_db')
BEGIN
    CREATE DATABASE persona_db;
    ALTER AUTHORIZATION ON DATABASE::persona_db TO sa;
END
GO

-- Cambiar al nuevo contexto de la base de datos
USE persona_db;
GO

-- Crear el esquema
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'arq_per_db')
BEGIN
    EXEC('CREATE SCHEMA arq_per_db AUTHORIZATION sa');
END
GO

-- -----------------------------------------------------
-- Tabla `arq_per_db`.`persona`
-- -----------------------------------------------------
IF OBJECT_ID('arq_per_db.persona', 'U') IS NULL
BEGIN
    CREATE TABLE arq_per_db.persona (
        cc INT NOT NULL,
        nombre VARCHAR(45) NOT NULL,
        apellido VARCHAR(45) NOT NULL,
        genero CHAR(1) NOT NULL CHECK (genero IN ('M', 'F')), -- No hay ENUM en SQL Server, usamos CHECK
        edad INT NULL,
        CONSTRAINT PK_persona PRIMARY KEY (cc)
    );
END
GO

-- -----------------------------------------------------
-- Tabla `arq_per_db`.`profesion`
-- -----------------------------------------------------
IF OBJECT_ID('arq_per_db.profesion', 'U') IS NULL
BEGIN
    CREATE TABLE arq_per_db.profesion (
        id INT NOT NULL,
        nom VARCHAR(90) NOT NULL,
        des TEXT NULL,
        CONSTRAINT PK_profesion PRIMARY KEY (id)
    );
END
GO

-- -----------------------------------------------------
-- Tabla `arq_per_db`.`estudios`
-- -----------------------------------------------------
IF OBJECT_ID('arq_per_db.estudios', 'U') IS NULL
BEGIN
    CREATE TABLE arq_per_db.estudios (
        id_prof INT NOT NULL,
        cc_per INT NOT NULL,
        fecha DATE NULL,
        univer VARCHAR(50) NULL,
        CONSTRAINT PK_estudios PRIMARY KEY (id_prof, cc_per),
        CONSTRAINT FK_estudios_persona FOREIGN KEY (cc_per) REFERENCES arq_per_db.persona(cc),
        CONSTRAINT FK_estudios_profesion FOREIGN KEY (id_prof) REFERENCES arq_per_db.profesion(id)
    );
END
GO

-- -----------------------------------------------------
-- Tabla `arq_per_db`.`telefono`
-- -----------------------------------------------------
IF OBJECT_ID('arq_per_db.telefono', 'U') IS NULL
BEGIN
    CREATE TABLE arq_per_db.telefono (
        num VARCHAR(15) NOT NULL,
        oper VARCHAR(45) NOT NULL,
        duenio INT NOT NULL,
        CONSTRAINT PK_telefono PRIMARY KEY (num),
        CONSTRAINT FK_telefono_persona FOREIGN KEY (duenio) REFERENCES arq_per_db.persona(cc)
    );
END
GO
