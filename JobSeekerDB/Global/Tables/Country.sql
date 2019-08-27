CREATE TABLE [Global].[Country] (
    [CountryId]    INT                                         NOT NULL,
    [CountryName]  NVARCHAR (200)                              NOT NULL,
    [IsActive]     BIT                                         NOT NULL,
    [CreatedDate]  DATETIME2 (7)                               NOT NULL,
    [DeletedDate]  DATETIME2 (7)                               NULL,
    [IsDeleted]    BIT                                         NOT NULL,
    [SysStartDate] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndDate]   DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Global_Country] PRIMARY KEY CLUSTERED ([CountryId] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartDate], [SysEndDate])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[Global].[CountryHistory], DATA_CONSISTENCY_CHECK=ON));

