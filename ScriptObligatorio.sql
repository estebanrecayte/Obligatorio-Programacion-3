USE [BaseDatosObligatorio]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16/5/2024 14:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 16/5/2024 14:43:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[Codigo] [bigint] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Precio] [float] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 16/5/2024 14:43:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rut] [bigint] NOT NULL,
	[RazonSocial] [nvarchar](max) NOT NULL,
	[DistanciaKm] [int] NOT NULL,
	[Calle] [nvarchar](max) NOT NULL,
	[Ciudad] [nvarchar](max) NOT NULL,
	[Numero] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lineas]    Script Date: 16/5/2024 14:43:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lineas](
	[PedidoId] [int] NOT NULL,
	[ArticuloId] [bigint] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
 CONSTRAINT [PK_Lineas] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC,
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 16/5/2024 14:43:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaEntregaPrometida] [date] NOT NULL,
	[TipoPedido] [nvarchar](8) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/5/2024 14:43:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Nombre_Valor] [nvarchar](20) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[PasswordSalt] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240414233738_inicial', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240416221538_ProbandoNuevoNombre', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240416221700_NuevoNombreTablaUsuarios', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422172128_Avances', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422174109_Avances2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422174337_Avances3', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422200756_AgregarClientesABD', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240422201845_DireccionEnClientes', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240427165926_TodasLasTablas', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240506004053_probnado2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240511163726_AgregarPropiedadEstadoEnPedido', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240514233802_THELASTONE', N'8.0.4')
