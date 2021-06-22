﻿  
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
VALUES (1, N'Iphone', N'Celular Iphone cor gold', CAST(279.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (2, N'Ipad', N'Tablet Apple cor branca', CAST(199.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (3, N'Tv', N'Tv da marca Sony cor preta', CAST(200.00 AS Decimal(18, 2)), 1, 1, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (4, N'Mesa', N'Mesa de madeira redonda para 6 pessoas', CAST(500.00 AS Decimal(18, 2)), 1, 3,N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (5, N'Cadeira', N'Cadeira de madeira na cor preta', CAST(50.00 AS Decimal(18, 2)), 1, 3, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (6, N'Porta', N'Porta de madeira na cor branca', CAST(350.00 AS Decimal(18, 2)), 1, 3, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (7, N'Cadeira', N'Cadeira de ferro na cor branca', CAST(40.00 AS Decimal(18, 2)), 1, 3, N'Porto Alegre', 1, NULL)

INSERT INTO [dbo].[Produtos] ([ProdutoId], [Nome], [Descricao], [Preco], [Status], [CategoriaID], [Cidade], [UsuarioId], [DataVenda]) 
VALUES (8, N'Prancha de surf', N'Prancha da marca Tri Coast', CAST(400.00 AS Decimal(18, 2)), 1, 4, N'Porto Alegre', 1, NULL)

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


INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2dd54ce7-84b6-4af2-9d99-3c28e91a8671', NULL, 'Hugo', N'comprador@psa.br', N'COMPRADOR@PSA.BR', N'comprador@psa.br', N'COMPRADOR@PSA.BR', 1, N'AQAAAAEAACcQAAAAEJHjpLbX33jJycOhiQNqkuZ/SxkEqtS99Z08lOHxwXCt0xzGWS9Vm892sqKXsbR8Rw==', N'LIZ2BH7WKJKFH5EOI5KNYGUU7Y36RW2A', N'1142d987-44c5-4d33-9c12-90bad15da75a', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'67b24e7e-cfe2-448d-8e2d-8081b429fe1d', NULL, 'Ze', N'admin@psa.br', N'ADMIN@PSA.BR', N'admin@psa.br', N'ADMIN@PSA.BR', 1, N'AQAAAAEAACcQAAAAEGLvWHqnptSTqfcpblpMh+TwXFDwFtex7GPG8G1XBcY85/zA+GcBud2BtR3cDYJl4A==', N'EOHWGEUYCH52ASK7JHUV4YGCTMUPUUI6', N'e45ce73e-7708-4967-afd0-11b19847cb15', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a39c5dc3-196a-4460-828c-900f0096925a', NULL, 'Luis', N'vendedor@psa.br', N'VENDEDOR@PSA.BR', N'vendedor@psa.br', N'VENDEDOR@PSA.BR', 1, N'AQAAAAEAACcQAAAAEMfAo6pVQv20i/Waqh5wDugBnLtyYk/YUhEQTZtFmWWfszmQUf6tmoxIJaGyg9S5ww==', N'2B6TUYFP4YX2JVZOEICWO2XTKXF3YLL4', N'2c699072-b3ed-44e4-8d01-71b446d925bc', NULL, 0, 0, NULL, 1, 0)



INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6a1bbd8e-edef-42d2-949a-605644cefac0', N'Vendedor', N'VENDEDOR', N'6772569e-e01e-4d92-94e1-93204be1e552')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'802e0cb6-f784-4da3-b618-8f485dae6cbe', N'Administrador', N'ADMINISTRADOR', N'e783c050-a385-4a69-a251-dc4eb62e65c9')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a0720860-932d-43d3-a967-42cc3100f66f', N'Comprador', N'COMPRADOR', N'39ad851b-1cff-4380-b63e-31101c18383f')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2dd54ce7-84b6-4af2-9d99-3c28e91a8671', N'a0720860-932d-43d3-a967-42cc3100f66f')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a39c5dc3-196a-4460-828c-900f0096925a', N'6a1bbd8e-edef-42d2-949a-605644cefac0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'67b24e7e-cfe2-448d-8e2d-8081b429fe1d', N'802e0cb6-f784-4da3-b618-8f485dae6cbe')

