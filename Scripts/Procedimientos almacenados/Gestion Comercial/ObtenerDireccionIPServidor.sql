USE Doblones20
GO

---- To allow advanced options to be changed.
EXEC sp_configure 'show advanced options', 1
GO

--To update the currently configured value for advanced options.
RECONFIGURE
GO

--To enable the feature.
EXEC sp_configure 'xp_cmdshell', 1
GO

--To update the currently configured value for this feature.
RECONFIGURE
GO


CREATE PROCEDURE sp_get_ip_address (@ip VARCHAR(40) OUT)
AS
BEGIN
DECLARE @ipLine VARCHAR(200)
DECLARE @pos INT
SET NOCOUNT ON
		SET @ip = NULL
		CREATE TABLE #temp (
			ipLine varchar(200)
		)
        INSERT #temp EXEC MASTER..xp_cmdshell 'ipconfig'
        SELECT @ipLine = ipLine
        FROM #temp
        WHERE UPPER (ipLine) like '%IP ADDRESS%'
        IF (ISNULL (@ipLine,'***') != '***')
		BEGIN 
            SET @pos = CHARINDEX (':',@ipLine,1);
            SET @ip = RTRIM(LTRIM(SUBSTRING (@ipLine , @pos + 1 ,LEN (@ipLine) - @pos)))
		END 
		DROP TABLE #temp
SET NOCOUNT OFF
END 
GO

--declare @ip varchar(40)
--exec sp_get_ip_address @ip out
--print @ip
--go



--CREATE TABLE #ipconfig(captured_line VARCHAR(255))
--INSERT INTO #ipconfig
--  EXECUTE xp_cmdshell 'ipconfig /all'
--go

--SELECT captured_line FROM #ipconfig;
--go

--SELECT captured_line FROM #ipconfig
--WHERE captured_line like '%IP Address%'
--or captured_line like '%Dirección IPv4%'
--go

--SELECT CAST(PARSENAME(SUBSTRING(captured_line,40,15),4) AS VARCHAR(4)) AS '1st octet',
--       CAST(PARSENAME(SUBSTRING(captured_line,40,15),3) AS VARCHAR(3)) AS '2nd octet',
--       CAST(PARSENAME(SUBSTRING(captured_line,40,15),2) AS VARCHAR(3)) AS '3rd octet',
--       CAST(PARSENAME(SUBSTRING(captured_line,40,15),1) AS VARCHAR(3)) AS '4th octet'
--FROM #ipconfig WHERE captured_line like '%IP Address%'
--or captured_line like '%Dirección IPv4%'

--SELECT convert(VARCHAR, getdate(),2)
