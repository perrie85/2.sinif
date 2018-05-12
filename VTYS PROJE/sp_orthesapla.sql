CREATE PROCEDURE sp_orthesapla
	@ders VARCHAR(50),
	@hanginot VARCHAR(10) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (@ders ='fizik' or @ders='yaz�l�m m�hendisli�i' or @ders='yapay zeka' or @ders='matematik' or @ders='programlama dili 2' or @ders='ileri programlama') 
	BEGIN
		IF(@hanginot='vize')
		BEGIN
			SELECT AVG(vize) 
				from notlar 
					where dersno=(select dersno from dersler where dersad=@ders)
		END 
		ELSE IF (@hanginot='final')
		BEGIN
			SELECT AVG(final) 
				from notlar 
					where dersno=(select dersno from dersler where dersad=@ders)
		END 
		ELSE IF(@hanginot='genel')
		BEGIN 	
			SELECT AVG(vize)*0.4+ AVG(final)*0.6 AS GENELORTALAMA 
				from notlar 
					where dersno=(select dersno from dersler where dersad=@ders)
		END 
		ELSE
		BEGIN
			PRINT('Yanl�� se�enek girdiniz. Se�enekler :vize, final ve genel �eklindedir')
		END 
	END 
	ELSE
	BEGIN 
		PRINT('Olmayan bir ders girdiniz. Se�enekler :vize, final ve genel �eklindedir')
	END 
END