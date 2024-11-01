USE [FSBR]
GO
/****** Object:  Table [dbo].[Processos]    Script Date: 28/10/2024 08:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Processos](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](70) NULL,
	[NPU] [varchar](20) NULL,
	[DataCadastro] [datetime] NULL,
	[DataVisualizacao] [datetime] NULL,
	[UF] [varchar](50) NULL,
	[Municipio] [int] NULL,
 CONSTRAINT [PK_Processos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
