using SalleTheotim.Models;
using SalleTheotim.Services;
using System;
using System.Runtime.Serialization;
// récupération des données utilisateurs
SaisiesUtilisateursService SaisieUserService = new SaisiesUtilisateursService();
InteractionsUtillisateurService InteractUserService = new InteractionsUtillisateurService();
BattimentService PService = new BattimentService();

while (true)
{
    int entreeMenu = SaisieUserService.DemandeInt(@"Que voulez vous faire ?
1. Créer Battiment/salle, 
2. Afficher les Batiments
3. Afficher les Salle
4. Afficher nombre Place Total
5. Afficher Detaille Batiment
10. Quitter");
    if (entreeMenu == 1)
    {
        Lieu p = PService.CreerBatimentSalle();
    }
    else if (entreeMenu == 2)
    {
        PService.AfficherLesBattiments();
    }
    else if (entreeMenu == 3)
    {
        PService.AfficherLesSalles();
    }
    else if (entreeMenu == 4)
    {
        PService.CalculerNombreTotalPlaces();
    }
    else if (entreeMenu == 5)
    {
        PService.AfficherDetailsBatiments();
    }
    
    else if (entreeMenu == 10)
    {
        break;
    }
    else
    {
        InteractUserService.AfficherMessages("entrée invalide");
    }
    // pour attendre que l'utilisateur veuille bien quitter
    InteractUserService.AttendrePourQuitter();
}





