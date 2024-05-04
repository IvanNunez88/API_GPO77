CREATE PROC spConsultaCliente
(@P_Accion TINYINT,
 @P_Texto VARCHAR(15) = NULL)
AS
BEGIN
	SET NOCOUNT ON

	IF @P_Accion = 1
	BEGIN

		SELECT IdCliente,
			   CONCAT_WS(' ', Nombre,APaterno,AMaterno) AS Cliente,
			   RFC,
			   FORMAT(FecRegistro,'dd/MM/yyyy HH:mm') AS FecRegistro,
			   iif(IsActivo= 1, 'Activo', 'InActico') AS Estatus
		FROM CLIENTE

	END
	ELSE IF @P_Accion = 2
	BEGIN

		SELECT IdCliente,
			   CONCAT_WS(' ', Nombre,APaterno,AMaterno) AS Cliente,
			   RFC,
			   FORMAT(FecRegistro,'dd/MM/yyyy HH:mm') AS FecRegistro,
			   iif(IsActivo= 1, 'Activo', 'InActico') AS Estatus
		FROM CLIENTE
		WHERE CONCAT(Nombre,APaterno,AMaterno) LIKE '%' + @P_Texto + '%'

	END

	SET NOCOUNT OFF
END