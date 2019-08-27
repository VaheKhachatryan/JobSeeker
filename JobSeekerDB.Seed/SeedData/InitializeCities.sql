SET NOCOUNT ON
 
DECLARE @CreatedDate DATETIME
SET @CreatedDate = GETUTCDATE()

DECLARE @ArmeniaId		INT = (SELECT TOP(1) [CountryId] FROM [Global].[Country] WHERE [CountryName] = 'Armenia')
DECLARE @UK				INT = (SELECT TOP(1) [CountryId] FROM [Global].[Country] WHERE [CountryName] = 'UK')

DECLARE @CitiesToMerge TABLE
	(
		[CityId]		INT PRIMARY KEY			NOT NULL,
		[CityName]		NVARCHAR (200) 			NOT NULL,
		[CountryId]		INT						NOT NULL,
		[IsActive]		BIT						NOT NULL
	)
 
-- Insert into temporary table @RefFileTypeToMerge
INSERT INTO @CitiesToMerge([CityId], [CityName], [CountryId], [IsActive])
VALUES
(1, 'Yerevan', @ArmeniaId,  1),
(2, 'London', @UK, 1)

MERGE [Global].[City] AS target
	USING (SELECT 
			[CityId], 
			[CityName], 
			[CountryId],
			[IsActive] FROM @CitiesToMerge
	) AS source (
			[CityId], 
			[CityName], 
			[CountryId],
			[IsActive]
	)
ON (target.[CityId] = source.[CityId])
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
			[CityId], 
			[CityName], 
			[CountryId],
			[IsActive],
			[CreatedDate],
			[IsDeleted]
		   )
	VALUES (
			source.[CityId], 
			source.[CityName], 
			source.[CountryId], 
			source.[IsActive],
			@CreatedDate,
			0
		   )
WHEN MATCHED 
	AND 
	(
		NULLIF(target.[CityName], source.[CityName]) IS NOT NULL OR NULLIF(source.[CityName], target.[CityName]) IS NOT NULL
		OR NULLIF(target.[CountryId], source.[CountryId]) IS NOT NULL OR NULLIF(source.[CountryId], target.[CountryId]) IS NOT NULL
		OR NULLIF(target.[IsActive], source.[IsActive]) IS NOT NULL OR NULLIF(source.[IsActive], target.[IsActive]) IS NOT NULL
	)
	THEN UPDATE SET 
	target.[CityName] = source.[CityName],
	target.[CountryId] = source.[CountryId],
	target.[IsActive] = source.[IsActive];

SET NOCOUNT OFF