-- Assigns Home section to existing portal texts whose keys begin with Home_
-- and have no section set
UPDATE PortalTexts
SET Section = 'Home'
WHERE [Key] LIKE 'Home_%' AND (Section IS NULL OR Section = '');

-- Assign Layout section to navigation and header texts that lack it
UPDATE PortalTexts
SET Section = 'Layout'
WHERE [Key] IN ('Header_Brand', 'Nav_Women', 'Nav_Men', 'Nav_Kids', 'Nav_Accessories')
  AND (Section IS NULL OR Section = '');

-- Assign Info section to texts related to info pages
UPDATE PortalTexts
SET Section = 'Info'
WHERE [Key] LIKE 'Info_%' AND (Section IS NULL OR Section = '');
GO
