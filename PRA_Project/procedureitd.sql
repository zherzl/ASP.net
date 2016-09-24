select * from InicijalniPodaci

CREATE PROC UbaciInicijalnePodatke
AS
(
	INSERT INTO TipKategorija(Naziv) VALUES('Trosak'), ('Prihod');
	INSERT INTO Kategorija(Naziv, Aktivno, DatumVrijeme, TipKategorijaID, UserId)
				VALUES('Placa', 1, GETDATE(), 1, 1);

	INSERT INTO Kategorija(Naziv, Aktivno, DatumVrijeme, TipKategorijaID, UserId)
	VALUES('Rezije', 1, GETDATE(), 1, 1);
	INSERT INTO Valuta(Zemlja, Oznaka, Tecaj, DatumVrijeme, Aktivno, UserId)
	VALUES('Hrvatska', 'Kn', 1.0, GETDATE(), 1, 1) 
	--INSERT INTO InicijalniPodaci([Naziv], [TipKategorijaID]) VALUES('', 1);

)
go

select * FROM TipKategorija

select k.Naziv, k.IDKategorija

FROM Kategorija as k
INNER JOIN TipKategorija as tip ON tip 

select * from UserProfile

select * from PrihodTrosak