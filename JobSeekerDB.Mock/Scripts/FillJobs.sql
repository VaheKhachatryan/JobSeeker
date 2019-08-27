DECLARE @CreatedDate	DATETIME = GETUTCDATE()
DECLARE @ITCatId		INT = (SELECT TOP(1) [DictionaryJobCategoryId] FROM [Global].[DictionaryJobCategory] WHERE [Category] = 'IT')
DECLARE @HospCatId		INT = (SELECT TOP(1) [DictionaryJobCategoryId] FROM [Global].[DictionaryJobCategory] WHERE [Category] = 'Finance')
DECLARE @FullTimeId		INT = (SELECT TOP(1) [DictionaryEmploymentTypeId] FROM [Global].[DictionaryEmploymentType] WHERE [EmploymentType] = 'Full time')
DECLARE @PartTimeId		INT = (SELECT TOP(1) [DictionaryEmploymentTypeId] FROM [Global].[DictionaryEmploymentType] WHERE [EmploymentType] = 'Part time')
DECLARE @YerevanCityId	INT = (SELECT TOP(1) [CityId] FROM [Global].[City] WHERE [CityName] = 'Yerevan')
DECLARE @LondonCityId	INT = (SELECT TOP(1) [CityId] FROM [Global].[City] WHERE [CityName] = 'London')

INSERT INTO [Jobs].[Job] ([DictionaryJobCategoryId], [DictionaryEmploymentTypeId], [CityId], [Title], [Description], [IsActive], [CreatedDate], [IsDeleted])
VALUES
(
	@ITCatId,
	@FullTimeId,
	@YerevanCityId,
	N'Full Stack Web Developer',
	N'As a part of our talented and strong Engineering team, your second objective is to collaborate and engage in teamwork. “Alone we can do so little, together we can do so much”- this is what we truly believe in and we hope you share this and enjoy common success as we do.',
	1,
	@CreatedDate,
	0
),
(
	@HospCatId,
	@PartTimeId,
	@LondonCityId,
	N'Restaurant Manager',
	N'HOT PUB ռեստորանը աշխատանքի է հրավիրում փորձառու, բարետես արտաքինով աղջիկ մենեջերների:',
	1,
	@CreatedDate,
	0
)
