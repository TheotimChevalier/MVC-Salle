using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalleTheotim.Models
{
    public class Lieu
    {
        public string Code { get; set; }
        public string Nom { get; set; }

    }

    public class Batiment : Lieu
    {
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public List<Salle> Salles { get; set; }


        public List<Salle> lesSalles = new List<Salle>();
    }


    public class Salle : Lieu {
        public int Nbplace { get; set; }
        public Batiment Batiment { get; set; }
    }
}