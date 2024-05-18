--"TUTAREKLE" adl� tetikleyici, FATURAKalems tablosuna yeni bir kay�t eklendi�inde devreye girecektir.
Create Trigger TUTAREKLE
ON FATURAKalems
AFTER INSERT 
AS

 -- Eklenen kay�t�n faturaid ve tutar bilgilerini tutacak de�i�kenler tan�mlanm��t�r.
DECLARE @Faturaid int 
Declare @Tutar decimal(18,2)
Select @Faturaid=faturaid,@tutar=tutar from inserted

 -- Faturalars tablosundaki ilgili fatura i�in toplam tutar� g�ncelle.
update Faturalars set Toplam=Toplam+@Tutar where Faturaid=@Faturaid