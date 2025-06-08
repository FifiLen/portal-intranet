/* Inserts initial portal texts used across the entire site */

-- Layout texts
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Header_Brand')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Header_Brand', 'CIUCHY', 'Layout');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Nav_Women')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Nav_Women', 'KOBIETY', 'Layout');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Nav_Men')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Nav_Men', 'MĘŻCZYŹNI', 'Layout');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Nav_Kids')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Nav_Kids', 'DZIECI', 'Layout');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Nav_Accessories')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Nav_Accessories', 'AKCESORIA', 'Layout');

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

IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_About_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_About_Text1', 'CIUCHY to marka łącząca pasję do mody z wysoką jakością wykonania. Tworzymy ubrania, które pozwalają wyrazić indywidualny styl.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_About_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_About_Text2', 'Nasz zespół dba o każdy detal, dzięki czemu oferujemy kolekcje dopracowane i zgodne z najnowszymi trendami.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Jobs_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Jobs_Text1', 'Szukasz inspirującego miejsca pracy? W CIUCHY stawiamy na kreatywność i rozwój. Regularnie poszukujemy osób pełnych pasji do mody.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Jobs_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Jobs_Text2', 'Wyślij swoje CV na adres <strong>praca@ciuchy.pl</strong> i dołącz do naszego zespołu.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Privacy_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Privacy_Text1', 'Chronimy Twoje dane osobowe i przetwarzamy je zgodnie z obowiązującymi przepisami. Szczegóły dotyczące przetwarzania danych znajdziesz poniżej.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Privacy_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Privacy_Text2', 'W razie pytań dotyczących prywatności skontaktuj się z nami poprzez formularz kontaktowy.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Shipping_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Shipping_Text1', 'Zamówienia realizujemy w ciągu 1-2 dni roboczych. Dostawy obsługuje firma kurierska oraz paczkomaty.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Shipping_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Shipping_Text2', 'Akceptujemy płatności przelewem, kartą oraz za pobraniem. Szczegóły wyświetlane są na etapie finalizacji zamówienia.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Terms_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Terms_Text1', 'Niniejszy regulamin określa zasady korzystania ze sklepu CIUCHY. Dokonując zakupu, akceptujesz poniższe warunki.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Terms_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Terms_Text2', 'Pełną wersję regulaminu znajdziesz w dokumentach dostępnych w naszym biurze obsługi klienta.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Returns_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Returns_Text1', 'Masz 14 dni na zwrot towaru bez podania przyczyny. Reklamacje rozpatrujemy w ciągu 14 dni od ich otrzymania.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Returns_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Returns_Text2', 'Aby rozpocząć proces zwrotu lub reklamacji, napisz na <strong>reklamacje@ciuchy.pl</strong>.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Faq_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Faq_Text1', 'Najczęściej zadawane pytania dotyczące zakupów w naszym sklepie znajdziesz poniżej.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Faq_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Faq_Text2', 'Jeśli nie znalazłeś odpowiedzi, napisz do nas – chętnie pomożemy.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Contact_Text1')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Contact_Text1', 'Masz pytania? Skontaktuj się z nami pod adresem <strong>kontakt@ciuchy.pl</strong> lub telefonicznie: <strong>+48 123 456 789</strong>.', 'Info');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Info_Contact_Text2')
    INSERT INTO PortalTexts([Key], [Value], [Section])
    VALUES ('Info_Contact_Text2', 'Odpowiadamy na wiadomości w dni robocze w godzinach 9:00-17:00.', 'Info');

-- Account/Login
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Title')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Title', 'Logowanie', 'Account');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Email')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Email', 'Email', 'Account');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Password')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Password', 'Hasło', 'Account');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Account_Login_Button')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Account_Login_Button', 'Zaloguj', 'Account');

-- Home page
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_HeroTop')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_HeroTop', 'NOWA KOLEKCJA', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_HeroBottom')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_HeroBottom', 'WIOSNA/LATO', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_HeroSubtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_HeroSubtitle', 'Najmodniejsze trendy tego sezonu', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_HeroButton')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_HeroButton', 'ODKRYJ KOLEKCJĘ', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_CategoriesTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_CategoriesTitle', 'KATEGORIE', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_CategoriesSubtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_CategoriesSubtitle', 'Odkryj nasze sekcje i znajdź coś dla siebie', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_FeaturedTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_FeaturedTitle', 'WYRÓŻNIONE PRODUKTY', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_FeaturedSubtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_FeaturedSubtitle', 'Sprawdź nasze bestsellery', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_ShowMore')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_ShowMore', 'POKAŻ WIĘCEJ', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_LookbookTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_LookbookTitle', 'LOOKBOOK', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_LookbookSubtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_LookbookSubtitle', 'Zainspiruj się naszymi stylizacjami', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_LookbookButton')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_LookbookButton', 'POKAŻ LOOKBOOK', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_NewsletterTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_NewsletterTitle', 'NEWSLETTER', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_NewsletterSubtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_NewsletterSubtitle', 'Zapisz się, aby otrzymywać najnowsze informacje i oferty', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_NewsletterPlaceholder')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_NewsletterPlaceholder', 'Wpisz swój email', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_NewsletterButton')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_NewsletterButton', 'ZAPISZ SIĘ', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_InstagramTitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_InstagramTitle', 'INSTAGRAM', 'Home');
IF NOT EXISTS (SELECT 1 FROM PortalTexts WHERE [Key] = 'Home_InstagramSubtitle')
    INSERT INTO PortalTexts([Key], [Value], [Section]) VALUES ('Home_InstagramSubtitle', 'Obserwuj nas na Instagramie', 'Home');
GO
