SET NOCOUNT ON
 
DECLARE @CreatedDate DATETIME
SET @CreatedDate = GETUTCDATE()
 
DECLARE @EmploymentTypeToMerge TABLE
	(
		[DictionaryEmploymentTypeId]		INT PRIMARY KEY			NOT NULL,
		[EmploymentType]					NVARCHAR (200) 			NULL,
		[IsActive]							BIT						NOT NULL
	)
 
-- Insert into temporary table @RefFileTypeToMerge
INSERT INTO @EmploymentTypeToMerge([DictionaryEmploymentTypeId], [EmploymentType], [IsActive])
VALUES
(1, 'Full time', 1),
(2, 'Part time', 1),
(3, 'Contractor', 1),
(4, 'Intern', 1),
(5, 'Seasonal / Temp', 1)


MERGE [Global].[DictionaryEmploymentType] AS target
	USING (SELECT 
			[DictionaryEmploymentTypeId], 
			[EmploymentType], 
			[IsActive] FROM @EmploymentTypeToMerge
	) AS source (
			[DictionaryEmploymentTypeId], 
			[EmploymentType], 
			[IsActive]
	)
ON (target.[DictionaryEmploymentTypeId] = source.[DictionaryEmploymentTypeId])
WHEN NOT MATCHED BY TARGET THEN
	INSERT (
			[DictionaryEmploymentTypeId], 
			[EmploymentType], 
			[IsActive],
			[CreatedDate],
			[IsDeleted]
		   )
	VALUES (
			source.[DictionaryEmploymentTypeId], 
			source.[EmploymentType], 
			source.[IsActive],
			@CreatedDate,
			0
		   )
WHEN MATCHED 
	AND 
	(
		NULLIF(target.[EmploymentType], source.[EmploymentType]) IS NOT NULL OR NULLIF(source.[EmploymentType], target.[EmploymentType]) IS NOT NULL
		OR NULLIF(target.[IsActive], source.[IsActive]) IS NOT NULL OR NULLIF(source.[IsActive], target.[IsActive]) IS NOT NULL
	)
	THEN UPDATE SET 
	target.[EmploymentType] = source.[EmploymentType],
	target.[IsActive] = source.[IsActive];

SET NOCOUNT OFF