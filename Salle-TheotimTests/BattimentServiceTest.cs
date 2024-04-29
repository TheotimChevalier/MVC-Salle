using NUnit.Framework;
using SalleTheotim.Models;
using SalleTheotim.Services;
using System.Collections.Generic;

namespace SalleTheotimTests
{
    [TestFixture]
    public class BatimentServiceTest
    {
        private readonly List<Batiment> batiments = new List<Batiment>();


        [Test]
        public void CreerBatimentTest()
        {

            BattimentService bService = new BattimentService();
            bService.SaisieUserServices = new SaisieMock();
            var batiment = (Batiment)bService.CreerBatimentSalle();
            Assert.AreEqual("123", batiment.Code);
            Assert.AreEqual("Batiment A", batiment.Nom);
            Assert.AreEqual("10 rue de la Liberté", batiment.Adresse);
            Assert.AreEqual("75001", batiment.CodePostal);
            Assert.AreEqual("Paris", batiment.Ville);
        }

        [Test]
 
        public void CreerSalleTest()
        {
            Batiment batiment = new Batiment
            {
                Nom = "oui",
                Code = "100",
                Adresse = "ok",
                CodePostal = "54321",
                Ville = "Grenoble",
                Salles = new List<Salle>() 
            };

            BattimentService bService = new BattimentService();
            bService.SaisieUserServices = new SaisieMock2();

            
            bService.lesBatiments.Add(batiment);

            var salle = (Salle)bService.CreerBatimentSalle();

            bService.AjouterSalle(salle); 

            Assert.IsNotNull(salle);
            Assert.AreEqual("456", salle.Code);
            Assert.AreEqual("Salle 101", salle.Nom);
            Assert.AreEqual(2, salle.Nbplace);
            Assert.AreEqual(batiment, salle.Batiment);
        }


        [Test]
        public void CalculerNombreTotalPlacesTest()
        {
            BattimentService bService = new BattimentService();
            bService.AjouterSalle(new Salle { Nbplace = 50 });
            bService.AjouterSalle(new Salle { Nbplace = 100 });
            bService.AjouterSalle(new Salle { Nbplace = 30 });
            Assert.AreEqual(180, bService.CalculerNombreTotalPlaces());
        }
    }

    public class SaisieMock : SaisiesUtilisateursService
    {
        public override int DemandeInt(string message)
        {
            return 1;
        }
        public override string DemandeString(string message)
        {
            if (message == "Veuillez indiquer le Code : ") { return "123"; }
            else if (message == "Veuillez indiquer le nom : ") { return "Batiment A"; }
            else if (message == "Adresse : ") { return "10 rue de la Liberté"; }
            else if (message == "CodePostal : ") { return "75001"; }
            else if (message == "Ville : ") { return "Paris"; }
            return string.Empty;
        }
    }

    public class SaisieMock2 : SaisiesUtilisateursService
    {
        private int count = 0;

        public override int DemandeInt(string message)
        {
            return 2;
        }

        public override string DemandeString(string message)
        {
            if (message == "Veuillez indiquer le Code : ")
            {
                return "456";
            }
            else if (message == "Veuillez indiquer le nom : ")
            {
                return "Salle 101";
            }
            else if (message == "Le code de Batiment : ")
            {
                return "100";
            }
            else if (message == "Le nom du batiment : ")
            {
                return "oui";
            }
            else if (message == "Veuillez indiquer l'ID du bâtiment parent : ")
            {
                return "1";
            }
            else
            {
                return string.Empty;
            }
        }
    }





}