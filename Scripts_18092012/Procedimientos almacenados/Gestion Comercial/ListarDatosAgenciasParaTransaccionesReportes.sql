USE Doblones20
GO


DROP PROCEDURE ListarDatosAgenciasParaTransaccionesReportes
GO

CREATE PROCEDURE ListarDatosAgenciasParaTransaccionesReportes
	@NumeroAgencia		INT	
AS
BEGIN
	SELECT A.NombreAgencia, P.NombrePais, D.NombreDepartamento, A.DireccionAgencia, A.NITAgencia, A.NumeroAutorizacion,
		 '4-64-55099' AS Telefono, 'icpr.representaciones@gmail.com ' as CorreoElectronico1, 
		 'icpr.representaciones@gmail.com 2' as CorreoElectronico2, 
		 'icpr.representaciones@gmail.com 3' as CorreoElectronico3
	FROM Agencias A LEFT JOIN Paises P ON P.CodigoPais = A.CodigoPais
	LEFT JOIN Departamentos D ON A.CodigoDepartamento = D.CodigoDepartamento	
	WHERE A.NumeroAgencia = @NumeroAgencia;
END