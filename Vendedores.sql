use SecondHand

SET IDENTITY_INSERT [dbo].[Vendedores] ON
INSERT INTO [dbo].[Vendedores] ([VendedorId], [Nome], [email], [senha], [EnderecoId]) VALUES (1, N'Neymar da Silva Santos Júnior', N'ney@gmail.com', 1234, 1)

SET IDENTITY_INSERT [dbo].[Vendedores] OFF