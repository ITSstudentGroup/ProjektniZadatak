
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BrojeviTelefona]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BrojeviTelefona](
	[Id] [int] NOT NULL,
	[RedniBr] [int] IDENTITY(1,1) NOT NULL,
	[Broj] [varchar](50) NOT NULL,
	[Lokal] [varchar](10) NULL,
	[OznakaId] [int] NULL,
 CONSTRAINT [PK__BrojeviT__69785652C98A45D9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RedniBr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MailAdrese]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MailAdrese](
	[Id] [int] NOT NULL,
	[RedniBr] [int] IDENTITY(1,1) NOT NULL,
	[Adresa] [varchar](50) NOT NULL,
	[OznakaId] [int] NULL,
 CONSTRAINT [PK__MailAdre__69785652364B3E2C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RedniBr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Osoba]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Osoba](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](150) NOT NULL,
	[Prezime] [varchar](150) NOT NULL,
	[ImeRoditelja] [varchar](150) NOT NULL,
	[JMBG] [numeric](13, 0) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[MestoRodjenja] [varchar](150) NOT NULL,
	[OpstinaRodjenja] [varchar](150) NOT NULL,
	[Pol] [char](1) NOT NULL,
	[BrojLicneKarte] [numeric](9, 0) NOT NULL,
	[Beleska] [text] NULL,
	[Fotografija] [text] NULL,
 CONSTRAINT [PK_Osoba] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OznakaMaila]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OznakaMaila](
	[Id] [int] NOT NULL,
	[Oznaka] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OznakaMaila] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OznakaPostanskeAdrese]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OznakaPostanskeAdrese](
	[Id] [int] NOT NULL,
	[Oznaka] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OznakaPostanskeAdrese] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OznakaTelefona]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OznakaTelefona](
	[Id] [int] NOT NULL,
	[Oznaka] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OznakaTelefona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PostanskeAdrese]    Script Date: 25.3.2017 17:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PostanskeAdrese](
	[Id] [int] NOT NULL,
	[RedniBr] [int] IDENTITY(1,1) NOT NULL,
	[Adresa] [varchar](50) NOT NULL,
	[PostanskiBroj] [varchar](15) NOT NULL,
	[Grad] [varchar](50) NOT NULL,
	[OznakaId] [int] NULL,
 CONSTRAINT [PK__Postansk__6978565241A1791D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RedniBr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201703101429279_InitialCreate', N'Projekat.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE336167E5F60FF83A0A7DD456AE5D2194C037B06A993EC069D5C30CE147D1BD012ED6847A254894A1314FD657DE84FEA5FE8A144C9E24D175BB19DA24031160F3F1E1E7E240F0F0FF3E7EF7F8C3F3C8581F58893D48FC8C43E1A1DDA16266EE4F96439B133BAF8E69DFDE1FD3FFF31BEF0C227EBC752EE84C9414D924EEC074AE353C749DD071CA27414FA6E12A5D1828EDC2874901739C78787DF3947470E06081BB02C6BFC2923D40F71FE037E4E23E2E2986628B88E3C1CA4FC3B94CC7254EB0685388D918B27F65D12FD1F7F45745488DAD659E02350638683856D2142228A282879FA39C5339A4464398BE1030AEE9F630C720B14A4982B7FBA12EFDA8FC363D60F6755B18472B39446614FC0A3136E1847AEBE9679EDCA7060BA0B30317D66BDCECD37B1AF3C9C7FFA14056000B9C1D3699030E1897D5D357196C637988ECA8AA302F23201B85FA2E4EBA88E786075AE775011E97874C8FE3BB0A65940B3044F08CE68828203EB2E9B07BEFB037EBE8FBE623239399A2F4EDEBD798BBC93B7DFE29337F59E425F414EF8009F8027314E4037BCA8FA6F5B8E58CF912B56D56A750AAB0097604ED8D6357AFA88C9923EC06C397E675B97FE13F6CA2F9C5C9F890F53082AD124839F375910A07980AB72A7B14DF6FF86568FDFBC1DA4D51BF4E82FF3A197DA878993C0BCFA8483BC347DF0E3627A09E3FD858B5D2651C87E8BFC2A4ABFCCA22C71596722A3C83D4A96988ADA8D9D15793B519A410D4FEB1275FFA9CD3455E9AD15651D5A6726944D6C7B3694FABE6CBB9D197716C7307839B598459A0827ED5423A92A10810BAC4873D49534043AF3775E032F42E407032C821D5A01E763E12721AE7AF97D049443A4B7CE77284D610DF0FE87D28706D5E19F03A83EC36E960035671485F18BB776F710117C938573C6F8EDB535D8D0DCFF125D229746C90561B536C6FB18B95FA38C5E10EF1C51FC99BA2520FB79EF87DD010651E7CC75719A5E0299B1378DC0B72E01AF083D39EE0DC756A75D3B21D300F9A1DE0B91D6D12FA5E8CA13D14B28DE88414CE79134A9FA315AFAA49BAAA5A859D542A255552ED6575506D64D532E6956341768D5B3901ACCC7CB476878272F87DD7F2F6FB3CDDBB416D4CC38831512FF17139CC032E6DD214A71425623D065DDD885B3900F1F6BF4C5F7A6BCA51F51900DDDD45AB3215F04869F0D39ECFECF865C4DF8FCE87BCC2BE970F4298501BE93BCFE54D53EE724CDB63D1D846E6EBBF1EDAC01A6E97296A691EBE7B34013F4E2210B517FF0E1ACF6F845D11B3906021D03A2FB6CCB832FD0375B26D52D39C701A6D83A738BA0E014A52EF254334287BC1E8A953BAA46B1552C4454EE3F4A9BC0749CB04A881D825298A93EA1EAB4F089EBC72868B59254B3E316C6FA5EB521979CE31813D660AB25BA34AE0F7D3005AA76A44169B3D0D8A931AE998806AFD534E66D2EEC6ADC9588C45638D9E23B1B78C9FDB7172166B3C5B640CE66937451C018C6DB0541F959A52B01E483CBBE11543A311908CA5DAAAD1054B4D80E082A9AE4D511B438A2761D7FE9BCBA6FF4140FCADBDFD61BCDB5036E0AF6D8336A16BE27D4A15003272A3DCFE7AC103F51CDE10CF4E4E7B394BBBA324518F80C533164B3F277B57EA8D30C2293A8097045B416507E01A8002913AA8772652CAF513BEE45F4802DE36E8DB07CED97606B1C50B1EB17A13541F375A94CCE4EA78FAA67151B1492773A2CD470348490172FB1E31D8C628ACBAA86E9E20BF7F1866B1DE383D160A016CFD560A4B233835BA9A466BB95740E591F976C232B49EE93C14A656706B712E768BB91344E410FB7602313895BF84093AD8C7454BB4D5536768AE428FE61EC18B2A8C6D7288E7DB2AC6555F12FD6AC48A99A7E33EB9F6E1416188E9B6AB28E2A6DAB966894A025964AA169D0F4D24F527A8E289A2316E7997AA122A6DD5B0DCB7FD9647DFB5407B1DC074A69F6EF2A7C265CDB0B1BADEA8970804BE85EC8DC993C86AE197C7D758BA5B8A100259AB0FD340AB29098BD2B73EDE2F2AE5EBFF8A2228C1D497FC57B524CA5F8B8A2DD3B8D8A3A238618A1CA73597F94CC10265B977E67DDDA265FD48C5286A6EA28A670D5CE46CDE4C2741F29D935EC3F50AD082F33A3783E4A1D807FEA89514B6950C06A65DD51C5AC933AA658D21D514A2DA9434A453DB4AC2790084AD60BD6C23358542FD1BD053565A48EAE967647D6248FD4A135C56B606B7496CBBAA36AF24BEAC09AE2EED8AB64137905DDE33DCB7860596FD32A0EB49BED5A068C97590E87D9F46AF7F675A0DAE79E58FC665E01E3DFF7924AC653DD7A542A82189B51C980615E7384EB6E71C969BCA337630A77D8C2B2DE74876FC6EB47D817A58572A29345AAD6AB939D74821BF3D354FB6319E5785588D8566946D8D29F538AC3111318CD7E0EA6818FD9025E0A5C23E22F704A8BBC0DFBF8F0E8587A72B33FCF5F9C34F502CD69D4F406461CB32DA460914794B80F28511322367822B2025562CD57C4C34F13FBD7BCD6691EB660FFCA3F1F5857E967E2FF9C41C17D9261EB3735C1739894F9E6B3D59E3E70E86ED5AB9FBE14550FACDB0466CCA97528D9729D11169F3DF4D2A6A8BA81366B3F8678BD134A786FA0459526C4FACF0BE63E1DE46941A9E5BF42F4F4EFBEAA699F0F6C84A879223014DE2026343D015807CB98FEEFC14F9AA7FFF7EBACFE39C03AAA199F02F8A43F98FC10A0FB3254D6DCE156A339106D6349CAEDDC9A48BD5156E5AEF72625DF7AA389AEE654F780DB206F7A0D66BCB294E3C176474D46F160D8BBA4F68BA711EF4BE6F02AA763B709C3DBCC116EB80DFA5BA506EF41329B263967F709C0DBE69A2988BBE75994FDD27CF78C6C3C656BF7C9BCDB269B29CCBBE764EB95B2BB675CDBD5FEB963A675DE42779E80ABE612192E6374B1E0B604DB22700E27FC790424283CCAE25DA43EA3AB291BB5A5C19588B951732A99DCB0327194761589E666FBF5956FF88D9DE532CDCD1A12309BDAE6EB7F63DB5CA6B96D435AE32E5283B58985BA74ED9675AC29F7E935A5020B3D69C93C6FF3591B6FD65F53E6EF204611668FE18EF8F524FA0E629221A74E8FC45EF5BA17F6CEDA5F5084FD3BF5972B08F6F7140976855DB392B9228BA8DCBC258D4A112942738D29F2604B3D4BA8BF402E85621663CE1F76E7713B76D331C7DE15B9CD689C51E8320EE78110F0624E4053FB79F6B2A8F3F836CEFF46C9105D00357D169BBF25DF677EE0557A5F6A62420608E65DF0882E1B4BCA22BBCBE70AE926221D81B8F92AA7E81E87710060E92D99A147BC8E6E40BF8F7889DCE75504D004D23E10A2D9C7E73E5A26284C39C6AA3EFC040E7BE1D3FBBF0065400B1D48540000, N'6.1.3-40302')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'17576130-ef40-4ca8-a4d4-beda728fa61e', N'admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'55716eaa-c4ed-4b5d-8c26-79634ad0475d', N'editor')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'41ef198d-6006-4987-a523-360835ee2517', N'viewer')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab8cdb88-c2f8-45cc-8f90-db8992b8f97c', N'17576130-ef40-4ca8-a4d4-beda728fa61e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9ee1fe2b-0fbe-4479-9a3a-58c3e19bc365', N'41ef198d-6006-4987-a523-360835ee2517')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b57108cd-b788-4598-8d7c-6f72e63e4b9e', N'55716eaa-c4ed-4b5d-8c26-79634ad0475d')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9ee1fe2b-0fbe-4479-9a3a-58c3e19bc365', N'viewer@projekat.com', 0, N'AKuYncbjzBxIpdldddLfl5DfBf1WfWRytdLm/pwThYY+bSwfxpxSVBbWSI3IBCHnhQ==', N'40cd1790-71ce-4da8-a3f5-6cdda83f1aa2', NULL, 0, 0, NULL, 1, 0, N'viewer@projekat.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab8cdb88-c2f8-45cc-8f90-db8992b8f97c', N'admin@projekat.com', 0, N'AAlNq2WBW2BKlPOKsyXleEe1QQKLJYTYPoIfWMf2UBCSLL3I9vstbl4wBUvUXn+lJA==', N'3093e67d-8e39-46e9-abde-cb2e420d8f4d', NULL, 0, 0, NULL, 0, 0, N'admin@projekat.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b57108cd-b788-4598-8d7c-6f72e63e4b9e', N'editor@projekat.com', 0, N'ACUnFWo/Ly1VgRK0EBU8sHF85Z6/BZy9l/5EJKD+AQ8sqk8xv7c3M8PKwEhCTzBatQ==', N'88253ca5-f111-43e0-970a-770b4926f908', NULL, 0, 0, NULL, 1, 0, N'editor@projekat.com')
