﻿use SecondHand



SET IDENTITY_INSERT [dbo].[Produtos] ON
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [StatusVenda], [CategoriaID], [CidadeId], [CompradorId], [VendedorID]) 
VALUES (1, N'Iphone', N'Celular Iphone cor Gold', CAST(2179.00 AS Decimal(18, 2)), 1, 1, 1, 1, 2)

SET IDENTITY_INSERT [dbo].[Produtos] OFF