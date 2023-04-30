using System;
namespace TrenAPI.Models
{
    public class Rezervasyon
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }

        public List<YerlesimAyrinti> RezervasyonYap(Rezervasyon rezervasyon)
        {
            List<YerlesimAyrinti> yerlesimAyrinti = new List<YerlesimAyrinti>();

          
            foreach (var vagon in rezervasyon.Tren.Vagonlar)
            {
              
                int bosKoltukSayisi = vagon.Kapasite - vagon.DoluKoltukAdet;                
                int kisiSayisi = Math.Min(bosKoltukSayisi, rezervasyon.RezervasyonYapilacakKisiSayisi);

            }

            return yerlesimAyrinti;
        }

    }
}
