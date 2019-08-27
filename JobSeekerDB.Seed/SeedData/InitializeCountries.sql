SET NOCOUNT ON
 
DECLARE @CreatedDate DATETIME
SET @CreatedDate = GETUTCDATE()
 
DECLARE @CountriesToMerge TABLE
	(
		[CountryId]						INT PRIMARY KEY			NOT NULL,
		[CountryName]					NVARCHAR (200) 			NULL,
		[IsActive]						BIT						NOT NULL
	)
 
-- Insert into temporary table @RefFileTypeToMerge
INSERT INTO @CountriesToMerge([CountryId], [CountryName], [IsActive])
VALUES
(1, 'Armenia', 1),
(2, 'UK', 1)

MERGE [Global].[Country] AS target
	USING (SELECT 
			[CountryId], 
			[CountryName], 
			[IsActive] FROM @CountriesToMerge
	) AS source (
			[CountryId], 
			[CountryName], 
			[IsActive]
	)
ON (target.[CountryId] = source.[CountryId])
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
			[CountryId], 
			[CountryName], 
			[IsActive],
			[CreatedDate],
			[IsDeleted]
		   )
	VALUES (
			source.[CountryId], 
			source.[CountryName], 
			source.[IsActive],
			@CreatedDate,
			0
		   )
WHEN MATCHED 
	AND 
	(
		NULLIF(target.[CountryName], source.[CountryName]) IS NOT NULL OR NULLIF(source.[CountryName], target.[CountryName]) IS NOT NULL
		OR NULLIF(target.[IsActive], source.[IsActive]) IS NOT NULL OR NULLIF(source.[IsActive], target.[IsActive]) IS NOT NULL
	)
	THEN UPDATE SET 
	target.[CountryName] = source.[CountryName],
	target.[IsActive] = source.[IsActive];

SET NOCOUNT OFF