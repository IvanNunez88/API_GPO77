CREATE PROC spActualiCliente
(@P_Nombre VARCHAR (60),
 @P_APaterno VARCHAR (60), 
 @P_AMaterno VARCHAR (60),
 @P_RFC VARCHAR (13),
 @P_IsActivo BIT,
 @P_IdCliente INT)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE CLIENTE SET Nombre = @P_Nombre,
					   APaterno = @P_APaterno,
					   AMaterno = @P_AMaterno,
					   RFC = @P_RFC,
					   IsActivo = @P_IsActivo
	WHERE IdCliente = @P_IdCliente


	SET NOCOUNT OFF
END
