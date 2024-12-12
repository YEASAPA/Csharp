namespace Pr3;
class Program
{
    //Iniciem Main
     static void Main(string[] args){

        //Inciem la funcio per triar l'exercici
        TriarEx();
     }

    //Definim la funció per triar exercici.
    static void TriarEx()
    {

    //Definim com a string que triaras
    string? queTriar;

    //Li preguntem que exercici fara i iniciarem un switch amb el número que trii.
    Console.WriteLine("Exercici a provar? ");
    queTriar = Console.ReadLine();
    switch (queTriar)
{
    //Si és el 1
    case "1":

    //Declarem la variable random i un int que es diu NumeroRandom on almacenarem el resultat de random.
        Random random = new Random();
        int NumeroRandom;

        //Declarem arrayrandom que sera l'array que guardara els numeros random.
        List<int> arrayrandom = new List<int>();

        //Fem un bucle que es fara 55 vegades
        for (int i = 0; i < 55; i++){

        //A cada iteració s'inventara un número i la posara a la següent posició d'arrayrandom.
        NumeroRandom = random.Next(2,2259);
        arrayrandom.Add(NumeroRandom);
        }
        
        /*Declarem el minim i el màxim de l'array, IMPORTANT, després de que s'hagi omplenat 
        o sigui, després del bucle, o sino ens donara error.*/
        int minim = arrayrandom.Min();
        int maxim = arrayrandom.Max();

        //Diem per terminal quin és el més petit i el més gran.
        Console.WriteLine($"El numeró més petit és: {minim}.\nEl numeró més gran és: {maxim}.");

        //Trenquem el codi.
        break;

    //Si és el exercici 2
    case "2":

        //Declarem la variable random2 per a valors random i NumeroRandom2 que serà el contenedor dels números random.
        Random random2 = new Random();
        int NumeroRandom2;

        //Declarem l'array de valors aleatoris.
        List<int> arrayrandom2 = new List<int>();

        //Declarem on aniran tots els multiples de 4 i de 11.
        int mult4 = 0;
        int mult11 = 0;

        //Iniciem un bucle que fa 333 iteracions.
        for (int i = 0; i < 333; i++){

        //A cada iteració es pensa un número i ho posa a arrayrandom2, i suma el número pensat a MitjanaArray2.
        NumeroRandom2 = random2.Next(2,2259);
        arrayrandom2.Add(NumeroRandom2);

        /*Finalment a cada iteracio mira si NumeroRandom2 és multiple de 4 o de 11.
        I en cas positiu suma 1 al contador de multiples de 4 o de 11.*/ 
        if(NumeroRandom2 % 4 == 0){
            mult4 ++;
        }
        if(NumeroRandom2 % 11 == 0){
            mult11 ++;
        }
        }

        /*Definim MitjanaArray2 que en int et diu la mitjana de l'array arrayrandom2.
        Linq és un paquet en el sistema que deixa fer consultes.*/
        int MitjanaArray2 = Convert.ToInt32(System.Linq.Enumerable.Average(arrayrandom2));

        //Finalment et diem la mitjana de l'array, els multiples de 4 i 11 i trenquem el codi.
        Console.WriteLine($"Mitjana de tota l'array: {MitjanaArray2}.\nMultiples de 4: {mult4}.\nMultiples de 11: {mult11}.");
        break;

    //Si poses el exercici 3
    case "3":

    //Definim un contador per cada vocal i la string de la frase.
    int vocalA = 0;
    int vocalE = 0;
    int vocalI = 0;
    int vocalO = 0;
    int vocalU = 0;
    string? frase;

    /*Li demanem la frase i especifiquem que si la frase és nula la deixi buida. 
    (No és necessari pero m'evita una advertencia del codi)*/
    Console.Write("Inserta una frase: ");
    frase = Console.ReadLine();
    if (frase == null){
        frase = "";
    }

    //Fem un bucle tan llarg com la mida de frase.
    for (int i = 0; i < frase.Length; i++)
    {
        //Definim lletra que es el caracter actual d'aquesta iteració.
        char lletra = frase[i];

        //Si lletra actual és a, e, i, o, u suma 1 al seu contador.
        if(lletra == 'a'){
            vocalA++;
        }

        if(lletra == 'e'){
            vocalE++;
        }

        if(lletra == 'i'){
            vocalI++;
        }

        if(lletra == 'o'){
            vocalO++;
        }

        if(lletra == 'u'){
            vocalU++;
        }
    }

    /*Acaba el bucle i fem que el codi s'esperi un segon (això sempre sera per pura decoració).
    I li diem quantes a, e, i, o, u té la frase. \u0022 són " però per que el sistema no és queixi de que estic sortint de la string.*/
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine($"Hi han {vocalA} \u0022A\u0022, Hi han {vocalE} \u0022E\u0022, Hi han {vocalI} \u0022I\u0022, Hi han {vocalO} \u0022O\u0022, Hi han {vocalU} \u0022U\u0022");
        
        //Trenquem el codi.
        break;

    //Si diu 4
    case "4":

            //Definim saldo i la selecció del usuari.
            int saldo = 5000;
            string? selecciousuari;

            //Creem la funcio TreureSaldo amb la referencia de saldo com a parametre.
            static void TreureSaldo(ref int saldo){
            
            //Dins de la funció creem saldoretirar i intentardenou que serà una cosa per després.
            int saldoretirar;
            string? intentardenou;

                //Preguntem quan vols retirar.
                Console.WriteLine("Quant vols retirar?");
                    saldoretirar = Convert.ToInt32(Console.ReadLine());

                    //Si el saldo és més gran que la quantitat a retirar es retira, es resta a saldo i el codi s'espera 1 segon.
                    if(saldo > saldoretirar){
                        saldo -= saldoretirar;
                        Console.Write($"Retirats {saldoretirar}€ sense problemes.");
                        System.Threading.Thread.Sleep(1000);
                    }


                    //Si no.
                    else{
                        
                        /*Li informem del error i li diem si vols intentar de nou usant la variable intentardenou
                        1 = Sí, 2 = No*/
                        Console.WriteLine("Error: Intentas retirar més del que tens, vols intentar de nou?\n1 - Si.\n2 - No\nPosa el número:");
                        intentardenou = Console.ReadLine();
                        
                        //Si intentar de nou és 1 (si), s'espera un segon i torna a iniciar la funció.
                        if(intentardenou == "1"){
                            System.Threading.Thread.Sleep(1000);
                            TreureSaldo(ref saldo);
                        }

                        //Sí és 2 (No), s'espera 1 segon i surt de la funció.
                        else if(intentardenou == "2"){
                            System.Threading.Thread.Sleep(1000);
                            return;
                        }

                        //Qualsevol altre valor diu que és invalid i torna al menú principal esperant-se un segon i sortint de la funció.
                        else{
                            Console.WriteLine("Valor invalid, tornant al menú principal...");
                            System.Threading.Thread.Sleep(1000);
                            return;
                        }
                    }
            }

            //Creem la funció AfegirSaldo donant-li com a parametre la referencia de saldo.
            static void AfegirSaldo(ref int saldo){
                
                //Definim el saldo a depositar.
                int saldodepositar;

                //Preguntem quan vols depositar
                Console.WriteLine("Quant vols depositar?");
                    saldodepositar = Convert.ToInt32(Console.ReadLine());

                    //Sumem el saldo depositat al saldo, li informem que s'ha depositat sense problemes i esperem 1 segon per tornar al menú.
                    saldo += saldodepositar;
                    Console.Write($"Depositats {saldodepositar}€ sense problemes.");
                    System.Threading.Thread.Sleep(1000);
            }            

            //Creem la funció MirarSaldo i li donem la referència de saldo com a parametre.
            static void MirarSaldo(ref int saldo){

                //Et diu quan saldo actual tens, s'espera 1 segon i torna al menú.
                Console.WriteLine($"El teu saldo és de {saldo}€");
                System.Threading.Thread.Sleep(1000);
            }

            //Iniciem un bucle infinit
            while (true)
            {
                
                /*Et demanem el numeró amb una benvinguda i decoracions, incluint parades de codi per què quedi millor.
                (Aqui s'usa la variable selecciousuari)*/
                Console.Write("---------\n---------\nBenvingut al caixer automatic! Que vols fer?\n");
                Console.Write("1 - Retirar\n2 - Depositar\n3 - Consultar saldo\n---------\n---------\n0: Sortir\n");
                System.Threading.Thread.Sleep(700);
                Console.Write("Inserta el teu número: ");
                selecciousuari = Console.ReadLine();
                System.Threading.Thread.Sleep(1000);

                //Si escull 0 (sortir) li despedim, esperem 1 segon i se'n va del codi.
                if (selecciousuari == "0"){
                    Console.Write("Vale, Adeu!");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }

                //Si esculleix 1 (retirar) iniciem la funció TreureSaldo amb la referència de saldo com a parametre.
                else if(selecciousuari == "1"){
                    TreureSaldo(ref saldo);
                }

                //Si esculleix 2 (depositar) iniciem la funció TreureSaldo amb la referència de saldo com a parametre.
                else if(selecciousuari == "2"){
                    AfegirSaldo(ref saldo);
                }

                //Si esculleix 3 (consultar) iniciem la funció TreureSaldo amb la referència de saldo com a parametre.
                else if(selecciousuari == "3"){
                    MirarSaldo(ref saldo);
                }

                //Si posa alguna cosa invalida li diem que és invalid, s'espera 1 segon i torna al menú.
                else{
                    Console.WriteLine("Número invalid, intenta de nou.");
                    System.Threading.Thread.Sleep(1000);
                }
            }
                //Trenquem el codi
                break;

    //Si escolleix qualsevol cosa que no és un exercici           
    default:

        //Li diem que és invalid, tornem a executar TriarEx i trenquem el codi.
        Console.Write("Exercici no valid, torna a provar.");
        TriarEx();
        break;
}

    }
}
