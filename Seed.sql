use SecondHand

SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (1, N'Eletrônicos')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (2, N'Casa')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (3, N'Móveis')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (4, N'Esportes')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (5, N'Ferramentas')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (6, N'Brinquedos')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (7, N'Roupas')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (8, N'Peças')
SET IDENTITY_INSERT [dbo].[Categorias] OFF


SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (1, N'Aline Riscado', N'aline@gmail.com', N'4321')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (2, N'Neymar da Silva Santos Júnior', N'ney@gmail.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (3, N'Elon Musk', N'musk@tesla.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (4, N'Bruna Marquezine', N'bruna@gmail.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (5, N'Keanu Charles Reeves', N'keanu@yahoo.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (6, N'Jennifer Lawrence', N'jen@yahoo.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (7, N'Sophie Turner', N'sophie@yahoo.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Nome], [email], [senha]) VALUES (8, N'admin@psa.br', N'admin@psa.br', N'Admin@psa')

SET IDENTITY_INSERT [dbo].[Usuarios] OFF


SET IDENTITY_INSERT [dbo].[Produtos] ON

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioID], [DataVenda]) 
VALUES (1, N'Iphone', N'Celular Iphone cor gold', CAST(2179.00 AS Decimal(18, 2)), 2, 1, N'Porto Alegre', 1, CAST(N'2021-01-18 10:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (2, N'Ipad', N'Tablet Apple cor branca', CAST(1199.00 AS Decimal(18, 2)), 2, 1, N'Gramado', 1, CAST(N'2021-02-21 09:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (3, N'Tv', N'Tv da marca Sony cor preta', CAST(1200.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 5, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (4, N'Mesa', N'Mesa de madeira redonda para 6 pessoas', CAST(800.00 AS Decimal(18, 2)), 3, 3, N'Capão da Canoa', 6, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (5, N'Cadeira', N'Cadeira de madeira na cor preta', CAST(50.00 AS Decimal(18, 2)), 2, 3, N'Capão da Canoa', 6, CAST(N'2021-02-15 08:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (6, N'Porta', N'Porta de madeira na cor branca', CAST(350.00 AS Decimal(18, 2)), 2, 3, N'Capão da Canoa', 6, CAST(N'2021-02-10 07:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (7, N'Cadeira', N'Cadeira de ferro na cor branca', CAST(40.00 AS Decimal(18, 2)), 2, 3, N'Porto Alegre', 4, CAST(N'2021-02-09 10:14:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (8, N'Prancha de surf', N'Prancha da marca Tri Coast', CAST(1000.00 AS Decimal(18, 2)), 2, 4, N'Capão da Canoa', 6, CAST(N'2021-01-18 11:38:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (9, N'Camisa do Barcelona', N'Camisa do time Barcelona com número 10', CAST(150.00 AS Decimal(18, 2)), 1, 4, N'Gramado', 2, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (10, N'Camisa do Vancouver Canucks', N'Camisa do time de hockey com número 88', CAST(250.00 AS Decimal(18, 2)), 1, 4, N'Gramado', 3, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (11, N'Prancha de snowboard', N'Prancha da marca Burton', CAST(500.00 AS Decimal(18, 2)), 1, 4, N'Capão da Canoa', 6, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (12, N'Skate', N'Skate da marca Drop Dead', CAST(400.00 AS Decimal(18, 2)), 1, 4, N'Capão da Canoa', 6, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (13, N'Bola de futebol', N'Bola de futebol da marca Adidas na cor branca', CAST(100.00 AS Decimal(18, 2)), 3, 4, N'Capão da Canoa', 6, NULL)


SET IDENTITY_INSERT [dbo].[Produtos] OFF