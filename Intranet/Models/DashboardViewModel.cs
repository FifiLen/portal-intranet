
using System.Collections.Generic;

namespace Intranet.Models 
{
    public class SalesChartData
    {
        public List<string> Labels { get; set; } = new List<string>(); 
        public List<decimal> Values { get; set; } = new List<decimal>(); 
    }

    public class DashboardViewModel
    {
        
        public string DzisiejszaSprzedaz { get; set; }
        public int ZamowieniaDoRealizacji { get; set; }
        public int ProduktyNaWyczerpaniu { get; set; }
        public int DzisiejsiKlienci { get; set; }
        public List<Zamowienie> OstatnieZamowienia { get; set; }

        
        public SalesChartData? SprzedazTygodniowaChartData { get; set; }
        public List<Ogloszenie> Ogloszenia { get; set; }

        public List<Zadanie> MojeZadania { get; set; }
        public List<Wydarzenie> NadchodzaceWydarzenia { get; set; }

        public DashboardViewModel()
        {
            OstatnieZamowienia = new List<Zamowienie>();
            DzisiejszaSprzedaz = "0 zł";
            ZamowieniaDoRealizacji = 0;
            ProduktyNaWyczerpaniu = 0;
            DzisiejsiKlienci = 0;
            SprzedazTygodniowaChartData = new SalesChartData();
            Ogloszenia = new List<Ogloszenie>();
            MojeZadania = new List<Zadanie>();
            NadchodzaceWydarzenia = new List<Wydarzenie>();
        }
    }
}
