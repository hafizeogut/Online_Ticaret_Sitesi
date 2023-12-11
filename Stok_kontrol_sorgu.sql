Create Trigger SatisStokAzalt
On SatisHarekets
After insert
as


/*De�i�kenler declare ile olusturuldu.*/
Declare @Urunid int
Declare @Adet int

 /* Inserted tablosundan Uruns ve Adet bilgilerini al */
Select @Urunid =Urunid, @Adet = Adet from inserted

/* Stok azaltma i�lemi - Uruns tablosunda ilgili �r�n�n stok miktar�n� g�ncelleme */
Update Uruns set stok=Stok-@Adet where Urunid=@Urunid