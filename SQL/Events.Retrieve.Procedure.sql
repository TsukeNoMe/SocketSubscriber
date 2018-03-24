USE [WebsocketEvents]
GO
/****** Object:  StoredProcedure [Events].[RetrieveEvents]    Script Date: 3/24/2018 7:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Events].[RetrieveEvents]

	@Batch int = 1

AS

Select  top(@Batch) * from Events.Queue q with(nolock)
order by q.Id