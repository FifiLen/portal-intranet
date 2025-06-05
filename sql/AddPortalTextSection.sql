-- Adds a [Section] column used to categorize portal texts by area
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PortalTexts_Key_Language')
    DROP INDEX IX_PortalTexts_Key_Language ON PortalTexts;

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE Name = N'Section' AND Object_ID = Object_ID(N'PortalTexts')
)
BEGIN
    ALTER TABLE PortalTexts ADD [Section] NVARCHAR(100) NOT NULL DEFAULT '';
END

CREATE UNIQUE INDEX IX_PortalTexts_Key_Section ON PortalTexts([Key], [Section]);
GO
