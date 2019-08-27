SET NOCOUNT ON
 
DECLARE @CreatedDate DATETIME
SET @CreatedDate = GETUTCDATE()
 
DECLARE @CategoriesToMerge TABLE
	(
		[DictionaryJobCategoryId]		INT PRIMARY KEY			NOT NULL,
		[Category]						NVARCHAR (200) 			NULL,
		[IsActive]						BIT						NOT NULL
	)
 
-- Insert into temporary table @RefFileTypeToMerge
INSERT INTO @CategoriesToMerge([DictionaryJobCategoryId], [Category], [IsActive])
VALUES
(1, 'IT', 1),
(2, 'Hospitality', 1),
(3, 'Health Care', 1),
(4, 'Finance', 1)
 
MERGE [Global].[DictionaryJobCategory] AS target
	USING (SELECT 
			[DictionaryJobCategoryId], 
			[Category], 
			[IsActive] FROM @CategoriesToMerge
	) AS source (
			[DictionaryJobCategoryId], 
			[Category], 
			[IsActive]
	)
ON (target.[DictionaryJobCategoryId] = source.[DictionaryJobCategoryId])
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
			[DictionaryJobCategoryId], 
			[Category], 
			[IsActive],
			[CreatedDate],
			[IsDeleted]
		   )
	VALUES (
			source.[DictionaryJobCategoryId], 
			source.[Category], 
			source.[IsActive],
			@CreatedDate,
			0
		   )
WHEN MATCHED 
	AND 
	(
		NULLIF(target.[Category], source.[Category]) IS NOT NULL OR NULLIF(source.[Category], target.[Category]) IS NOT NULL
		OR NULLIF(target.[IsActive], source.[IsActive]) IS NOT NULL OR NULLIF(source.[IsActive], target.[IsActive]) IS NOT NULL
	)
	THEN UPDATE SET 
	target.[Category] = source.[Category],
	target.[IsActive] = source.[IsActive];

SET NOCOUNT OFF