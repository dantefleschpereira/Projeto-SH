use SecondHand

SET IDENTITY_INSERT [dbo].[Enderecos] ON
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (1, 90619-900, N'Av. Ipiranga', 6681, N'Prédio 30', N'Partenon', 1)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (2, 90550-070, N' Av. Nova York', 72, N'01', N'Auxiliadora', 1)


SET IDENTITY_INSERT [dbo].[Enderecos] OFF