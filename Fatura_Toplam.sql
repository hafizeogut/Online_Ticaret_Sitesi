UPDATE  Faturalars SET Toplam=(Select SUM(TUTAR) FROM FaturaKalems WHERE Faturaid=4) 
WHERE Faturaid=4