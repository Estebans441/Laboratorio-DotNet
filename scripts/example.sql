-- Seed data into persona table
USE persona_db;
GO

IF NOT EXISTS (SELECT * FROM persona_db.persona WHERE cc = 101010101)
    INSERT INTO persona_db.persona (cc, nombre, apellido, genero, edad) 
    VALUES (101010101, 'Juan', 'Pérez', 'M', 30);
IF NOT EXISTS (SELECT * FROM persona_db.persona WHERE cc = 202020202)
    INSERT INTO persona_db.persona (cc, nombre, apellido, genero, edad) 
    VALUES (202020202, 'Ana', 'García', 'F', 28);
IF NOT EXISTS (SELECT * FROM persona_db.persona WHERE cc = 303030303)
    INSERT INTO persona_db.persona (cc, nombre, apellido, genero, edad) 
    VALUES (303030303, 'Carlos', 'Rodríguez', 'M', 35);
IF NOT EXISTS (SELECT * FROM persona_db.persona WHERE cc = 404040404)
    INSERT INTO persona_db.persona (cc, nombre, apellido, genero, edad) 
    VALUES (404040404, 'Luisa', 'Martínez', 'F', 25);
GO

-- Seed data into profesion table
IF NOT EXISTS (SELECT * FROM persona_db.profesion WHERE id = 1)
    INSERT INTO persona_db.profesion (id, nom, des) 
    VALUES (1, 'Ingeniero de Sistemas', 'Profesional en ingeniería de software y redes.');
IF NOT EXISTS (SELECT * FROM persona_db.profesion WHERE id = 2)
    INSERT INTO persona_db.profesion (id, nom, des) 
    VALUES (2, 'Médico', 'Profesional en medicina general y cirugías.');
IF NOT EXISTS (SELECT * FROM persona_db.profesion WHERE id = 3)
    INSERT INTO persona_db.profesion (id, nom, des) 
    VALUES (3, 'Abogado', 'Profesional en derecho y leyes.');
IF NOT EXISTS (SELECT * FROM persona_db.profesion WHERE id = 4)
    INSERT INTO persona_db.profesion (id, nom, des) 
    VALUES (4, 'Profesor', 'Profesional en docencia de nivel primario y secundario.');
GO

-- Seed data into estudios table
IF NOT EXISTS (SELECT * FROM persona_db.estudios WHERE id_prof = 1 AND cc_per = 101010101)
    INSERT INTO persona_db.estudios (id_prof, cc_per, fecha, univer) 
    VALUES (1, 101010101, '2015-06-10', 'Universidad Nacional');
IF NOT EXISTS (SELECT * FROM persona_db.estudios WHERE id_prof = 2 AND cc_per = 202020202)
    INSERT INTO persona_db.estudios (id_prof, cc_per, fecha, univer) 
    VALUES (2, 202020202, '2013-09-15', 'Universidad de los Andes');
IF NOT EXISTS (SELECT * FROM persona_db.estudios WHERE id_prof = 3 AND cc_per = 303030303)
    INSERT INTO persona_db.estudios (id_prof, cc_per, fecha, univer) 
    VALUES (3, 303030303, '2010-03-20', 'Universidad del Rosario');
IF NOT EXISTS (SELECT * FROM persona_db.estudios WHERE id_prof = 4 AND cc_per = 404040404)
    INSERT INTO persona_db.estudios (id_prof, cc_per, fecha, univer) 
    VALUES (4, 404040404, '2018-07-01', 'Pontificia Universidad Javeriana');
GO

-- Seed data into telefono table
IF NOT EXISTS (SELECT * FROM persona_db.telefono WHERE num = '3001234567')
    INSERT INTO persona_db.telefono (num, oper, duenio) 
    VALUES ('3001234567', 'Claro', 101010101);
IF NOT EXISTS (SELECT * FROM persona_db.telefono WHERE num = '3209876543')
    INSERT INTO persona_db.telefono (num, oper, duenio) 
    VALUES ('3209876543', 'Movistar', 202020202);
IF NOT EXISTS (SELECT * FROM persona_db.telefono WHERE num = '3105556789')
    INSERT INTO persona_db.telefono (num, oper, duenio) 
    VALUES ('3105556789', 'Tigo', 303030303);
IF NOT EXISTS (SELECT * FROM persona_db.telefono WHERE num = '3111237890')
    INSERT INTO persona_db.telefono (num, oper, duenio) 
    VALUES ('3111237890', 'Claro', 404040404);
GO
