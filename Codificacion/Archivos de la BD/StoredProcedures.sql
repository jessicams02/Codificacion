CREATE PROCEDURE sp_ListVacantes @id int
	AS BEGIN
		IF @id = 0
			SELECT * FROM VACANTE
		ELSE 
			SELECT * FROM VACANTE WHERE id = @id
	END

CREATE PROCEDURE sp_InsertVacante @area varchar(50), @sueldo money, @activo bit
    AS BEGIN
		DECLARE @aidi AS INT = (SELECT TOP 1 CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END id FROM VACANTE) 

		INSERT INTO VACANTE (id, area, sueldo, activo)
		VALUES (@aidi, @area, @sueldo, @activo)
	END 

CREATE PROCEDURE sp_UpdateVacante @id int, @area varchar(50), @sueldo money, @activo bit
	AS BEGIN
		UPDATE VACANTE SET area = @area, sueldo = @sueldo, activo = @activo WHERE id = @id
	END

CREATE PROCEDURE sp_DeleteVacante @id int
	AS BEGIN 
		DELETE FROM VACANTE WHERE id = @id
	END

/*----------------- PROSPECTO ---------------*/
CREATE PROCEDURE sp_ListProspectos @id int
	AS BEGIN
		IF @id = 0
			SELECT * FROM PROSPECTO
		Else
			SELECT * FROM PROSPECTO WHERE id = @id
	END

CREATE PROCEDURE sp_InsertProspecto @nombre varchar(50), @correo varchar(50), @fecha date
    AS BEGIN
		DECLARE @aidi AS INT = (SELECT TOP 1 CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END id FROM PROSPECTO) 

	    INSERT INTO PROSPECTO (id, nombre, correo, fecha_registro)
		VALUES (@aidi, @nombre, @correo, @fecha)
    END

CREATE PROCEDURE sp_UpdateProspecto @id int, @nombre varchar(50), @correo varchar(50), @fecha date
	AS BEGIN
		UPDATE PROSPECTO SET nombre = @nombre, correo = @correo, fecha_registro = @fecha WHERE id = @id
	END

CREATE PROCEDURE sp_DeleteProspecto @id int
	AS BEGIN 
		DELETE FROM PROSPECTO WHERE id = @id
	END

/*--------------- ENTREVISTA -----------------*/
CREATE PROCEDURE sp_ListEntrevistas @id int
	AS BEGIN
		IF @id = 0
			SELECT * FROM ENTREVISTA
		ELSE
			SELECT * FROM ENTREVISTA WHERE id = @id
	END

CREATE PROCEDURE sp_InsertEntrevista @vacante int, @prospecto int, @fecha date, @notas text, @reclutado bit
    AS BEGIN
		DECLARE @aidi AS INT = (SELECT TOP 1 CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END id FROM ENTREVISTA) 

	    INSERT INTO ENTREVISTA(id, vacante, prospecto, fecha_entrevista, notas, reclutado)
		VALUES (@aidi, @vacante, @prospecto, @fecha, @notas, @reclutado)
    END

CREATE PROCEDURE sp_UpdateEntrevista @id int, @vacante int, @prospecto int, @fecha date, @notas text, @reclutado bit
	AS BEGIN
		UPDATE ENTREVISTA SET vacante = @vacante, prospecto = @prospecto, fecha_entrevista = @fecha, 
		notas = @notas, reclutado = @reclutado WHERE id = @id
	END

CREATE PROCEDURE sp_DeleteEntrevista @id int
	AS BEGIN 
		DELETE FROM ENTREVISTA WHERE id = @id
	END