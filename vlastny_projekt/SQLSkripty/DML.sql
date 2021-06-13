USE [projekt]
GO
SET IDENTITY_INSERT [dbo].[Transakcie_Typ] ON 

INSERT [dbo].[Transakcie_Typ] ([ID],[nazov]) VALUES (1,N'Predaj')
INSERT [dbo].[Transakcie_Typ] ([ID],[nazov]) VALUES (2,N'Reklamacia')
INSERT [dbo].[Transakcie_Typ] ([ID],[nazov]) VALUES (3,N'Oprava')

SET IDENTITY_INSERT [dbo].[Transakcie_Typ] OFF 

SET IDENTITY_INSERT [dbo].[Vyrobca] ON

INSERT [dbo].[Vyrobca] ([ID],[meno]) VALUES (1,N'Bauer')
INSERT [dbo].[Vyrobca] ([ID],[meno]) VALUES (2,N'Slovensky stavatelia')
INSERT [dbo].[Vyrobca] ([ID],[meno]) VALUES (3,N'Vsetok nabytok')
INSERT [dbo].[Vyrobca] ([ID],[meno]) VALUES (4,N'Kuchyne za euro')
INSERT [dbo].[Vyrobca] ([ID],[meno]) VALUES (5,N'Ciste kupelne')
INSERT [dbo].[Vyrobca] ([ID],[meno]) VALUES (6,N'Vsetko do garaze')

SET IDENTITY_INSERT [dbo].[Vyrobca] OFF