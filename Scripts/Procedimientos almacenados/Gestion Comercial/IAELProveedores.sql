use DOBLONES20
GO

DROP PROCEDURE InsertarProveedor
GO

CREATE PROCEDURE InsertarProveedor
	@NombreRazonSocial		VARCHAR(250),
	@NombreRepresentante	VARCHAR(250),
	@CodigoTipoProveedor	CHAR(1),
	@NITProveedor			VARCHAR(30),
	@CodigoBanco			TINYINT,
	@NumeroCuentaBanco		CHAR(30),
	@CodigoMoneda			TINYINT,
	@NombreOrdenCheque		VARCHAR(250),
	@CodigoPais				CHAR(2),
	@CodigoDepartamento		CHAR(2),
	@CodigoProvincia		CHAR(2),
	@CodigoLugar			CHAR(3),
	@Direccion				VARCHAR(250),
	@Telefono				VARCHAR(50),
	@Fax					VARCHAR(250),
	@Casilla				CHAR(15),
	@Email					TEXT,
	@Observaciones			TEXT,
	@ProveedorActivo		BIT,
	@NumeroAgencia			INT
AS
BEGIN
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Proveedores WHERE NombreRazonSocial = @NombreRazonSocial))
		INSERT INTO dbo.Proveedores (NombreRazonSocial,	NombreRepresentante,CodigoTipoProveedor,NITProveedor,CodigoBanco,NumeroCuentaBanco,	CodigoMoneda,NombreOrdenCheque,	CodigoPais,CodigoDepartamento,CodigoProvincia,CodigoLugar,Direccion,Telefono,Fax,Casilla,Email,Observaciones, ProveedorActivo, NumeroAgencia)
		VALUES (@NombreRazonSocial,@NombreRepresentante,@CodigoTipoProveedor,@NITProveedor,@CodigoBanco,@NumeroCuentaBanco,	@CodigoMoneda,@NombreOrdenCheque,	@CodigoPais,@CodigoDepartamento,@CodigoProvincia,@CodigoLugar,@Direccion,@Telefono,@Fax,@Casilla,@Email,@Observaciones, @ProveedorActivo, @NumeroAgencia)
	ELSE
		RAISERROR ('EL NOMBRE DEL PROVEEDOR YA SE ENCUENTRA REGISTRADO',16, 2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16, 2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE ActualizarProveedor
GO

CREATE PROCEDURE ActualizarProveedor
	@CodigoProveedor		INT,
	@NombreRazonSocial		VARCHAR(250),
	@NombreRepresentante	VARCHAR(250),
	@CodigoTipoProveedor	CHAR(1),
	@NITProveedor			VARCHAR(30),
	@CodigoBanco			TINYINT,
	@NumeroCuentaBanco		CHAR(30),
	@CodigoMoneda			TINYINT,
	@NombreOrdenCheque		VARCHAR(250),
	@CodigoPais				CHAR(2),
	@CodigoDepartamento		CHAR(2),
	@CodigoProvincia		CHAR(2),
	@CodigoLugar			CHAR(3),
	@Direccion				VARCHAR(250),
	@Telefono				VARCHAR(50),
	@Fax					VARCHAR(250),
	@Casilla				CHAR(15),
	@Email					TEXT,
	@Observaciones			TEXT,
	@ProveedorActivo		BIT,
	@NumeroAgencia			INT
AS
BEGIN
	BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT * FROM Proveedores WHERE NombreRazonSocial = @NombreRazonSocial AND CodigoProveedor <> @CodigoProveedor))
		UPDATE 	dbo.Proveedores
		SET		
			NombreRazonSocial		= @NombreRazonSocial,
			NombreRepresentante		= @NombreRepresentante,
			CodigoTipoProveedor		= @CodigoTipoProveedor,
			NITProveedor			= @NITProveedor,
			CodigoBanco				= @CodigoBanco,
			NumeroCuentaBanco		= @NumeroCuentaBanco,
			CodigoMoneda			= @CodigoMoneda,
			NombreOrdenCheque		= @NombreOrdenCheque,
			CodigoPais				= @CodigoPais,
			CodigoDepartamento		= @CodigoDepartamento,
			CodigoProvincia			= @CodigoProvincia,
			CodigoLugar				= @CodigoLugar,
			Direccion				= @Direccion,
			Telefono				= @Telefono,
			Fax						= @Fax,
			Casilla					= @Casilla,
			Email					= @Email,
			Observaciones			= @Observaciones,
			ProveedorActivo			= @ProveedorActivo,
			NumeroAgencia			= @NumeroAgencia
		WHERE (@CodigoProveedor = CodigoProveedor)
	ELSE
		RAISERROR ('EL NOMBRE DEL PROVEEDOR YA SE ENCUENTRA REGISTRADO',16,2)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO INSERTAR CORRECTAMENTE EL REGISTRO',16,2)
	END
	ELSE
		COMMIT TRANSACTION
END
GO

DROP PROCEDURE EliminarProveedor
GO

CREATE PROCEDURE EliminarProveedor
@CodigoProveedor INT
AS
BEGIN
	BEGIN TRANSACTION
		DELETE 
		FROM dbo.Proveedores
		WHERE (@CodigoProveedor = CodigoProveedor)
	IF(@@ERROR <> 0)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR ('NO SE PUDO ELIMINAR CORRECTAMENTE EL REGISTRO, PROBABLEMENTE EL SERVICIO YA SE ENCUENTRA EN USO EN ALGUNA TRANSACCIÓN',2,16)
	END
	ELSE
		COMMIT TRANSACTION


END
GO

DROP PROCEDURE ListarProveedores
GO

CREATE PROCEDURE ListarProveedores
AS
BEGIN
	SELECT CodigoProveedor, NombreRazonSocial, NombreRepresentante, CodigoTipoProveedor, NITProveedor, CodigoBanco, NumeroCuentaBanco, CodigoMoneda, NombreOrdenCheque,	CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, Direccion, Telefono, Fax, Casilla, Email, Observaciones, ProveedorActivo, NumeroAgencia
	FROM dbo.Proveedores
	ORDER BY NombreRazonSocial
END
GO

DROP PROCEDURE ObtenerProveedor
GO

CREATE PROCEDURE ObtenerProveedor
@CodigoProveedor INT
AS
BEGIN
	SELECT CodigoProveedor, NombreRazonSocial, NombreRepresentante, CodigoTipoProveedor, NITProveedor, CodigoBanco, NumeroCuentaBanco, CodigoMoneda, NombreOrdenCheque,	CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, Direccion, Telefono, Fax, Casilla, Email, Observaciones, ProveedorActivo, NumeroAgencia
	FROM dbo.Proveedores
	WHERE (@CodigoProveedor = CodigoProveedor)
END
GO