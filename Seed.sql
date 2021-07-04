  
use SecondHand

SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (1, N'Eletrônicos')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (2, N'Móveis')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (3, N'Esportes')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (4, N'Ferramentas')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (5, N'Roupas')

SET IDENTITY_INSERT [dbo].[Categorias] OFF


INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'28ac4b25-2483-4d53-8e08-a5b196e70022', NULL, N'Ze', N'ze@psa.br', N'ZE@PSA.BR', N'ze@psa.br', N'ZE@PSA.BR', 1, N'AQAAAAEAACcQAAAAEGmCMAYaMET8urNb919UjpK/JYhmh2Ak6lby3pKj+tLGn+IEwYnDH3VyGM4aL/MIhg==', N'QTQLK3FTUAV2BVKQFI7QRF54TLQGBQO7', N'a488b5a3-504e-419e-8567-735b9784281f', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'c225d294-09aa-4f3f-b419-b848915d4490', NULL, N'Luis', N'luis@psa.br', N'LUIS@PSA.BR', N'luis@psa.br', N'LUIS@PSA.BR', 1, N'AQAAAAEAACcQAAAAEBdd9tM0itwxB/faqzz3r4BEa3VnNp3AQ/8oBGi570rXVmkpFGBmgm6lKNP2J1wFTA==', N'3WXFDMULGDNKRGVK4ZDIL437W2QQDSSU', N'939b3534-bd96-49bd-8724-f7e2b71fef0c', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'd627f772-b711-4cf4-8999-5c587c21a5d1', NULL, N'Hugo', N'hugo@psa.br', N'HUGO@PSA.BR', N'hugo@psa.br', N'HUGO@PSA.BR', 1, N'AQAAAAEAACcQAAAAEDhHsltbHxitkvIMom89Skc8ug2qNr3bYKQdhdXqnxRzH6rFh2LKZh2vX3cU07NPMg==', N'RCMXDOPQDLU6KFBADMAMSHA54JLOYDNR', N'9c430a98-27a7-498d-8927-86f50b307195', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'67b24e7e-cfe2-448d-8e2d-8081b429fe1d', NULL, 'Admin', N'admin@psa.br', N'ADMIN@PSA.BR', N'admin@psa.br', N'ADMIN@PSA.BR', 1, N'AQAAAAEAACcQAAAAEGmCMAYaMET8urNb919UjpK/JYhmh2Ak6lby3pKj+tLGn+IEwYnDH3VyGM4aL/MIhg==', N'EOHWGEUYCH52ASK7JHUV4YGCTMUPUUI6', N'e45ce73e-7708-4967-afd0-11b19847cb15', NULL, 0, 0, NULL, 1, 0)




INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6a1bbd8e-edef-42d2-949a-605644cefac0', N'User', N'USER', N'6772569e-e01e-4d92-94e1-93204be1e552')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'802e0cb6-f784-4da3-b618-8f485dae6cbe', N'Administrador', N'ADMINISTRADOR', N'e783c050-a385-4a69-a251-dc4eb62e65c9')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'67b24e7e-cfe2-448d-8e2d-8081b429fe1d', N'802e0cb6-f784-4da3-b618-8f485dae6cbe')


SET IDENTITY_INSERT [dbo].[Produtos] ON
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (1, N'Iphone 6', N'Celular Apple na cor gold', CAST(950.00 AS Decimal(18, 2)), 0, 1, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Hugo', N'd627f772-b711-4cf4-8999-5c587c21a5d1')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (2, N'Bola', N'Bola marca Topper de cor branca', CAST(120.00 AS Decimal(18, 2)), 0, 3, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Hugo', N'd627f772-b711-4cf4-8999-5c587c21a5d1')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (3, N'Skate', N'Marca DropDead em bom estado', CAST(150.00 AS Decimal(18, 2)), 0, 3, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Hugo', N'd627f772-b711-4cf4-8999-5c587c21a5d1')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (4, N'Mesa', N'Mesa redonda de madeira', CAST(180.00 AS Decimal(18, 2)), 0, 2, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Luis', N'c225d294-09aa-4f3f-b419-b848915d4490')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (5, N'TV', N'Marca Sony cor preta', CAST(900.00 AS Decimal(18, 2)), 0, 1, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Luis', N'c225d294-09aa-4f3f-b419-b848915d4490')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (6, N'Camisa do Barcelona', N'Camisa número 11 do Neymar', CAST(250.00 AS Decimal(18, 2)), 0, 3, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Luis', N'c225d294-09aa-4f3f-b419-b848915d4490')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (7, N'Ipad Mini', N'Ipad Apple na cor branca', CAST(1200.00 AS Decimal(18, 2)), 0, 1, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Ze', N'28ac4b25-2483-4d53-8e08-a5b196e70022')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (8, N'Camisa de Hockey', N'Camisa do time Canucks na cor azul', CAST(260.00 AS Decimal(18, 2)), 0, 3, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Ze', N'28ac4b25-2483-4d53-8e08-a5b196e70022')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (9, N'Porta', N'Porta na cor branca de madeira', CAST(180.00 AS Decimal(18, 2)), 0, 2, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Ze', N'28ac4b25-2483-4d53-8e08-a5b196e70022')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaId], [Cidade], [UsuarioId], [DataVenda], [NomeComprador], [IdComprador], [NomeVendedor], [IdVendedor]) VALUES (10, N'Cadeira', N'Cadeira de ferro na cor branca', CAST(90.00 AS Decimal(18, 2)), 0, 2, N'Porto Alegre', NULL, NULL, NULL, NULL, N'Ze', N'28ac4b25-2483-4d53-8e08-a5b196e70022')
SET IDENTITY_INSERT [dbo].[Produtos] OFF
