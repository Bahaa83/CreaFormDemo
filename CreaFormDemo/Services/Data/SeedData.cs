using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.LifestyleModel.Habits;
using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Entitys.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.Data
{
    public class SeedData
    {
        private readonly CreaFormDBcontext db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public SeedData(CreaFormDBcontext _db,UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            db = _db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedUserData()
        {
            #region //lagra Roles
            if (!_roleManager.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin" },
                    new Role { Name = "Advisor" },
                    new Role { Name = "Client" },
                };
                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }
            }
                #endregion
                #region//lagra Admin
                if (!_userManager.Users.Any())
                {

                var adminuser = new UserModel()
                {
                    UserName = "Bahaa"
                };
            IdentityResult result= _userManager.CreateAsync(adminuser, "Admin1983").Result;
                _userManager.AddToRoleAsync(adminuser, "Admin").Wait();
                }
            #endregion
            #region   //lagra data i livsstil område
            string[] lifestyleAreas = { "Vanor", "Arbete", "Privat" };
            string[] VanorKategori = { "Vätske-intag", "Kost-näring", "Måltids-vanor", "Stimu-lantia", "Sömn", "Stress-återhämtning", "Fysisk aktivitet", "Droger" };
            if (!  db.lifestyleAreas.Any())//
            {
                for (int i = 0; i < lifestyleAreas.Length; i++)
                {
                    var lifestyle = new LifestyleArea()
                    {
                        Name = lifestyleAreas[i]

                    };
                    db.lifestyleAreas.Add(lifestyle);
                }
                 SaveCHanges();
            }

            if(! db.habitsCategories.Any())//lagra data i Vanor Kategori
            {
                for (int i = 0; i < VanorKategori.Length; i++)
                {
                    var categoryname = new HabitsCategory()
                    {
                        CategoryName= VanorKategori[i],
                        LifestyleAreaID=1
                    };
                    db.habitsCategories.Add(categoryname);
                   
                }
                 SaveCHanges();
            }
            #endregion
            #region  lagrar data i Symtom
            string[] Symptomscategory =new string[] { "Energi och sömn", " Känslomässig balans", "Kognitiv kapacitet ",
                "Sinnesorgan aptit törst", "Munhålan", "Temperaturreglering", "Smärta ", "Muskler balans kroppskontroll",
                "Mage-tarm", "Immunförsvaret", "Hjärta och cirkulation", "Njurar urinvägar", "Hormonellt", "Hår hud naglar", };
            string[] EnergyAndSleep = new string[]{ "Svårt att somna", "Sover dåligt/störd sömn", "Trött på morgonen", "Trött stora delar av dagen", "Kraftlöshet/orkeslöshet", "Allmän sjukdomskänsla" };
            string[] Emotionalbalance = new string[] { "Brist på tålamod", "Lättretlig/irritabilitet", "Blir lätt aggressiv", "Nedstämd/depression", "Känslo-/humörsvängningar", "Gråtmildhet", "Rastlöshet", "Apati/olust/likgiltighet", "Orolig/nervös", "Ångest/panikångest", "Uppvarvad/hyperaktiv" };
            string[] Cognitivecapacity = new string[]{ "Minnesproblem", "Nedsatt stresshanteringsförmåga", "Svårt/orkar inte/tänka/klart/", "Beslutsångest", "Koncentrationssvårigheter" };
            string[] Sensoryorgans = new string[] { "Ljuskänslig", "Dimmig/suddig syn", "Ser fläckar/prickar framför ögonen/ljusblixtar", "Dubbelseende/tunnelseende", "Nattblindhet", "Svullnad över/under/runt ögonen", "Gruskänsla i ögonen",
                "Torra ögon", "Vattniga ögon/ökat tårflöde", "Kliande ögon", "Ögoninflammation","Ögonryckningar" ,"Gulfärgade ögonvitor","Ljudöverkänslig","Tinnitus, brus eller ringningar i örat","Luktsinnet har blivit sämre","Känner mig hela tiden hungrig","Aptitlöshet","Stark törst","Sällan törstig"};
            string[] Theoralcavity = new string[] { "Inflammationer i tandköttet (blödande)", "Munsår", "Blåsor i munnen", "Sprickor i mungiporna", "Muntorrhet",
                "Ökad salivutsöndring", "Dålig andedräkt", "Tungan har en synlig vit beläggning", "Svullen tunga", "Tandlossning"};
            string[] Temperaturecontrol = new string[] { "Fryser lätt", "Känner mig alltid varm (het)", "Vallningar",
                "Ansiktshetta", "Brännande känsla i  t ex händer/fötter", "Alltid kall om endast händer/fötter", "Svettas aldrig eller mycket sällan", "Svettas mycket lätt", "Kallsvettningar", "Illaluktande svett" };
            string[] Pain = new string[]{ "Huvudvärk", "Migrän", "Nervsmärtor", "Smärta annan. Specificera vad/var i det grå fälten på följ rade",
                "Stelhet i kroppen", "Vissa delar av kroppen domnar lätt bort / stickningar", "Myrkrypningar, restless legs" };
            string[] Muscles = new string[] { "Dålig balans", "Yrsel", "Nedsatt reaktionsförmåga / långsamma reflexer", "Rörelsesvårigheter", "Skakningar/darrningar t ex i händer", "Muskelkramp", "Snarkar" };
            string[] Gastrointestinal = { "Förstoppning", "Diarré", "Gaser", "Svullen buk", "Trött efter måltid",
                "Buksmärta", "Illamående", "Halsbränna", "Sura uppstötningar", "Rapningar", "Sväljsvårigheter","Hungersugningar i magtrakten","Smärta över leverområdet (under lungan på höger sida)" };
            string[] Theimmunesystem = new string[] { "Ofta förkyld", "Ofta lätt feberstegring", "Ofta luftvägsinfektioner", "Ofta halsfluss / ont i halsen",
                "Ofta halsfluss / ont i halsen", "Vid insjuknande tar det veckor innan jag blir frisk",
                "Heshet", "Hosta", "Slembildning", "Harklar ofta", "Nästäppa","Försämrad sårläkning","Blöder lätt","Allergiska reaktioner" };
            string[] Heart = new string[] { "Andfådd vid lättare aktivitet", "Andnöd vid vila", "Torrhosta under natten",
                "Bröstsmärta/känner tryck mot bröstkorgen", "Vid bröstsmärta kan smärtan kännas ut mot armar eller nacke" +
                "Hjärtklappning", "Oregelbundna/snabba eller dunkande hjärtslag", "Åderbråck", "Näsblod" };
            string[] Kidneysurinarytract = new string[] { "Behöver ofta kissa", "Mörk urin", "Vaknar mer än en gång på natten av att jag behöver gå på toaletten",
                "Ofta urinvägsinfektion", "Smärtsam/svår urinering", "Vätskekvarhållning", "Svullnad i benområdena"};
            string[] Hormonal = new string[]{ "PMS", "Menstruationssmärtor", "Oregelbundna menstruationer", "Uteblivna menstruationer",
                "Rikliga menstruationer", "Nedsatt libido/sexlust", "Flytningar", "Ofta ömma bröst", "Övergångsbesvär", "Prostatabesvär", "Brösttillväxt hos män" };
            string[] Hairskinnails = new string[]{ "Eksem", "Acne / bölder", "Andra hudutslag", "Vårtor", "Herpes",
                "Hudklåda", "Blåmärken uppkommer lätt", "Torr hud och/eller flagnande hud", "Torra händer/torra fötter",
                "Vita fläckar i huden (vitiligo)", "Hudrodnad","Hudbristningar/sträckmärken","Hudsprickor","Celluliter","Knottror på huden på överarmar,lår,stjärt",
                "Torrt hår","Fett hår","Håravfall (ej årstidsbetingat)","Flagnande hårbotten","Mörka ringar under ögonen",
                "Sköra naglar","Räfflade naglar","Nagelsvamp eller svamp på huden" };
           
            if (! db.symptomsCategories.Any())//lagra data i Symtom Kategori
            {
                for (int i = 0; i < Symptomscategory.Length ; i++)
                {
                    var Scategoryname = new SymptomsCategory()
                    {
                        Name = Symptomscategory[i].ToLower(),
                        OrderBy= i+1
                    };
                    db.symptomsCategories.Add(Scategoryname);
                    SaveCHanges();
                }
                 //SaveCHanges();
            }
            if(! db.symptomQuestions.Any())//lagra data i Symtom 
            {
                for (int i = 0; i < EnergyAndSleep.Length; i++)
                {
                    var energyandsleep = new SymptomQuestions()
                    {
                        FråganText = EnergyAndSleep[i].ToLower(),
                        SymptomsCategoryID=1
                        
                    };
                    db.symptomQuestions.Add(energyandsleep);
                }
                SaveCHanges();
                for (int i = 0; i < Emotionalbalance.Length; i++)
                {
                    var emotionalbalance = new SymptomQuestions()
                    {
                        FråganText = Emotionalbalance[i].ToLower(),
                        SymptomsCategoryID = 2

                    };
                    db.symptomQuestions.Add(emotionalbalance);
                }
               SaveCHanges();
                for (int i = 0; i < Cognitivecapacity.Length; i++)
                {
                    var cognitivecapacity = new SymptomQuestions()
                    {
                        FråganText = Cognitivecapacity[i].ToLower(),
                        SymptomsCategoryID = 3

                    };
                    db.symptomQuestions.Add(cognitivecapacity);
                }
                SaveCHanges();
                for (int i = 0; i < Sensoryorgans.Length; i++)
                {
                    var sensoryorgans = new SymptomQuestions()
                    {
                        FråganText = Sensoryorgans[i].ToLower(),
                        SymptomsCategoryID = 4

                    };
                    db.symptomQuestions.Add(sensoryorgans);
                }
                SaveCHanges();
                for (int i = 0; i < Theoralcavity.Length; i++)
                {
                    var theoralcavity = new SymptomQuestions()
                    {
                        FråganText = Theoralcavity[i].ToLower(),
                        SymptomsCategoryID = 5

                    };
                    db.symptomQuestions.Add(theoralcavity);
                }
               SaveCHanges();
                for (int i = 0; i < Temperaturecontrol.Length; i++)
                {
                    var temperaturecontrol = new SymptomQuestions()
                    {
                        FråganText = Temperaturecontrol[i].ToLower(),
                        SymptomsCategoryID = 6

                    };
                    db.symptomQuestions.Add(temperaturecontrol);
                }
                SaveCHanges();
                for (int i = 0; i < Pain.Length; i++)
                {
                    var pain = new SymptomQuestions()
                    {
                        FråganText = Pain[i].ToLower(),
                        SymptomsCategoryID = 7

                    };
                    db.symptomQuestions.Add(pain);
                }
                SaveCHanges();
                for (int i = 0; i < Muscles.Length; i++)
                {
                    var muscles = new SymptomQuestions()
                    {
                        FråganText = Muscles[i].ToLower(),
                        SymptomsCategoryID = 8

                    };
                    db.symptomQuestions.Add(muscles);
                }
                SaveCHanges();
                for (int i = 0; i < Gastrointestinal.Length; i++)
                {
                    var gastrointestinal = new SymptomQuestions()
                    {
                        FråganText = Gastrointestinal[i].ToLower(),
                        SymptomsCategoryID = 9

                    };
                    db.symptomQuestions.Add(gastrointestinal);
                }
                SaveCHanges();
                for (int i = 0; i < Theimmunesystem.Length; i++)
                {
                    var theimmunesystem = new SymptomQuestions()
                    {
                        FråganText = Theimmunesystem[i].ToLower(),
                        SymptomsCategoryID = 10

                    };
                    db.symptomQuestions.Add(theimmunesystem);
                }
                SaveCHanges();
                for (int i = 0; i < Heart.Length; i++)
                {
                    var heart = new SymptomQuestions()
                    {
                        FråganText = Heart[i].ToLower(),
                        SymptomsCategoryID = 11

                    };
                    db.symptomQuestions.Add(heart);
                }
                SaveCHanges();
                for (int i = 0; i < Kidneysurinarytract.Length; i++)
                {
                    var kidneysurinarytract = new SymptomQuestions()
                    {
                        FråganText = Kidneysurinarytract[i].ToLower(),
                        SymptomsCategoryID = 12

                    };
                    db.symptomQuestions.Add(kidneysurinarytract);
                }
                SaveCHanges();
                for (int i = 0; i < Hormonal.Length; i++)
                {
                    var hormonal = new SymptomQuestions()
                    {
                        FråganText = Hormonal[i].ToLower(),
                        SymptomsCategoryID = 13

                    };
                    db.symptomQuestions.Add(hormonal);
                }
               SaveCHanges();
                for (int i = 0; i < Hairskinnails.Length; i++)
                {
                    var hairskinnails = new SymptomQuestions()
                    {
                        FråganText = Hairskinnails[i].ToLower(),
                        SymptomsCategoryID = 14

                    };
                    db.symptomQuestions.Add(hairskinnails);
                }
                SaveCHanges();
                



            }
            #endregion
            #region//Lagra data i Frekvens
            string[] Frekvenstext = { "Hela dagen/flera gånger om dagen", "Någon gång varje dag", "Nästan varje dag", "Någon gång i veckan", "Någon gång i månaden/ periodvis", "Någon gång om året eller ännu mer sällan" };
            int[] FrekvensValue = { 10, 9, 7, 5, 3, 1 };
            if (! db.frequencies.Any())
            {
                for (int i = 0; i < Frekvenstext.Length; i++)
                {
                    var frekvenstext = new Frequency()
                    {
                        frequencyText = Frekvenstext[i],
                       Value = FrekvensValue[i]

                    };
                    db.frequencies.Add(frekvenstext);
                }
                SaveCHanges();
            }
            #endregion
            #region //lagra data i Difficulty
            int[] Difficulty = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            if(! db.difficulties.Any())
            {
                for (int i = 0; i < Difficulty.Length; i++)
                {
                    var difficulty = new Difficulty()
                    {
                        Value = Difficulty[i]
                    };
                    db.difficulties.Add(difficulty);
                }
              SaveCHanges();
               

            }
            #endregion

        }

            private void SaveCHanges()
            {
                db.SaveChanges();
            }
            //private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsald)
            //{
            //   using(var hmac= new System.Security.Cryptography.HMACSHA512())
            //    {
            //        passwordsald = hmac.Key;
            //        passwordhash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            //    }
            //}
        }
}
