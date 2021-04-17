use SecondHand

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuarioId]) VALUES (1, N'Aline Riscado', N'aline@gmail.com', 4321, 2, 1)
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha], [EnderecoId], [TipoUsuarioId]) VALUES (2, N'Neymar da Silva Santos Júnior', N'ney@gmail.com', 1234, 1,2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF