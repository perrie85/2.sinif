CREATE TABLE ogrenci (	ogrencino INT PRIMARY KEY IDENTITY(100,1) not null, 
						ad VARCHAR(50) not null,
						soyad VARCHAR(50)not null,
						sinif INT CHECK (sinif between 1 and 4));
CREATE TABLE ogretmen(  ogretmenno INT PRIMARY KEY IDENTITY(4500,1) not null,
						ad VARCHAR(50) not null,
						soyad VARCHAR(50)not null,
						unvan VARCHAR(50) not null);
CREATE TABLE dersler(	dersno INT PRIMARY KEY IDENTITY (3300,1)not null,
						ogretmenno INT FOREIGN KEY REFERENCES ogretmen(ogretmenno) not null,
						sinif INT CHECK(sinif between 1 and 4) not null,
						dersad VARCHAR(50) not null );
CREATE TABLE notlar (	ogrencino INT FOREIGN KEY REFERENCES ogrenci(ogrencino) not null,
						dersno INT FOREIGN KEY REFERENCES dersler(dersno) not null,
						vize INT CHECK(vize between 0 and 100),
						final INT CHECK (final between 0 and 100));
						
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Turgut','Ozseven',1);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Bulent','Ayar',2);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Ayse','Ucar',3);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Elif','Kurt',4);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Murat','Beyaz',1);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Ahmet','Kara',2);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Mustafa','Caglayan',3);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Furkan','Celik',4);
INSERT INTO ogrenci(ad,soyad,sinif) VALUES ('Ibrahim','Acises',1);

INSERT INTO ogretmen(ad,soyad,unvan) VALUES ('Nevzat','Dolapcý','Profesor Dr');
INSERT INTO ogretmen(ad,soyad,unvan) VALUES ('Veli','Paca','Docent Dr');
INSERT INTO ogretmen(ad,soyad,unvan) VALUES ('Kadir','Tatar','Dr Ogretim Gorevlisi');
INSERT INTO ogretmen(ad,soyad,unvan) VALUES ('Zeliha','Aslan','Profesor Dr');
INSERT INTO ogretmen(ad,soyad,unvan) VALUES ('Humar','Siyah','Docent Dr');
INSERT INTO ogretmen(ad,soyad,unvan) VALUES ('Beyza','Ak','Dr Ogretim Gorevlisi');

INSERT INTO dersler(ogretmenno,dersad,sinif) VALUES (4500,'matematik',1);
INSERT INTO dersler(ogretmenno,dersad,sinif) VALUES (4501,'yazýlým mühendisliði',2);
INSERT INTO dersler(ogretmenno,dersad,sinif) VALUES (4502,'yapay zeka',3);
INSERT INTO dersler(ogretmenno,dersad,sinif) VALUES (4503,'programlama dili 2',2);
INSERT INTO dersler(ogretmenno,dersad,sinif) VALUES (4504,'ileri programlama',4);
INSERT INTO dersler(ogretmenno,dersad,sinif) VALUES (4505,'fizik',1);

INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(100,3300,50,55);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(100,3305,90,42);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(101,3301,46,33);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(101,3303,88,30);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(102,3302,51,35);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(103,3304,40,60);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(104,3300,12,5);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(104,3305,66,55);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(105,3301,46,35);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(105,3303,58,38);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(106,3302,56,65);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(107,3304,50,55);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(108,3300,50,55);
INSERT INTO notlar(ogrencino,dersno,vize,final) VALUES(108,3305,90,42);



SELECT * FROM ogrenci
SELECT * FROM ogretmen
SELECT * FROM dersler

SELECT DISTINCT ogrenci.ogrencino AS numarasi,ad,soyad,vize,final
	FROM ogrenci,notlar,dersler 
		WHERE ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=(SELECT dersno FROM dersler WHERE dersad='fizik')

select ogrenci.ogrencino as numarasi,ad,soyad,dersad,vize*0.4+final*0.6 as notu 
	from ogrenci,notlar,dersler 
		where ogrenci.ogrencino=notlar.ogrencino and notlar.dersno=dersler.dersno

SELECT AVG(vize), AVG(final) from notlar where dersno=(select dersno from dersler where dersad='fizik')

select vize,final,ad 
	from ogrenci,notlar
		where ogrenci.ogrencino=notlar.ogrencino and dersno=(select dersno from dersler where dersad='fizik')


select*from notlar where dersno=(select dersno from dersler where dersad='matematik')

exec sp_orthesapla 'programlama dili 2','genel'

SELECT ad,soyad,ogrenci.ogrencino,vize,dersad 
	FROM ogrenci,notlar,dersler 
		WHERE dersler.dersno=notlar.dersno and ogrenci.ogrencino=notlar.ogrencino and ogrenci.ogrencino=100


exec sp_notgoster 'matematik','vize'

SELECT ogrenci.ogrencino,ad,soyad,vize,final 
	FROM ogrenci,notlar 
		WHERE ogrenci.ogrencino=notlar.ogrencino and 45 < vize*0.4+final*0.6 and 
											dersno=(SELECT dersno FROM dersler WHERE dersad like'iler%')


SELECT	MAX(vize) AS enfazla, MIN (vize) AS enaz 
	FROM notlar 
			WHERE dersno=(SELECT dersno FROM dersler WHERE dersad like'iler%')