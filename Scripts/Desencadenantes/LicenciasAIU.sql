DROP TRIGGER LicenciasAIU
GO


CREATE TRIGGER LicenciasAIU ON Licencias
AFTER INSERT, UPDATE
AS

DECLARE @DT01 INT
DECLARE @DT02 INT

SELECT @DT01 = DATEDIFF(second, FechaHoraSolicitudLicencia, FechaHoraInicioLicencia),
@DT02 = DATEDIFF(second, FechaHoraInicioLicencia, FechaHoraFinLicencia)
FROM Inserted

IF (@DT01 <= 0) 
BEGIN
	RAISERROR ('La fecha de inicio de licencia no puede ser menor a la fecha de solicitud de licencia.',16,1)
	ROLLBACK TRANSACTION
END
ELSE IF (@DT02 <= 0)
BEGIN
	RAISERROR ('La fecha de fin de licencia no puede ser menor a la fecha de inicio de licencia',16,1)
	ROLLBACK TRANSACTION
END


