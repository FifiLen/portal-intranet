/* Inserts initial portal texts used across the entire site */

-- Category pages
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Women_Title')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Women_Title', 'KOBIETY', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Women_Subtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Women_Subtitle', 'Odkryj naszą kolekcję dla kobiet, która łączy nowoczesny design z ponadczasową elegancją', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Women_Scroll')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Women_Scroll', 'PRZEWIŃ W DÓŁ', 'Category');

IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Men_Title')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Men_Title', 'MĘŻCZYŹNI', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Men_Subtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Men_Subtitle', 'Odkryj naszą kolekcję dla mężczyzn, która łączy nowoczesny design z ponadczasową elegancją', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Men_Scroll')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Men_Scroll', 'PRZEWIŃ W DÓŁ', 'Category');

IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Kids_Title')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Kids_Title', 'DZIECI', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Kids_Subtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Kids_Subtitle', 'Odkryj naszą kolekcję dla dzieci, która łączy wygodę, jakość i radosny design', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Kids_Scroll')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Kids_Scroll', 'PRZEWIŃ W DÓŁ', 'Category');

IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Accessories_Title')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Accessories_Title', 'AKCESORIA', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Accessories_Subtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Accessories_Subtitle', 'Odkryj naszą kolekcję akcesoriów, które dopełnią każdą stylizację i dodadzą jej charakteru', 'Category');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Category_Accessories_Scroll')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Category_Accessories_Scroll', 'PRZEWIŃ W DÓŁ', 'Category');

-- Info pages
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_About_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_About_HeroTitle', 'O FIRMIE', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Jobs_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Jobs_HeroTitle', 'PRACA', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Privacy_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Privacy_HeroTitle', 'POLITYKA PRYWATNOŚCI', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Shipping_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Shipping_HeroTitle', 'DOSTAWA I PŁATNOŚCI', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Terms_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Terms_HeroTitle', 'REGULAMIN', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Returns_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Returns_HeroTitle', 'ZWROTY I REKLAMACJE', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Faq_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Faq_HeroTitle', 'FAQ', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Contact_HeroTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Info_Contact_HeroTitle', 'KONTAKT', 'Info');

-- Account/Login
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Title')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Title', 'Logowanie', 'Account');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Email')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Email', 'Email', 'Account');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Password')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Password', 'Hasło', 'Account');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Button')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Button', 'Zaloguj', 'Account');
GO
