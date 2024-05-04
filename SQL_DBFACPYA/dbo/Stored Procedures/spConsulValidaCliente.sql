CREATE PROC spConsulValidaCliente
(@P_Accion TINYINT,
 @P_Nombre VARCHAR(20) = NULL, 
 @P_APaterno  VARCHAR(20) = NULL, 
 @P_AMaterno  VARCHAR(20) = NULL,
 @P_RFC VARCHAR(20) = NULL)
AS
BEGIN
	SET NOCOUNT ON

	IF @P_Accion = 1
	BEGIN
		SELECT 1 AS RESULTADO
		FROM CLIENTE
		WHERE UPPER(RFC) = UPPER(@P_RFC) AND
			  TRIM(UPPER(CONCAT(Nombre, APaterno, AMaterno))) = 
			  TRIM(UPPER(REPLACE(CONCAT(@P_Nombre, @P_APaterno, @P_AMaterno),' ',''))) 
			  COLLATE Traditional_Spanish_CI_AI
	END

	SET NOCOUNT OFF
END
