USE [WebsocketEvents]
GO
/****** Object:  StoredProcedure [Events].[ArchiveEvents]    Script Date: 3/24/2018 7:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Events].[ArchiveEvents]

	@Events EventPool READONLY

AS

delete q
OUTPUT deleted.Id, deleted.Message into Events.Archive(EventId,Message)
from Events.Queue q with(nolock)
where q.Id in (select EventId from @Events)

Select @@ROWCOUNT as Deleted