CREATE TABLE [Global].[City] (
    [CityId]       INT                                         NOT NULL,
    [CountryId]    INT                                         NOT NULL,
    [CityName]     VARCHAR (200)                               NOT NULL,
    [IsActive]     BIT                                         NOT NULL,
    [CreatedDate]  DATETIME2 (7)                               NOT NULL,
    [DeletedDate]  DATETIME2 (7)                               NULL,
    [IsDeleted]    BIT                                         NOT NULL,
    [SysStartDate] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndDate]   DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_Global_City] PRIMARY KEY CLUSTERED ([CityId] ASC),
    CONSTRAINT [FK_Global_Country] FOREIGN KEY ([CountryId]) REFERENCES [Global].[Country] ([CountryId]),
    PERIOD FOR SYSTEM_TIME ([SysStartDate], [SysEndDate])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[Global].[CityHistory], DATA_CONSISTENCY_CHECK=ON));


GO
CREATE NONCLUSTERED INDEX [IX_City_CountyId]
    ON [Global].[City]([CountryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Global_City_CityName]
    ON [Global].[City]([CityName] ASC);

