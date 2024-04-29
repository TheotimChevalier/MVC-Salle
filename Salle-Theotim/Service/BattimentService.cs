using SalleTheotim.Models;
using System.Text.Json.Serialization;

namespace SalleTheotim.Services
{

    public class BattimentService
    {
        public InteractionsUtillisateurService InteractUserServices { get; set; } = new InteractionsUtillisateurService();
        public SaisiesUtilisateursService SaisieUserServices { get; set; } = new SaisiesUtilisateursService();

        public List<Batiment> lesBatiments = new List<Batiment>();
        public List<Salle> lesSalles = new List<Salle>();


        public void AfficherLesBattiments()
        {
            foreach (Batiment batiment in lesBatiments)
            {
                InteractUserServices.AfficherMessages($"Code : {batiment.Code}");
                InteractUserServices.AfficherMessages($"Nom : {batiment.Nom}");
                InteractUserServices.AfficherMessages($"Adresse : {batiment.Adresse}");
                InteractUserServices.AfficherMessages($"CodePostal : {batiment.CodePostal}");
                InteractUserServices.AfficherMessages($"Ville : {batiment.Ville}");
            }
        }




        public void AfficherDetailsBatiments()
        {
            foreach (Batiment batiment in lesBatiments)
            {
                InteractUserServices.AfficherMessages($"Nom du bâtiment : {batiment.Nom}");
                InteractUserServices.AfficherMessages($"Code Postal : {batiment.CodePostal}");
                InteractUserServices.AfficherMessages($"Nombre de places : {CalculerNombrePlacesBatiment(batiment)}");
                InteractUserServices.AfficherMessages("----------------------------------------");
            }
        }

        public int CalculerNombrePlacesBatiment(Batiment batiment)
        {
            int totalPlaces = 0;
            foreach (Salle salle in batiment.Salles)
            {
                totalPlaces += salle.Nbplace;
            }
            return totalPlaces;
        }



        public void AfficherLesSalles()
        {
            foreach (Salle salle in lesSalles)
            {
                InteractUserServices.AfficherMessages($"Code : {salle.Code}");
                InteractUserServices.AfficherMessages($"Nom : {salle.Nom}");
                InteractUserServices.AfficherMessages($"Nbplace : {salle.Nbplace}");
            }
        }


        public void AjouterBatiments(Batiment p)
        {
            lesBatiments.Add(p);
        }

        public void AjouterSalle(Salle p)
        {
            lesSalles.Add(p);
        }


        public Lieu CreerBatimentSalle()
        {
            int TypesCreations = SaisieUserServices.DemandeInt(@"Que voulez-vous faire ?
1. Créer un Batiment
2. Créer une Salle");

            if (TypesCreations == 1 || TypesCreations == 2)
            {
                if (TypesCreations == 1)
                {
                    Batiment p = new Batiment();
                    p.Code = SaisieUserServices.DemandeString("Veuillez indiquer le Code : ");
                    p.Nom = SaisieUserServices.DemandeString("Veuillez indiquer le nom : ");
                    p.Adresse = SaisieUserServices.DemandeString("Adresse : ");
                    p.CodePostal = SaisieUserServices.DemandeString("CodePostal : ");
                    p.Ville = SaisieUserServices.DemandeString("Ville : ");

                    lesBatiments.Add(p);
                    return p;
                }
                else if (TypesCreations == 2)
                {
                    Salle p = new Salle();
                    p.Code = SaisieUserServices.DemandeString("Veuillez indiquer le Code : ");
                    p.Nom = SaisieUserServices.DemandeString("Veuillez indiquer le nom : ");

                    int nbPlaces = SaisieUserServices.DemandeInt("Nbplace : ");
                    p.Nbplace = nbPlaces;

                    AfficherLesBattiments();
                    int choixBatiment;
                    do
                    {
                        choixBatiment = SaisieUserServices.DemandeInt("Sélectionnez le bâtiment associé à cette salle : ");
                        if (choixBatiment < 0 || choixBatiment >= lesBatiments.Count)
                        {
                            InteractUserServices.AfficherMessages("Choix de bâtiment invalide. Veuillez réessayer.");
                        }
                    } while (choixBatiment < 0 || choixBatiment >= lesBatiments.Count);

                    p.Batiment = lesBatiments[choixBatiment];
                    lesBatiments[choixBatiment].Salles.Add(p); 
                    lesSalles.Add(p);
                    return p;
                }
            }
            else
            {
                throw new InvalidOperationException("Choix invalide.");
            }
            return null;
        }






        public int CalculerNombreTotalPlaces()
        {
            int totalPlaces = 0;
            foreach (Salle salle in lesSalles)
            {
                totalPlaces += salle.Nbplace;
            }
            return totalPlaces;
        }


    }
}