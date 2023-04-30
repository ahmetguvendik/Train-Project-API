using System;
using TrenAPI.Models;

namespace TrenAPI.Inrerfaces
{
	public interface IRezervasyonService
	{
        List<YerlesimAyrinti> RezervasyonYap(Rezervasyon rezervasyon);
    }
}