GO
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1122334455443, N'Funda Protectora Laptop', N'Funda para proteger tu computadora', 10, 1000)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1132345678914, N'Marcadores Sharpie', N'Marcadores', 5, 1000)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1231233214321, N'Mouse Logitech', N'Mouse para oficina', 40, 650)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1234567891012, N'Monitor 23 Pulgadas', N'Monitor para oficina', 100, 500)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1234567891234, N'Lapicera Bic', N'Lapicera tinta', 10, 1000)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1234567899999, N'Regla 30 centimetros', N'Regla multifuncion de 30 centimetros de largo', 15, 500)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (1242345678915, N'Paquete de Hojas A4', N'Paquete de hojas A4', 20, 1000)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (2222345678913, N'Cuaderno Espiral', N'Cuaderno espiral 100 hojas', 50, 400)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (2332322323231, N'Teclado Gamer', N'Teclado gamer', 100, 1000)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (6672345678918, N'Tijeras de oficina', N'Tijeras para oficina', 15, 1000)
INSERT [dbo].[Articulos] ([Codigo], [Nombre], [Descripcion], [Precio], [Stock]) VALUES (9876543211234, N'Auriculares Gamer', N'Auriculares Gamer Logitech', 100, 200)
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (1, 218677420019, N'Valentina Fernandez', 5, N'Bulevar', N'Montevideo', N'2428')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (2, 213799640012, N'Eduardo Recayte', 120, N'Mateo Vidal', N'Montevideo', N'3351')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (3, 214889040214, N'Papeleria Propios', 14, N'Bulevar Battle Ordonez', N'Montevideo', N'2323')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (5, 210998423415, N'Mosca Centro', 4, N'18 de Julio', N'Montevideo', N'1030')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (8, 215049343210, N'Papeleria Canelones', 101, N'Rivera', N'Canelones', N'1899')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (9, 212324353421, N'Papeleria Rio Negro', 300, N'Principal Av', N'Rio Negro', N'9082')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (10, 210342304212, N'Julio Rodriguez', 20, N'Av Italia', N'Montevideo', N'3024')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (11, 290234205321, N'Pepe Perez', 500, N'Artigas', N'Rivera', N'1032')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (12, 213023435203, N'Papeleria Pinar', 30, N'Av Lago', N'Canelones', N'2121')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [DistanciaKm], [Calle], [Ciudad], [Numero]) VALUES (13, 290948239412, N'Papeleria Roman', 10, N'Av Italia', N'Montevideo', N'3030')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (1, 1132345678914, 15, 5)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (1, 1234567891234, 10, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (1, 1242345678915, 20, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (3, 1242345678915, 5, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (4, 1234567891234, 2, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (5, 1234567891234, 7, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (6, 6672345678918, 2, 15)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (7, 2222345678913, 1, 50)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (8, 1242345678915, 1, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (10, 1234567891234, 1, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (10, 1234567899999, 10, 15)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (10, 1242345678915, 10, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (11, 1234567891234, 1, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (11, 1242345678915, 10, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (12, 1132345678914, 10, 5)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (12, 1234567891234, 10, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (12, 1234567899999, 18, 15)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (12, 1242345678915, 10, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (12, 2222345678913, 10, 50)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (13, 1234567891234, 12, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (13, 1242345678915, 100, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (14, 1242345678915, 10, 20)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (14, 2222345678913, 20, 50)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (15, 1234567891234, 10, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (16, 1234567891234, 10, 10)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (16, 2332322323231, 10, 100)
INSERT [dbo].[Lineas] ([PedidoId], [ArticuloId], [Cantidad], [PrecioUnitario]) VALUES (17, 1231233214321, 4, 40)
GO
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (1, CAST(N'2024-04-27' AS Date), 1, CAST(N'2024-04-29' AS Date), N'Express', 0, 771.65)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (3, CAST(N'2024-05-09' AS Date), 1, CAST(N'2024-05-19' AS Date), N'Comun', 0, 122)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (4, CAST(N'2024-05-09' AS Date), 2, CAST(N'2024-05-19' AS Date), N'Comun', 1, 25.619999999999997)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (5, CAST(N'2024-05-09' AS Date), 2, CAST(N'2024-05-11' AS Date), N'Express', 0, 98.210000000000008)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (6, CAST(N'2024-05-09' AS Date), 2, CAST(N'2024-05-12' AS Date), N'Express', 1, 40.260000000000005)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (7, CAST(N'2024-05-09' AS Date), 1, CAST(N'2024-05-13' AS Date), N'Express', 1, 67.1)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (8, CAST(N'2024-05-09' AS Date), 2, CAST(N'2024-05-10' AS Date), N'Comun', 0, 25.619999999999997)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (10, CAST(N'2024-05-11' AS Date), 1, CAST(N'2024-05-12' AS Date), N'Express', 0, 483.12)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (11, CAST(N'2024-05-11' AS Date), 1, CAST(N'2024-05-20' AS Date), N'Comun', 1, 256.2)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (12, CAST(N'2024-05-11' AS Date), 2, CAST(N'2024-05-13' AS Date), N'Express', 0, 1503.0400000000002)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (13, CAST(N'2024-05-12' AS Date), 2, CAST(N'2024-05-25' AS Date), N'Comun', 0, 2715.7200000000003)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (14, CAST(N'2024-05-12' AS Date), 2, CAST(N'2024-05-13' AS Date), N'Express', 0, 1610.4)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (15, CAST(N'2024-05-14' AS Date), 2, CAST(N'2024-05-24' AS Date), N'Comun', 1, 128.1)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (16, CAST(N'2024-05-16' AS Date), 5, CAST(N'2024-05-25' AS Date), N'Comun', 1, 1342)
INSERT [dbo].[Pedidos] ([Id], [Fecha], [ClienteId], [FechaEntregaPrometida], [TipoPedido], [Estado], [Precio]) VALUES (17, CAST(N'2024-05-16' AS Date), 13, CAST(N'2024-05-17' AS Date), N'Express', 1, 214.72)
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Email], [Nombre_Valor], [Apellido], [Password], [PasswordHash], [PasswordSalt]) VALUES (7, N'estebanrecayte@gmail.com', N'Esteban', N'Recayte', N'Esteban.1995', N'5GF9XdB7pLRbhc6xr4dt4/2br95+WR+/tssTGIHfY++/3PK2pD7mJau4IDtH3jy91psVIpEWY+pBKHysHBZ4+g==', N'h4gOrass7X4sdHwS0SSNk7zCBNmTU/o1A3ISnrYA9ZK6WDENw40klTObErcvRfrfO0wZpw5OZBAGiNuFhH7xivtQfruOcDftdP+LItpXY+WmSUYKwGxzGy6PdP7hFepPcfCTVWCo6oKw2RuBXfNAaKAW1oLb+qW4fgMmh3rt520=')
INSERT [dbo].[Usuarios] ([Id], [Email], [Nombre_Valor], [Apellido], [Password], [PasswordHash], [PasswordSalt]) VALUES (9, N'juan@gmail.com', N'Juan', N'Perez', N'Juan.1995', N'PWR9U7pkil5DHVQmPIlHl2YlXZT6yXny0HMEOdmKkwYFC8fwoF1ObONyW2lBJyX0IzI9v3TbaOVgi3mVBuY3NQ==', N'm9Ad/wzutMwuNWIF422PQmfLWe8sXZQNfji7OLMDEE+FvcjQdF2BE9nJcnWx0zbeGqVFAMVi9XcAP3INWqd95iac8FpK/4Wi/QWK/LnTwBp7PBuKM+JRxxNH5zpXQX6dBsOy+1RiLLk9hmyNZE1IhPToU0bV/B+wdD3qS1fkHSI=')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Lineas_ArticuloId]    Script Date: 16/5/2024 14:43:04 ******/
CREATE NONCLUSTERED INDEX [IX_Lineas_ArticuloId] ON [dbo].[Lineas]
(
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedidos_ClienteId]    Script Date: 16/5/2024 14:43:04 ******/
CREATE NONCLUSTERED INDEX [IX_Pedidos_ClienteId] ON [dbo].[Pedidos]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [Calle]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [Ciudad]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [Numero]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Estado]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Precio]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (N'') FOR [PasswordHash]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (N'') FOR [PasswordSalt]
GO
ALTER TABLE [dbo].[Lineas]  WITH CHECK ADD  CONSTRAINT [FK_Lineas_Articulos_ArticuloId] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulos] ([Codigo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lineas] CHECK CONSTRAINT [FK_Lineas_Articulos_ArticuloId]
GO
ALTER TABLE [dbo].[Lineas]  WITH CHECK ADD  CONSTRAINT [FK_Lineas_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lineas] CHECK CONSTRAINT [FK_Lineas_Pedidos_PedidoId]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes_ClienteId]
GO
