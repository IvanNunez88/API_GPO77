CREATE TABLE [dbo].[CLIENTE] (
    [IdCliente]   INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (60)  NOT NULL,
    [APaterno]    VARCHAR (60)  NOT NULL,
    [AMaterno]    VARCHAR (60)  NOT NULL,
    [RFC]         VARCHAR (13)  NOT NULL,
    [FecRegistro] SMALLDATETIME CONSTRAINT [DF_FecRegistro_CLI] DEFAULT (getdate()) NULL,
    [IsActivo]    BIT           CONSTRAINT [DF_IsActivo_CLI] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_IdCliente_CLI] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [UQ_RFC] UNIQUE NONCLUSTERED ([RFC] ASC)
);

