using System;
using System.Collections.Generic;
using TrenAPI.Inrerfaces;
using TrenAPI.Models;

namespace TrenAPI.Repositories
{
 
    public class RezervasyonService : IRezervasyonService
    {
        public List<YerlesimAyrinti> RezervasyonYap(Rezervasyon rezervasyon)
        {
            Tren tren = rezervasyon.Tren;
            int kisiSayisi = rezervasyon.RezervasyonYapilacakKisiSayisi;
            bool farkliVagonlaraYerlestirilebilir = rezervasyon.KisilerFarkliVagonlaraYerlestirilebilir;

            List<YerlesimAyrinti> yerlesimAyrinti = new List<YerlesimAyrinti>();

            foreach (var vagon in tren.Vagonlar)
            {
                int kalanKoltukSayisi = vagon.Kapasite - vagon.DoluKoltukAdet;
           
                double dolulukOrani = (double)vagon.DoluKoltukAdet / vagon.Kapasite;


                if (kalanKoltukSayisi >= kisiSayisi && dolulukOrani < 0.7)
                {
                    if (farkliVagonlaraYerlestirilebilir)
                    {
                        YerlesimAyrinti ayrinti = new YerlesimAyrinti();
                        ayrinti.VagonAdi = vagon.Ad;
                        ayrinti.KisiSayisi = kisiSayisi;
                        yerlesimAyrinti.Add(ayrinti);
                        break;
                    }
                    else
                    {
                        YerlesimAyrinti ayrinti = new YerlesimAyrinti();
                        ayrinti.VagonAdi = vagon.Ad;
                        ayrinti.KisiSayisi = kisiSayisi;
                        yerlesimAyrinti.Add(ayrinti);
                        kisiSayisi = 0;
                    }
                }
                else if (kalanKoltukSayisi > 0)
                {
                    if (farkliVagonlaraYerlestirilebilir)
                    {
                        YerlesimAyrinti ayrinti = new YerlesimAyrinti();
                        ayrinti.VagonAdi = vagon.Ad;
                        ayrinti.KisiSayisi = kalanKoltukSayisi;
                        yerlesimAyrinti.Add(ayrinti);
                        kisiSayisi -= kalanKoltukSayisi;
                    }
                }

             
             

                if (kisiSayisi == 0)
                {
                    break;
                }
            }



            bool rezervasyonYapilabilir = yerlesimAyrinti.Count > 0;
            return yerlesimAyrinti;
        }

  
    }
}



