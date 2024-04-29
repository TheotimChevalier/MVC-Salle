using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalleTheotim.Services
{
    public class SaisiesUtilisateursService
    {
        public static InteractionsUtillisateurService InteractUserServices { get; set; } = new InteractionsUtillisateurService();
        public virtual int DemandeInt(string message)
        {
            int result;
            while (true)
            {
                string userInput = DemandeString(message);
                if (int.TryParse(userInput, out result) == false)
                {
                    Console.WriteLine("Idiot, saisie incorrecte, faut un nombre");
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public virtual string DemandeString(string message)
        {
            string result;
            while (true)
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Idiot, saisie incorrecte, faut pas laisser vide");
                }
                else
                {
                    result = userInput;
                    break;
                }
            }
            return result;
        }
    }
}
