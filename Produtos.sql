use SecondHand



SET IDENTITY_INSERT [dbo].[Produtos] ON
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [CidadeId], [CompradorId], [VendedorID]) 
VALUES (1, N'Iphone', N'Celular Iphone cor gold', CAST(2179.00 AS Decimal(18, 2)), 1, 1, 1, 1, 2)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [CidadeId], [CompradorId], [VendedorID]) 
VALUES (2, N'Ipad', N'Tablet Apple cor branca', CAST(1199.00 AS Decimal(18, 2)), 2, 1, 6, 1, 3)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [CidadeId], [CompradorId], [VendedorID]) 
VALUES (3, N'Tv', N'Tv da marca Sony cor preta', CAST(1200.00 AS Decimal(18, 2)), 1, 1, 6, 5, 4)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [CidadeId], [CompradorId], [VendedorID]) 
VALUES (4, N'Mesa', N'Mesa de madeira redonda para 6 pessoas', CAST(800.00 AS Decimal(18, 2)), 3, 3, 1, 6, 7)


SET IDENTITY_INSERT [dbo].[Produtos] OFF