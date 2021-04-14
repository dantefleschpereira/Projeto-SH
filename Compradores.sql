use SecondHand

SET IDENTITY_INSERT [dbo].[Compradores] ON
INSERT INTO [dbo].[Compradores] ([CompradorId], [Nome], [email], [senha], [EnderecoId]) VALUES (1, N'Aline Riscado', N'aline@gmail.com', 4321, 2)

SET IDENTITY_INSERT [dbo].[Compradores] OFF