INSERT [dbo].[OznakaMaila] ([Id], [Oznaka]) VALUES (100, N'Posao')
INSERT [dbo].[OznakaMaila] ([Id], [Oznaka]) VALUES (200, N'Privatna')
INSERT [dbo].[OznakaPostanskeAdrese] ([Id], [Oznaka]) VALUES (1, N'Kuca')
INSERT [dbo].[OznakaPostanskeAdrese] ([Id], [Oznaka]) VALUES (2, N'Posao')
INSERT [dbo].[OznakaPostanskeAdrese] ([Id], [Oznaka]) VALUES (3, N'Adresa iz LK')
INSERT [dbo].[OznakaTelefona] ([Id], [Oznaka]) VALUES (10, N'Mobilni')
INSERT [dbo].[OznakaTelefona] ([Id], [Oznaka]) VALUES (20, N'Kuca')
INSERT [dbo].[OznakaTelefona] ([Id], [Oznaka]) VALUES (30, N'Posao')
INSERT [dbo].[OznakaTelefona] ([Id], [Oznaka]) VALUES (40, N'Sluzbeni mobilni')
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 25.3.2017 17:25:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 25.3.2017 17:25:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 25.3.2017 17:25:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 25.3.2017 17:25:05 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 25.3.2017 17:25:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 25.3.2017 17:25:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BrojeviTelefona]  WITH CHECK ADD  CONSTRAINT [FK__BrojeviTe__Oznak__173876EA] FOREIGN KEY([OznakaId])
REFERENCES [dbo].[OznakaTelefona] ([Id])
GO
ALTER TABLE [dbo].[BrojeviTelefona] CHECK CONSTRAINT [FK__BrojeviTe__Oznak__173876EA]
GO
ALTER TABLE [dbo].[BrojeviTelefona]  WITH CHECK ADD  CONSTRAINT [FK__BrojeviTelef__Id__182C9B23] FOREIGN KEY([Id])
REFERENCES [dbo].[Osoba] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BrojeviTelefona] CHECK CONSTRAINT [FK__BrojeviTelef__Id__182C9B23]
GO
ALTER TABLE [dbo].[MailAdrese]  WITH CHECK ADD  CONSTRAINT [FK__MailAdres__Oznak__1CF15040] FOREIGN KEY([OznakaId])
REFERENCES [dbo].[OznakaMaila] ([Id])
GO
ALTER TABLE [dbo].[MailAdrese] CHECK CONSTRAINT [FK__MailAdres__Oznak__1CF15040]
GO
ALTER TABLE [dbo].[MailAdrese]  WITH CHECK ADD  CONSTRAINT [FK__MailAdrese__Id__1DE57479] FOREIGN KEY([Id])
REFERENCES [dbo].[Osoba] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MailAdrese] CHECK CONSTRAINT [FK__MailAdrese__Id__1DE57479]
GO
ALTER TABLE [dbo].[PostanskeAdrese]  WITH CHECK ADD  CONSTRAINT [FK__Postanske__Oznak__22AA2996] FOREIGN KEY([OznakaId])
REFERENCES [dbo].[OznakaPostanskeAdrese] ([Id])
GO
ALTER TABLE [dbo].[PostanskeAdrese] CHECK CONSTRAINT [FK__Postanske__Oznak__22AA2996]
GO
ALTER TABLE [dbo].[PostanskeAdrese]  WITH CHECK ADD  CONSTRAINT [FK__PostanskeAdr__Id__239E4DCF] FOREIGN KEY([Id])
REFERENCES [dbo].[Osoba] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostanskeAdrese] CHECK CONSTRAINT [FK__PostanskeAdr__Id__239E4DCF]
GO
USE [master]
GO
ALTER DATABASE [Projekat] SET  READ_WRITE 
GO
