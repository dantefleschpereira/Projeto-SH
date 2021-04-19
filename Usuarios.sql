use SecondHand

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (1, N'Aline Riscado', N'aline@gmail.com', N'4321', 8, 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (2, N'Neymar da Silva Santos Júnior', N'ney@gmail.com', N'1234', 2,1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (3, N'Elon Musk', N'musk@tesla.com', N'1234', 3,1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (4, N'Bruna Marquezine', N'bruna@gmail.com', N'1234', 4,1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (5, N'Keanu Charles Reeves', N'keanu@yahoo.com', N'1234', 5,1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (6, N'Jennifer Lawrence', N'jen@yahoo.com', N'1234', 6,1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (7, N'Sophie Turner', N'sophie@yahoo.com', N'1234', 7,1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuario]) VALUES (8, N'admin@psa.br', N'admin@psa.br', N'Admin@psa', 1,2)


SET IDENTITY_INSERT [dbo].[Usuarios] OFF