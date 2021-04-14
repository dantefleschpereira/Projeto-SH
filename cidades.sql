use SecondHand

SET IDENTITY_INSERT [dbo].[Cidades] ON
INSERT INTO [dbo].[Cidades] ([CidadeId], [Nome]) VALUES (1, N'Porto Alegre')
INSERT INTO [dbo].[Cidades] ([CidadeId], [Nome]) VALUES (2, N'Canoas')
INSERT INTO [dbo].[Cidades] ([CidadeId], [Nome]) VALUES (3, N'Novo Hamburgo')
INSERT INTO [dbo].[Cidades] ([CidadeId], [Nome]) VALUES (4, N'Esteio')
INSERT INTO [dbo].[Cidades] ([CidadeId], [Nome]) VALUES (5, N'Capão da Canoa')
INSERT INTO [dbo].[Cidades] ([CidadeId], [Nome]) VALUES (6, N'Gramado')

SET IDENTITY_INSERT [dbo].[Cidades] OFF