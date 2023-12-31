USE [AnonymForum]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 2023-09-20 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FKTopic] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Contents] [nvarchar](1000) NOT NULL,
	[TimePosted] [datetime] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 2023-09-20 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FKPost] [int] NOT NULL,
	[Contents] [nvarchar](1000) NOT NULL,
	[ReplyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 2023-09-20 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([ID], [FKTopic], [Title], [Contents], [TimePosted]) VALUES (1, 1, N'Fotboll är poggers', N'jag älskar fotboll wow', CAST(N'2023-01-21T21:42:01.000' AS DateTime))
INSERT [dbo].[Post] ([ID], [FKTopic], [Title], [Contents], [TimePosted]) VALUES (2, 2, N'Starfield sucks', N'I played starfield and it sucked bad like ajsdnöaskojdölksanmdföl.s<ajfklözsdfnölgnjzskögfvnzsörkjnfgjkzsölngfökszjnegrökljszrng', CAST(N'2023-09-11T14:24:55.240' AS DateTime))
INSERT [dbo].[Post] ([ID], [FKTopic], [Title], [Contents], [TimePosted]) VALUES (3, 1, N'Basketball är tråkig', N'jag har kollat på basketball igår och somnade !!!', CAST(N'2023-09-17T16:17:12.117' AS DateTime))
INSERT [dbo].[Post] ([ID], [FKTopic], [Title], [Contents], [TimePosted]) VALUES (4, 1, N'messi eller ronaldo', N'messi är en goat och ronaldo är overhyped change my mind', CAST(N'2023-09-17T16:17:40.763' AS DateTime))
INSERT [dbo].[Post] ([ID], [FKTopic], [Title], [Contents], [TimePosted]) VALUES (5, 3, N'oppenheimer is trash wtf', N'i missed the first hour of oppenheimer but i have to say that the movie doesnt make sensse whatsoever', CAST(N'2023-09-20T00:39:16.047' AS DateTime))
INSERT [dbo].[Post] ([ID], [FKTopic], [Title], [Contents], [TimePosted]) VALUES (6, 3, N'the new batman was boring', N'robert pattinson is boring actor but song was fire!!! 💃', CAST(N'2023-09-20T00:45:27.313' AS DateTime))
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Reply] ON 

INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (1, 1, N'jag håller fan inte med!!!', CAST(N'2023-09-08T19:27:00.000' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (2, 2, N'yea i dont agree starfield is a kinda cool game that has spaceships :D', CAST(N'2023-09-11T14:45:38.270' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (3, 2, N'stfu man you dont know what you are talking about you suck', CAST(N'2023-09-11T14:46:03.063' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (4, 3, N'pessi fanboy detect, laliga stat peddler vet ingenting abarman!!!!!!', CAST(N'2023-09-18T02:08:42.757' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (5, 4, N'?????', CAST(N'2023-09-19T22:10:37.307' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (6, 1, N'Jo fotboll är kulll!!!!', CAST(N'2023-09-19T22:27:45.907' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (7, 2, N'nah starfield is cool', CAST(N'2023-09-19T22:33:46.517' AS DateTime))
INSERT [dbo].[Reply] ([ID], [FKPost], [Contents], [ReplyDate]) VALUES (8, 5, N'you missed the movie though', CAST(N'2023-09-20T00:43:38.113' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reply] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([ID], [Name]) VALUES (1, N'Sport')
INSERT [dbo].[Topic] ([ID], [Name]) VALUES (2, N'Spel')
INSERT [dbo].[Topic] ([ID], [Name]) VALUES (3, N'Filmer')
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Topic] FOREIGN KEY([FKTopic])
REFERENCES [dbo].[Topic] ([ID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Topic]
GO
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Post] FOREIGN KEY([FKPost])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_Reply_Post]
GO
