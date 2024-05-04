CREATE PROC spInsertCliente
(@P_Nombre VARCHAR(60),
 @P_APaterno VARCHAR(60),  
 @P_AMaterno VARCHAR(60), 
 @P_RFC VARCHAR(13))
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO CLIENTE (Nombre, APaterno, AMaterno, RFC)
				 VALUES (@P_Nombre, @P_APaterno, @P_AMaterno, @P_RFC)

	SET NOCOUNT OFF
END