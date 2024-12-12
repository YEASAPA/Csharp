//Utilitzem system
using System;

//Definim el nom del programa C#
namespace Pr1
{

//Creem la clase programa
  class Program
  {
    
    //Posem el main del codi que executi la funcio de triar exercici
    static void Main(string[] args)
    {
      TriarEx();
    }
    
    //Fem apareixer la funció de triar exercici i posem a dins el codi
    static void TriarEx()
    {
      /*Demanem l'exercici que provaras en String? (El ? està explicat en un altre comentari més a baix)
      La avantatge de fer-ho en string en comptes de int és que no ho hem de convertir
      i que si l'exercici és invalid i es una lletra no petara el codi, sino que actuara com a qualsevol altre digit invalid*/
        string? queTriar;
        Console.WriteLine("Exercici a provar? ");
        queTriar = Console.ReadLine();

        //Fem un switch dels exercicis que hi ha
        switch (queTriar)
        {       
          
          //En cas del primer exercici
            case "1":

                //Diem a la consola que aquest es el Exercici 1 y que es tracta de revisar la teva cistella
                Console.WriteLine("Exercici 1");
                Console.WriteLine("Revisa la teva cistella de productes.");

                /*Definim les variebles preus i descompte en decimal, i els noms dels productes en string?. 
                (El ? es posa per que el sistema no es queixi, en aqui no fa res pero serveix per si la string té valor null que es pugui llegir)*/
                decimal preu1;
                decimal preu2;
                decimal descompte;
                string? nomProducte1;
                string? nomProducte2;
                
                //Demanem tots els noms i preus, i descompte si n'hi ha, si no li demanem al usuari que posi 0
                Console.WriteLine("Quin és el primer producte?");
                nomProducte1 = Console.ReadLine();

                Console.WriteLine("Quin és el preu del primer producte?");
                preu1 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Quin és el segon producte?");
                nomProducte2 = Console.ReadLine();

                Console.WriteLine("Quin és el preu del segon producte?");
                preu2 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Insereix % de Descompte, si no hi ha posa 0");
                descompte = Convert.ToDecimal(Console.ReadLine());

                //Fem les operacions per tenir el preu total
                decimal preuNoDescompte = preu1 + preu2;
                decimal preuTotal = preuNoDescompte - descompte / 100 * preuNoDescompte;

                //Li diem al client quins son els seus productes i el preu total
                Console.WriteLine($"El total dels productes {nomProducte1} y {nomProducte2} és {preuTotal}€");

                //Apaguem el codi
                break;
            
            //En cas del segon exercici
            case "2":

                //Li diem que es el exercici 2 i que calcularas l'area d'un rectangle
                Console.WriteLine("Exercici 2");
                Console.WriteLine("Càlcula l'areà d'un rectangle");
                
                //Definim els costats, el area que posaras i l'area correcte en decimal
                decimal costat1;
                decimal costat2;
                decimal area;
                decimal areaCorrecte;
                
                //Demanem els costats
                Console.Write("Inserta tamany del primer costat en cm: ");
                costat1 = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Inserta tamany del segon costat en cm: ");
                costat2 = Convert.ToDecimal(Console.ReadLine());

                //Demanem el area que creus que dona
                Console.Write("Inserta tamany del area en cm: ");
                area = Convert.ToDecimal(Console.ReadLine());

                //Fem que el sistema calculi l'area correcta
                areaCorrecte = costat1 * costat2;

                /*Si el area calculada i el que has posat son la mateixa et diu que ho has fet bé
                Si no, et diu que ho has fet malament*/
                if (area == areaCorrecte)
                {
                Console.Write($"Ben fet! El resultat son {areaCorrecte} cm");                 
                }
                else
                {
                Console.Write($"Incorrecte! El resultat son {areaCorrecte} cm");                  
                }

                //Apaguem el codi
                break;

            //Si es el exercici 3
            case "3":

                //Li diem que és el exercici 3 i que faras una equació de segon grau
                Console.WriteLine("Exercici 3");
                Console.WriteLine("Fes una equació de segon grau:");

                //Demanem en numeros enters el A, B, C i els calculs en double ja que sempre seran decimals
                int A;
                int B;
                int C;
                double equaciomes;
                double equaciomenys;
                double imaginarytechniquehollowpurple;
                double amplified;
                double reversal;

                //Demanem les 3 lletres
                Console.Write("Inserta el numero A: ");
                A = Convert.ToInt32(Console.ReadLine());

                Console.Write("Inserta el numero B: ");
                B = Convert.ToInt32(Console.ReadLine());

                Console.Write("Inserta el numero C: ");
                C = Convert.ToInt32(Console.ReadLine());

                /*Fem que amplified sigui B al cuadrat
                I que reversal sigui 4AC, finalment imaginarytechniquehollowpurple es restar B al cuadrat - 4AC
                (Els noms de les variables son una referencia a un anime)*/
                amplified = Math.Pow(B, 2);
                reversal = 4 * A * C;
                imaginarytechniquehollowpurple = amplified - reversal;

                /*Si amplified és mes petit que reversal (que B al cuadrat sigui més petit que 4AC, o sigui, un numero negatiu)
                Fes que es trenqui el codi dient-te que és un numero imaginari, quin és i que no es pot completar per això*/
                if (amplified < reversal)
                  {
                    Console.WriteLine($"Aquesta equació dona un numero imaginari, no es pot completar. El numeró és: {imaginarytechniquehollowpurple}"); 
                    break;
                  }
                
                //Si no és cumpleix lo enterior fa els 2 calculs de segon grau, un amb un "+" i el altre amb un "-"
                equaciomes = (-B + Math.Sqrt(imaginarytechniquehollowpurple)) / 2 * A;
                equaciomenys = (-B - Math.Sqrt(Math.Pow(B, 2) - 4 * A * C)) / 2 * A;    

                //T'escriu quins son els resultats amb "+" i amb "-"
                Console.WriteLine($"Resultat amb +: {equaciomes}");          
                Console.WriteLine($"Resultat amb -: {equaciomenys}"); 

                //S'apaga el codi
                break;

              //Si és qualsevol altre opció
              default:

                /*Et diu que això no és un exercici valid, fa un salt de linia a la terminal i reinicia el codi
                autoexecutant la funció i apagant el codi actual per deixar el proces al nou*/
                Console.Write("Això no és un exerici valid\n");
                TriarEx();
                break;
   
        }

    }
  }
}
