CREATE PROCEDURE sp_notgoster
	@ders VARCHAR(50) ,
	@hanginot VARCHAR(10) ,
	@ogrno INT =1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF(@ogrno NOT IN ( select ogrencino from ogrenci))
		BEGIN
		IF (@ders ='fizik' or @ders='yazılım mühendisliği' or @ders='yapay zeka' or @ders='matematik' or @ders='programlama dili 2' or @ders='ileri programlama') 
		BEGIN
			IF(@hanginot='vize')
			BEGIN
				SELECT DISTINCT ogrenci.ogrencino AS numarasi,ad,soyad,vize
					FROM ogrenci,notlar,dersler 
						WHERE ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad=@ders)
			END 
			ELSE IF (@hanginot='final')
			BEGIN
				SELECT DISTINCT ogrenci.ogrencino AS numarasi,ad,soyad,final
					FROM ogrenci,notlar,dersler 
						WHERE ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad=@ders)
			END 
			ELSE IF(@hanginot='genel')
			BEGIN 	
				SELECT DISTINCT ogrenci.ogrencino AS numarasi,ad,soyad,vize,final
					FROM ogrenci,notlar,dersler 
							WHERE ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad=@ders)
			END 
			ELSE
			BEGIN
				PRINT('Yanlış seçenek girdiniz. Seçenekler :vize, final ve genel şeklindedir')
			END 
		END 
		ELSE
		BEGIN 
			PRINT('Olmayan bir ders girdiniz. Seçenekler :vize, final ve genel şeklindedir')
		END 
	END
	ELSE
	BEGIN 
		IF (@ders ='fizik' or @ders='yazılım mühendisliği' or @ders='yapay zeka' or @ders='matematik' or @ders='programlama dili 2' or @ders='ileri programlama') 
		BEGIN
			IF(@hanginot='vize')
			BEGIN
				SELECT ad,soyad,ogrenci.ogrencino,vize,dersad 
					FROM ogrenci,notlar,dersler 
						WHERE ogrenci.ogrencino=@ogrno and dersler.dersno=notlar.dersno and ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad=@ders)
			END 
			ELSE IF (@hanginot='final')
			BEGIN
				SELECT ad,soyad,ogrenci.ogrencino,final,dersad 
					FROM ogrenci,notlar,dersler 
						WHERE ogrenci.ogrencino=@ogrno and dersler.dersno=notlar.dersno and ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad=@ders)
			END 
			ELSE IF(@hanginot='genel')
			BEGIN 	
				SELECT ad,soyad,ogrenci.ogrencino,vize,final,dersad 
					FROM ogrenci,notlar,dersler 
						WHERE ogrenci.ogrencino=@ogrno and dersler.dersno=notlar.dersno and ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad=@ders)
			END 
			ELSE
			BEGIN
				PRINT('Yanlış seçenek girdiniz. Seçenekler :vize, final ve genel şeklindedir')
			END 
		END 
		ELSE
		BEGIN 
			PRINT('Olmayan bir ders girdiniz. Seçenekler :vize, final ve genel şeklindedir')
		END 
	END
END