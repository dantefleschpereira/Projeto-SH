use SecondHand

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (1, N'Aline Riscado', N'aline@gmail.com', N'4321', 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (2, N'Neymar da Silva Santos Júnior', N'ney@gmail.com', N'1234', 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (3, N'Elon Musk', N'musk@tesla.com', N'1234', 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (4, N'Bruna Marquezine', N'bruna@gmail.com', N'1234', 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (5, N'Keanu Charles Reeves', N'keanu@yahoo.com', N'1234',1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (6, N'Jennifer Lawrence', N'jen@yahoo.com', N'1234',1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (7, N'Sophie Turner', N'sophie@yahoo.com', N'1234', 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [TipoUsuario]) VALUES (8, N'admin@psa.br', N'admin@psa.br', N'Admin@psa',2)


SET IDENTITY_INSERT [dbo].[Usuarios] OFF