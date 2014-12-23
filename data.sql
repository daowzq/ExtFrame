
/****** Object:  Table [dbo].[Employee]    Script Date: 12/23/2014 09:22:58 ******/
USE [FrameDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Employee](
	[ID] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Job] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Postion] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[CreateId] [nvarchar](50) NULL,
	[CreateName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


----------×·¼ÓÊý¾Ý----------------------
declare @count int
declare @seek  int 
set @count=10000
set @seek=0
while @seek <@count
begin
	 insert into dbo.Employee 
	 select NEWID(), 'Homes',(@seek%80)+1,'Police','Tctx23'+ cast(@seek as varchar),
			'Learder',GETDATE(),NEWID(),'WGM'
	set @seek=@seek+1;
end ;

