use SecondHand

SET IDENTITY_INSERT [dbo].[Enderecos] ON
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (1, 90619-900, N'Ipiranga', 6681, N'Prédio 30', N'Partenon', 1)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (2, 90550-070, N'Nova York', 72, N'01', N'Auxiliadora', 1)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (3, 95670-000, N'Borges de Medeiros', 2497, N'Bloco B', N'Centro', 6)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (4, 95670-000, N'Tristão Oliveira', 1200, N'Apt 505', N'Floresta', 6)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (5, 95670-000, N'Borges de Medeiros', 2771, N'Casa 1', N'Centro', 6)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (6, 95555-000, N'Ubirajara', 646, N'Casa', N'Centro', 5)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (7, 95555-000, N'Paraguassu', 2934, N'Casa', N'Centro', 5)
INSERT INTO [dbo].[Enderecos] ([EnderecoId], [Cep], [Rua], [Número], [Complemento], [Bairro], [CidadeId]) VALUES (8, 90550-070, N'Nova York', 82, N'Apt 801', N'Auxiliadora', 1)

SET IDENTITY_INSERT [dbo].[Enderecos] OFF