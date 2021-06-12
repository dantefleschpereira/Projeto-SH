  
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

SET IDENTITY_INSERT [dbo].[Usuarios] OFF


SET IDENTITY_INSERT [dbo].[Produtos] ON

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (1, N'Iphone', N'Celular Iphone cor gold', CAST(279.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 1, CAST(N'2021-01-18 10:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (2, N'Ipad', N'Tablet Apple cor branca', CAST(199.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 1, CAST(N'2021-02-21 09:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (3, N'Tv', N'Tv da marca Sony cor preta', CAST(200.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (4, N'Mesa', N'Mesa de madeira redonda para 6 pessoas', CAST(500.00 AS Decimal(18, 2)), 1, 3,N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (5, N'Cadeira', N'Cadeira de madeira na cor preta', CAST(50.00 AS Decimal(18, 2)), 1, 3, N'Porto Alegre', 1, CAST(N'2021-02-15 08:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (6, N'Porta', N'Porta de madeira na cor branca', CAST(350.00 AS Decimal(18, 2)), 1, 3, N'Porto Alegre', 1, CAST(N'2021-02-10 07:34:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (7, N'Cadeira', N'Cadeira de ferro na cor branca', CAST(40.00 AS Decimal(18, 2)), 1, 3, N'Porto Alegre', 1, CAST(N'2021-02-09 10:14:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (8, N'Prancha de surf', N'Prancha da marca Tri Coast', CAST(400.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, CAST(N'2021-01-18 11:38:09.000' AS DateTime))

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (9, N'Camisa do Barcelona', N'Camisa do time Barcelona com número 10', CAST(150.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (10, N'Camisa do Vancouver Canucks', N'Camisa do time de hockey com número 88', CAST(250.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (11, N'Prancha de snowboard', N'Prancha da marca Burton', CAST(500.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (12, N'Skate', N'Skate da marca Drop Dead', CAST(400.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (13, N'Bola de futebol', N'Bola de futebol da marca Adidas na cor branca', CAST(100.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, NULL)


SET IDENTITY_INSERT [dbo].[Produtos] OFF
