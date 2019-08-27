CREATE TABLE [Global].[DictionaryJobCategory] (
    [DictionaryJobCategoryId] INT                                         NOT NULL,
    [Category]                NVARCHAR (200)                              NOT NULL,
    [IsActive]                BIT                                         NOT NULL,
    [CreatedDate]             DATETIME2 (7)                               NOT NULL,
    [DeletedDate]             DATETIME2 (7)                               NULL,
    [IsDeleted]               BIT                                         NOT NULL,
    [SysStartDate]            DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndDate]              DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Global_DictionaryJobCategory] PRIMARY KEY CLUSTERED ([DictionaryJobCategoryId] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartDate], [SysEndDate])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[Global].[DictionaryJobCategoryHistory], DATA_CONSISTENCY_CHECK=ON));


GO
CREATE NONCLUSTERED INDEX [IX_Global_DictionaryJobCategory_Category]
    ON [Global].[DictionaryJobCategory]([Category] ASC);

