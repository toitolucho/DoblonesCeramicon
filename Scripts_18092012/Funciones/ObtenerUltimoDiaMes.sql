USE Doblones20
GO

DROP FUNCTION ObtenerUltimoDiaMes
GO

CREATE FUNCTION [dbo].[ObtenerUltimoDiaMes] ( @pInputDate    DATETIME )
RETURNS DATETIME
BEGIN

    DECLARE @vOutputDate        DATETIME

    SET @vOutputDate = CAST(YEAR(@pInputDate) AS VARCHAR(4)) + '/' + 
                       CAST(MONTH(@pInputDate) AS VARCHAR(2)) + '/01'
    SET @vOutputDate = DATEADD(DD, -1, DATEADD(M, 1, @vOutputDate))

    RETURN @vOutputDate

END
GO


DROP FUNCTION ObtenerPrimerDiaMes
GO

CREATE FUNCTION [dbo].[ObtenerPrimerDiaMes] ( @pInputDate    DATETIME )
RETURNS DATETIME
BEGIN

    RETURN CAST(CAST(YEAR(@pInputDate) AS VARCHAR(4)) + '/' + '01/'+ 
                CAST(MONTH(@pInputDate) AS VARCHAR(2))  AS DATETIME)

END
GO