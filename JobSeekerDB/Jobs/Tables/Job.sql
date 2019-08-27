CREATE TABLE [Jobs].[Job] (
    [JobId]                      INT                                         IDENTITY (1, 1) NOT NULL,
    [DictionaryJobCategoryId]    INT                                         NOT NULL,
    [DictionaryEmploymentTypeId] INT                                         NOT NULL,
    [CityId]                     INT                                         NOT NULL,
    [Title]                      NVARCHAR (1000)                             NOT NULL,
    [Description]                NVARCHAR (MAX)                              NULL,
    [IsActive]                   BIT                                         NOT NULL,
    [CreatedDate]                DATETIME2 (7)                               NOT NULL,
    [DeletedDate]                DATETIME2 (7)                               NULL,
    [IsDeleted]                  BIT                                         NOT NULL,
    [SysStartDate]               DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndDate]                 DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED ([JobId] ASC),
    CONSTRAINT [FK_Global_City] FOREIGN KEY ([CityId]) REFERENCES [Global].[City] ([CityId]),
    CONSTRAINT [FK_Global_DictionaryEmploymentType] FOREIGN KEY ([DictionaryEmploymentTypeId]) REFERENCES [Global].[DictionaryEmploymentType] ([DictionaryEmploymentTypeId]),
    CONSTRAINT [FK_Global_DictionaryJobCategory] FOREIGN KEY ([DictionaryJobCategoryId]) REFERENCES [Global].[DictionaryJobCategory] ([DictionaryJobCategoryId]),
    PERIOD FOR SYSTEM_TIME ([SysStartDate], [SysEndDate])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[Jobs].[JobHistory], DATA_CONSISTENCY_CHECK=ON));


GO
CREATE NONCLUSTERED INDEX [IX_Job]
    ON [Jobs].[Job]([DictionaryJobCategoryId] ASC, [DictionaryEmploymentTypeId] ASC, [CityId] ASC)
    INCLUDE([Title], [Description]);

