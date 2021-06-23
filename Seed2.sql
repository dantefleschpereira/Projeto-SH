  
use SecondHand

SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (1, N'Eletrônicos')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (2, N'Casa')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (3, N'Móveis')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (4, N'Esportes')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (5, N'Ferramentas')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Nome]) VALUES (6, N'Roupas')

SET IDENTITY_INSERT [dbo].[Categorias] OFF




INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'2dd54ce7-84b6-4af2-9d99-3c28e91a8671', NULL, 'Hugo', N'hugo@psa.br', N'HUGO@PSA.BR', N'hugo@psa.br', N'HUGO@PSA.BR', 1, N'AQAAAAEAACcQAAAAEJHjpLbX33jJycOhiQNqkuZ/SxkEqtS99Z08lOHxwXCt0xzGWS9Vm892sqKXsbR8Rw==', N'LIZ2BH7WKJKFH5EOI5KNYGUU7Y36RW2A', N'1142d987-44c5-4d33-9c12-90bad15da75a', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'67b24e7e-cfe2-448d-8e2d-8081b429fe1d', NULL, 'Ze', N'admin@psa.br', N'ADMIN@PSA.BR', N'admin@psa.br', N'ADMIN@PSA.BR', 1, N'AQAAAAEAACcQAAAAEGLvWHqnptSTqfcpblpMh+TwXFDwFtex7GPG8G1XBcY85/zA+GcBud2BtR3cDYJl4A==', N'EOHWGEUYCH52ASK7JHUV4YGCTMUPUUI6', N'e45ce73e-7708-4967-afd0-11b19847cb15', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetUsers] ([Id], [CPF], [Nome], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES (N'a39c5dc3-196a-4460-828c-900f0096925a', NULL, 'Luis', N'luis@psa.br', N'LUIS@PSA.BR', N'luis@psa.br', N'LUIS@PSA.BR', 1, N'AQAAAAEAACcQAAAAEMfAo6pVQv20i/Waqh5wDugBnLtyYk/YUhEQTZtFmWWfszmQUf6tmoxIJaGyg9S5ww==', N'2B6TUYFP4YX2JVZOEICWO2XTKXF3YLL4', N'2c699072-b3ed-44e4-8d01-71b446d925bc', NULL, 0, 0, NULL, 1, 0)



INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6a1bbd8e-edef-42d2-949a-605644cefac0', N'Vendedor', N'VENDEDOR', N'6772569e-e01e-4d92-94e1-93204be1e552')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'802e0cb6-f784-4da3-b618-8f485dae6cbe', N'Administrador', N'ADMINISTRADOR', N'e783c050-a385-4a69-a251-dc4eb62e65c9')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a0720860-932d-43d3-a967-42cc3100f66f', N'Comprador', N'COMPRADOR', N'39ad851b-1cff-4380-b63e-31101c18383f')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2dd54ce7-84b6-4af2-9d99-3c28e91a8671', N'a0720860-932d-43d3-a967-42cc3100f66f')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a39c5dc3-196a-4460-828c-900f0096925a', N'6a1bbd8e-edef-42d2-949a-605644cefac0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'67b24e7e-cfe2-448d-8e2d-8081b429fe1d', N'802e0cb6-f784-4da3-b618-8f485dae6cbe')

