namespace Pr4;
class Program
{
    //Defineixes Main
    static void Main(string[] args)
    {   
        //Inicies la funció TriarEx()
       TriarEx();
    }

    //Ara declarem la funció TriarEx()
    static void TriarEx(){

        //Li diem que escolleixi un exercici i que utlitzi 5 per a sortir.
        Console.Write("Escolleix un exercici, escriu 5 per sortir: ");
        string? triarEx = Console.ReadLine();

        //Fem un switch amb el que ha escollit
        switch (triarEx)
        {
            //Si escolleix 1, li diem quin exercici és i de que es tracta.
            case "1":
                Console.WriteLine("Exercici 1: Passant hores a Hores:Minuts:Segons");

                //Declarem segons i li demanem quants vol posar.
                int segons;
                Console.Write("Inserta quants segons vols posar: ");
                segons = Convert.ToInt32(Console.ReadLine());

                /*Declarem els minuts i les hores a partir dels segons.
                segonssobrants servira per posar els segons que sobren despres dels minuts i hores*/
                int minuts = segons / 60;
                int hores = minuts / 60;
                int segonssobrants = segons - minuts * 60 - hores * 3600;
                
                //Posem que està calculant com a decoració
                 System.Threading.Thread.Sleep(1000);
                 Console.Write("Calculant. ");
                System.Threading.Thread.Sleep(1000);
                Console.Write(". ");
                System.Threading.Thread.Sleep(1000);
                Console.Write(". ");
                System.Threading.Thread.Sleep(1000);
                
                //Donem el resultat i tornem a la funció.
                Console.WriteLine($"Aquest és el teu resultat: {hores}:{minuts}:{segonssobrants}");
                TriarEx();
                break;

            //Si escolleix 2, li diem que és el exercici 2 i de que es tracta.
            case "2":
            Console.WriteLine("Exercici 2: Suma i quants parells i senars té una array random.");
            
            //Declarem una variable random, una que serà un valor per a més tart, la suma del array, els parells i els senars.
            Random random = new Random();
            int valor;
            int sumaArray = 0;
            int parells = 0;
            int senars = 0;

            //Declarem una llista buida de integrals que es diu lista
            List<int> lista = new List<int>();

            //Iniciem un bucle que es fara 500 vegades
            for (int i = 0; i < 500; i++)
            {
                //Fem que valor es redeclari a un valor random, i que s'afageici a llista.
                valor = random.Next();
                lista.Add(valor);

                //Fem que és sumi al valor total de les arrays i al comptadors de parells o senars dependent que és.
                sumaArray += valor;
                if (valor % 2 == 0){
                    parells ++;
                }
                else{
                    senars++;
                }
            }

            //Posem que s'esta calculant com a decoració.
            System.Threading.Thread.Sleep(1000);
            Console.Write("Calculant. ");
            System.Threading.Thread.Sleep(1000);
            Console.Write(". ");
            System.Threading.Thread.Sleep(1000);
            Console.Write(". ");
            System.Threading.Thread.Sleep(1000);

            //Et diu la suma, els parells i els senars.
            Console.WriteLine($"La suma dels numeros aleatoris és: {sumaArray}");
            Console.WriteLine($"Hi ha {parells} números parells");
            Console.WriteLine($"Hi ha {senars} números senars");

                //Re-inicia la funció.
                TriarEx();
                break;

            //Si escolleix 3, li diem que és el exercici 3 i de que es tracta.
            case "3":
            Console.WriteLine("Exercici 3: Suma els digits d'un número.");

            //declarem numero com a string, i la suma dels digits com a 0.
            string? numero;
            int sumadigits = 0;

            /*Li demanem un numero, i per que no es queixi el compilador diem
            que si és buit o null que es declari com una string buida utilitzant String.IsNullOrEmpty.*/
            Console.Write("Inserta un numero per sumar els seus digits: ");
            numero = Console.ReadLine();
            if (String.IsNullOrEmpty(numero))
            {
                numero = "";
            }
            
            //Fem una array de caracters que es diu arrayNumeros.
            char[] arrayNumeros = numero.ToCharArray();

            //Un bucle que duri el numero de caracters que té numero.
            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                /*Fem que és sumi el valor numeric de arrrayNumeros[i].
                (int) es posa perque ho agafa com a double.
                i Char.GetnumericValue s'utilitza perque arrayNumeros[i] s'esta agafant
                com a caracter ASCII i no el seu valor numeric individual.*/
                sumadigits += (int)Char.GetNumericValue(arrayNumeros[i]);

                //Si és la ultima iteració posem el caracter final i = la suma i saltem de linea
                if (i == arrayNumeros.Length - 1){
                    Console.Write($"{arrayNumeros[i]} = {sumadigits}\n");
                }

                //Si no posa la iteracio actual + i un espai.
                else{
                Console.Write($"{arrayNumeros[i]} + ");}
                System.Threading.Thread.Sleep(1000);
            }
            //Li diem que la suma és la suma dels digits.
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"La suma dels digits de {numero} és {sumadigits}");

                //Reiniciem la funció
                TriarEx();
                break;
    	
            //Si escolleix 4, li diem que és el exercici 4 i de que es tracta.
            case "4":
            Console.WriteLine("Exercici 4: Calcula un perímetre.");

            //Declarem les 2 coorenades
            int coordenadaX;
            int coordenadaY;

            //Diem que indici la base i altura.
            Console.Write("Inserta la base: ");
            coordenadaX = Convert.ToInt32(Console.ReadLine());

            Console.Write("Inserta l'altura: ");
            coordenadaY= Convert.ToInt32(Console.ReadLine());

            //El perimetre sera la multiplicació d'aquests 2.
            int perimetre = coordenadaX * coordenadaY;
            
            //Diem que està calculant per decoració
            Console.Write("Calculant. ");
                System.Threading.Thread.Sleep(1000);
                Console.Write(". ");
                System.Threading.Thread.Sleep(1000);
                Console.Write(". ");
                System.Threading.Thread.Sleep(1000);

            //Li diem que (X, Y) = Periemtre.
            Console.WriteLine($"({coordenadaX}, {coordenadaY}) = {perimetre}");

                //Reiniciem la funció
                TriarEx();
                break;

            case "5":

                //Si escolleix 5 li diem que adeu i surt amb decoració
                Console.WriteLine("Vale, adeu!");
                System.Threading.Thread.Sleep(1000);
                Console.Write("Sortint. ");
                System.Threading.Thread.Sleep(1000);
                Console.Write(". ");
                System.Threading.Thread.Sleep(1000);
                Console.Write(". ");
                System.Threading.Thread.Sleep(1000);
                break;

            default:

                //Si posa qualsevol altre valor diem que no és valid i reinicia la funció.
                Console.WriteLine("Opció no valida. Torna a intentar-ho si us plau.");
                TriarEx();
                break;
        }
    }
}

