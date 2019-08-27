CREATE TABLE [Global].[DictionaryEmploymentType] (
    [DictionaryEmploymentTypeId] INT                                         NOT NULL,
    [EmploymentType]             NVARCHAR (200)                              NOT NULL,
    [IsActive]                   BIT                                         NOT NULL,
    [CreatedDate]                DATETIME2 (7)                               NOT NULL,
    [DeletedDate]                DATETIME2 (7)                               NULL,
    [IsDeleted]                  BIT                                         NOT NULL,
    [SysStartDate]               DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndDate]                 DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Global_DictionaryEmploymentType] PRIMARY KEY CLUSTERED ([DictionaryEmploymentTypeId] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartDate], [SysEndDate])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[Global].[DictionaryEmploymentTypeIdHistory], DATA_CONSISTENCY_CHECK=ON));

