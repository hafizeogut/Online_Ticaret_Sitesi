Create Trigger SatisStokAzalt
On SatisHarekets
After insert
as


/*Deðiþkenler declare ile olusturuldu.*/
Declare @Urunid int
Declare @Adet int

 /* Inserted tablosundan Uruns ve Adet bilgilerini al */
Select @Urunid =Urunid, @Adet = Adet from inserted

/* Stok azaltma iþlemi - Uruns tablosunda ilgili ürünün stok miktarýný güncelleme */
Update Uruns set stok=Stok-@Adet where Urunid=@Urunid