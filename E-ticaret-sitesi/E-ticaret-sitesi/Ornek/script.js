
// Bu fonksiyon, dosya seçildiğinde çağrılır.
function dosyaSecildi(input) {
    // Seçilen dosyanın adını al
    var dosyaAdi = input.files[0].name;

    // Konsola dosya adını yaz
    console.log('Seçilen dosya: ' + dosyaAdi); 
}
