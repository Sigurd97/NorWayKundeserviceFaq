using NorWayKundeserviceFaq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorWayKundeserviceFaq.DataBase
{
    public class DbInitializer
    {
        public static void Initialize(FaqDbContext context)
        {
            // Allerede data i databasen
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new[]
            {
                new Category
                {
                    Name = "Admin"
                },
                new Category
                {
                    Name = "Avganger"
                },
                new Category
                {
                    Name = "Billett"
                },
                new Category
                {
                    Name = "Kvittering"
                },
                new Category
                {
                    Name = "Stasjoner"
                }
            };
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();
            var questions = new[]
            {
                new Question
                {
                    Message = "Hvem er Admin?",
                    Answer = "Personer som arbeider hos Vy kundeservice",
                    CategoryId = context.Categories.Single( c => c.Name == "Admin").CategoryId
                },
                new Question
                {
                    Message = "Hvordan kan jeg bli admin?",
                    Answer = "Begynn hos Vy kundeservice",
                    CategoryId = context.Categories.Single( c => c.Name == "Admin").CategoryId
                },
                new Question
                {
                    Message = "Kan admin kjøpe billett for meg?",
                    Answer = "Nei! Strengt forbudt.",
                    CategoryId = context.Categories.Single( c => c.Name == "Admin").CategoryId
                },
                new Question
                {
                    Message = "Hvor mange avganger går det i timen?",
                    Answer = "Se avgangstabellen på vår nettside",
                    CategoryId = context.Categories.Single( c => c.Name == "Avganger").CategoryId
                },
                new Question
                {
                   Message = "Kan det komme flere avganger hos meg?",
                   Answer = "Vi vurderer antallet avganger basert på antallet personer som bruker linjen. Hvis etterspørselen er stor så vil vi deretter vurdere om flere avganger er nødvendige.",
                   CategoryId = context.Categories.Single( c => c.Name == "Avganger").CategoryId
                },
                new Question
                {
                   Message = "Hva slags type billetter fins det?",
                   Answer = "Vi har billetter for \"studenter\", \"barn\", og \"voksne\".",
                   CategoryId = context.Categories.Single( c => c.Name == "Billett").CategoryId
                },
                new Question
                {
                   Message = "Hva er aldersgrensen på ungdomsbillett?",
                   Answer = "Før fyllte 18 år.",
                   CategoryId = context.Categories.Single( c => c.Name == "Billett").CategoryId
                },
                new Question
                {
                   Message = "Hvem bestemmer prisen for billettens?",
                   Answer = "Vy velger sprisene i samsvar med våre kunder og aksjonærer",
                   CategoryId = context.Categories.Single( c => c.Name == "Billett").CategoryId
                },
                new Question
                {
                   Message = "Er kvitteringen et gyldig bevis for kjøpt billett?",
                   Answer = "Kvittering er gyldig, men vi forbeholder oss retten til å verifisere at kvitteringen er gyldig.",
                   CategoryId = context.Categories.Single( c => c.Name == "Kvittering").CategoryId
                },
                new Question
                {
                   Message = "Hvorfor er stasjonen stengt?",
                   Answer = "Det kan være mange grunner til det. Ring kundeservice for mere informasjon.",
                   CategoryId = context.Categories.Single( c => c.Name == "Stasjoner").CategoryId
                },
                new Question
                {
                   Message = "Hvem har ansvar for måking av stasjonen?",
                   Answer = "Vi har et sammarbeid med kommunene hvor vi opererer i for å holde stasjonene rene.",
                   CategoryId = context.Categories.Single( c => c.Name == "Stasjoner").CategoryId
                },
                new Question
                {
                   Message = "Kan det bygges en stasjon nermere meg?",
                   Answer = "Vi bygger hele tiden ut nye strekninger og stasjon. Hvis du ønsker flere stasjoner, eller en nærmere deg så kan du ringe oss på kundeservice, eller sende epost.",
                   CategoryId = context.Categories.Single( c => c.Name == "Stasjoner").CategoryId
                }
            };
            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
