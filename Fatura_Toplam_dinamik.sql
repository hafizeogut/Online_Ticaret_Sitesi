--"TUTAREKLE" adlý tetikleyici, FATURAKalems tablosuna yeni bir kayýt eklendiðinde devreye girecektir.
Create Trigger TUTAREKLE
ON FATURAKalems
AFTER INSERT 
AS

 -- Eklenen kayýtýn faturaid ve tutar bilgilerini tutacak deðiþkenler tanýmlanmýþtýr.
DECLARE @Faturaid int 
Declare @Tutar decimal(18,2)
Select @Faturaid=faturaid,@tutar=tutar from inserted

 -- Faturalars tablosundaki ilgili fatura için toplam tutarý güncelle.
update Faturalars set Toplam=Toplam+@Tutar where Faturaid=@Faturaid