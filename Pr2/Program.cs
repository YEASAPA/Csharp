namespace Pr2;

//Defineix la class program
class Program
{
    //Declara la funció main i que activi la funcio TriarEx
    static void Main(string[] args)
    {
        TriarEx();
    }
    
    //Ara declarem TriarEx
     static void TriarEx(){

        //Creem una string que és diu queTriar, y després et pregunta quin exercici vols probar, i tu poses el numeró.
        string? queTriar;
        Console.WriteLine("Exercici a provar? ");
        queTriar = Console.ReadLine();

        //Fem un switch amb el numeró que han posat a queTriar
        switch (queTriar)
        {
            //Si poses 1 et diu que és el exercici 1, i fem que el script esperi 1 segon:
            //NOTA: Tots els System.Threading.Thread.Sleep són decoratius per que quedi millor, no son obligatoris.
            case "1":
                Console.WriteLine("Exercici 1: Suma tots els números enters des de 13 fins a X número");
                System.Threading.Thread.Sleep(1000);
                
                //Declara el numero i el numero final després de la suma.
                int Numero;
                int NumeroFinal = 0;

                //Iniciem un bucle infinit
                while (true)
                {
                    //Demanem al usuari que posi un número superior a 13.
                    Console.WriteLine("Inserta un Numero superior al 13");
                    Numero =  Convert.ToInt32(Console.ReadLine());

                    //Si el numero és superior a 13 fem un bucle que nomès funciona mentrè numero no sigui igual a 13.
                    if (Numero > 13){
                        while (Numero != 13)
                        {
                            //En cada iteració del bucle numero es suma a numerofinal i es resta 1 a numero.
                            NumeroFinal += Numero;
                            Numero--;
                        }

                        //Quan acaba el bucle et diu el numero final i trenca el bucle
                        Console.WriteLine($"El numeró final és: {NumeroFinal}");
                        break;
                    }  
                    //Si és menor que 13 et diu que és invalid i que comencis de nou.
                    Console.WriteLine("Numeró Invalid, comença de nou");
                }
                //Trenca el bucle.
                break;

            //Si és l'exercici 2 diem que és el joc matematic i fem que el script s'esperi 1 segon.
            case "2":
                Console.WriteLine("Exercici 2: Joc matématic.");
                System.Threading.Thread.Sleep(1000);

            //Declarem les variables
            int Numero2;
            int NumerosPars = 0;
            int NumerosImpars = 0;
            int NumeroMarcador;
            int SumaNumeroPar = 0;
            int SumaNumeroImpar = 0;
            int Multiple13 = 0;

            //Demanem que posi un numero
            Console.WriteLine("Posa un numeró");
            Numero2 = Convert.ToInt32(Console.ReadLine());

            /*Creem "NumeroMarcador" que serà el que marci les iteracions ja que la posició nativa
            de C# és 1 menys de la que necessitem, i sempre sera el numero posat abans + 1*/
            NumeroMarcador = Numero2 + 1;


            //Fem un bucle que tindra d'iteracions NumeroMarcador
            for (int y = 0; y < NumeroMarcador; y++)
            {
                //Si la iteració actual és major que 0 (ja que el joc comença desde l'1).
                if (y > 0)
                {
                    //Si el residu és 0 (o sigui, que és par)
                    if(y % 2 == 0){
                        //Suma 1 a numeros pars i la iteració actual es suma a la suma total dels numeros pars
                        NumerosPars++;
                        SumaNumeroPar += y;
                    }
                    
                    //Si no (és impar)
                    else{
                        //Suma 1 a numeros impars i la iteració actual es suma a la suma total dels numeros impars
                        NumerosImpars++;
                        SumaNumeroImpar += y;
                    }
                    //Si la iteració actual / 13 dona 0 de residu (o sigui, multiple de 13).
                    if(y % 13 == 0){
                    //Sumem 1 al contador de multiples de 13.
                       Multiple13 ++; 
                    }

                }
            }
                //Escribim quants pars i impars hi ha, la suma d'aquests i quants multiples de 13 hi ha.
                Console.WriteLine($"Pars: {NumerosPars} Impars: {NumerosImpars}");
                Console.WriteLine($"Suma Pars: {SumaNumeroPar} Suma Impars: {SumaNumeroImpar}");
                Console.WriteLine($"Multiples de 13: {Multiple13}");

                //Trenquem el bucle.
                break;

            //Si és 3 li diem que és un pedra paper tisores i que s'esperi 1 segon el codi.
            case "3":
            Console.WriteLine("Exercici 3: Pedra, paper, tisores.");
            System.Threading.Thread.Sleep(1000);

            //Recordatori: 0 = pedra, 1 = paper, 2 = tisores.

            //Declarem que rnd és un nou valor aleatori.
            Random rnd = new Random();

            //Fem que cada jugador sigui assignat a un valor aleatori de rnd entre 0 i 3 (pero només agafa fins al 2).
            int jugador1 = rnd.Next(0,3);
            int jugador2 = rnd.Next(0,3);
            
            /*Aqui faig que el codi escrigui pedra... paper... tisores! utilitzant
            salts de linea i parades d'escriptura per donar-li un efecte humà.*/
            Console.Write("Pedra...\n");
            System.Threading.Thread.Sleep(1000);
            Console.Write("Paper...\n");
            System.Threading.Thread.Sleep(1000);
            Console.Write("Y tisores!\n");


            /*Si el Jugador 1 escolleix 0 (pedra), mira si el 2 té 0 (pedra) també
            i si no mira si te 1 (paper) o 2 (tisores), i així determina un guanyador o empat que escriu a la terminal.*/
            if(jugador1 == 0){
                if (jugador2 == 0)
                {
                    Console.Write("Empat, els dos han tret pedra");
                }
                else if(jugador2 == 1){
                    Console.Write("Ha guanyat el Jugador 2, ha tret paper i el Jugador 1 pedra.");
                }
                else{
                    Console.Write("Ha guanyat el Jugador 1, ha tret pedra i el Jugador 2 tisores.");
                }
            }

            /*Si el Jugador 1 escolleix 1 (paper), mira si el 2 té 0 (pedra),
            i si no mira si te 1 (paper) o 2 (tisores), i així determina un guanyador o empat que escriu a la terminal.*/
            else if(jugador1 == 1){
            if (jugador2 == 0)
                {
                    Console.Write("Ha guanyat el Jugador 1, ha tret paper i el Jugador 2 pedra.");
                }
                else if(jugador2 == 1){
                    Console.Write("Empat, els 2 han tret tisores.");
                }
                else{
                    Console.Write("Ha guanyat el Jugador 2, ha tret tisores i el Jugador 1 paper.");
                }
            }

            /*Si el Jugador 1 escolleix 2 (tisores, que és l'únic sobrant), mira si el 2 té 0 (pedra),
            i si no mira si te 1 (paper) o 2 (tisores), i així determina un guanyador o empat que escriu a la terminal.*/
            else{
                 if (jugador2 == 0)
                {
                    Console.Write("Ha guanyat el Jugador 2, ha tret pedra i el Jugador 1 tisores.");
                }
                else if(jugador2 == 1){
                    Console.Write("Ha guanyat el Jugador 1, ha tret tisores i el Jugador 2 paper.");
                }
                else{
                    Console.Write("Empat, els 2 han tret tisores.");
                }
            }
            
            //Trenca el codi
                break;
            
            //Si és el 4 et diu que és un simulador de caixa automatica i el codi s'espera 1 segon.
            case "4":
            Console.WriteLine("Exercici 4: Simulador de caixa automàtica");
            System.Threading.Thread.Sleep(1000);

            //Aquest és el meu favorit i en el que més coses he posat

            //Declara un saldo inicial, el número d'accio que fara l'usuari i el saldo a depositar
            int saldo = 5000;
            string? selecciousuari;
            int saldodepositar;

            /*Aqui fem una funció NOMÈS per retirar saldo ja que hi ha una cosa
            que només puc fer si és una funcio, li poso com a parametre saldo, i ref fa que 
            pugui agafar la variable saldo de fora.*/
            static void RetirarSaldo(ref int saldo){
            
            //Declarem el numeró de saldo a retirar
            int saldoretirar;

            //Declarem la string "intentardenou" per si posa un número invalid (veure més endavant)
            string? intentardenou;

                //Et pregunta quan vols retirar.
                Console.WriteLine("Quant vols retirar?");
                    saldoretirar = Convert.ToInt32(Console.ReadLine());

                    /*Si el saldo és més gran que la quantitat a retirar 
                    et diu que has retirat el saldo sense problemas, quant has retirat
                    i t'ho resta al saldo, després fent que el codi s'esperi 1 segon*/
                    if(saldo > saldoretirar){
                        saldo -= saldoretirar;
                        Console.Write($"Retirats {saldoretirar}€ sense problemes.");
                        System.Threading.Thread.Sleep(1000);
                    }

                    //Si el saldo a retirar és més gran:
                    else{

                        //Et diu que intentes retirar més del que tens, i si vols intentar de nou
                        Console.WriteLine("Error: Intentas retirar més del que tens, vols intentar de nou?\n1 - Si.\n2 - No\nPosa el número:");
                        
                        //Aqui "intentardenou" és el numeró que posaras.
                        intentardenou = Console.ReadLine();
                        
                        //Sí es "1" (sí), re-executa la funció despres d'un segon.
                        if(intentardenou == "1"){
                            System.Threading.Thread.Sleep(1000);
                            RetirarSaldo(ref saldo);
                        }

                        //Si diu que és 2 (no), retorna al codi després d'un segon.
                        else if(intentardenou == "2"){
                            System.Threading.Thread.Sleep(1000);
                            return;
                        }

                        //Qualsevol altre valor et dira qué és invalid i tornara al menú principal tras 1 segon.
                        else{
                            Console.WriteLine("Valor invalid, tornant al menú principal...");
                            System.Threading.Thread.Sleep(1000);
                            return;
                        }
                    }
            }
            
            //Ara que la funció existeix fem un bucle infinit
            while (true)
            {

                /*Demanem amb decoració que vols fer donant una benvinguda, entre mig algunes pausades
                per que quedi millor*/
                Console.Write("---------\n---------\nBenvingut al caixer automatic! Que vols fer?\n");
                Console.Write("1 - Retirar\n2 - Depositar\n3 - Consultar saldo\n---------\n---------\n0: Sortir\n");
                System.Threading.Thread.Sleep(700);
                Console.Write("Inserta el teu número: ");
                selecciousuari = Console.ReadLine();
                System.Threading.Thread.Sleep(1000);

                //Si l'usuari selecciona 0 (sortir), és trenca el programa
                if (selecciousuari == "0"){
                    break;
                }

                //Si selecciona 1 (retirar), s'executa la funció de retirar.
                else if(selecciousuari == "1"){
                    RetirarSaldo(ref saldo);
                }

                //Si es selecciona 2 (depositar), et demana quan vols depositar
                else if(selecciousuari == "2"){
                    Console.WriteLine("Quant vols depositar?");
                    saldodepositar = Convert.ToInt32(Console.ReadLine());

                    //És suma la quantitat al teu saldo i et diu quant has depositat, torna al codi tras 1 segon.
                    saldo += saldodepositar;
                    Console.Write($"Depositats {saldodepositar}€ sense problemes.");
                    System.Threading.Thread.Sleep(1000);
                }

                //Si selecciona 3 et diu el teu saldo actual i torna al codi tras 1 segon
                else if(selecciousuari == "3"){
                    Console.WriteLine($"El teu saldo és de {saldo}€");
                    System.Threading.Thread.Sleep(1000);
                }

                //Si poses qualsevol altre cosa et dira que és invalid i que intentis de nou (tras 1 segon).
                else{
                    Console.WriteLine("Número invalid, intenta de nou.");
                    System.Threading.Thread.Sleep(1000);
                }
            }

                //Trenca el codi
                break;

            //Si és el 5 cas, et diu que és una simulació de gestionar lloguers i s'espera 1 segon
            case "5":
            Console.WriteLine("Exercici 5: Simulador de gestor de lloguers");
            System.Threading.Thread.Sleep(1000);


            //Declarem les variables
            int edad;
            int ingressosmensuals;
            string? referencialloguer;
            int infracciotransit;

            //Demanem la edad i comprobem que sigui valida, si no ho diem i trenquem el codi
            Console.WriteLine("Inserta la teva edat: ");
            edad = Convert.ToInt32(Console.ReadLine());

            if (edad < 21 || edad > 65){
                Console.WriteLine("Edat invalida");
                break;
            }

            //Demanem els ingressos mensuals i comprobem que siguin valids, si no ho diem i trenquem el codi
            Console.WriteLine("Inserta els teus ingressos mensuals: ");
            ingressosmensuals = Convert.ToInt32(Console.ReadLine());

             if(ingressosmensuals < 2500){
                Console.WriteLine("Ingressos mensuals invalids");
                break;
            }

            /*Demanem si va tenir una referència de lloguer anterior positiva en número
            i comprobem primer que sigui un número que hem demanat, si no ho diem i trenquem el codi.
            Si ho hem demanat però la resposta es "no" també s'ho informem i trenquem el codi*/
            Console.Write("Vas tenir una referència de lloguer anterior positiva?\n1- Si\n2- No.\nPosa un numeró: ");
            referencialloguer = Console.ReadLine();

            if(referencialloguer != "1" && referencialloguer != "2"){
                Console.WriteLine("Número de referencia de lloguer invalid.");
                break;
            }

            else if(referencialloguer == "2"){
                Console.WriteLine("No acceptem gent amb una referència de lloguer anterior negativa.");
                break;}


            /*Demanem el nombre d'infraccions de trànsit greus registrades en els últims 5 anys.
            Si és major que 1 li diem que és invalid i trenquem el codi*/
            Console.WriteLine("Inserta el nombre d'infraccions de trànsit greus registrades en els últims 5 anys: ");
            infracciotransit = Convert.ToInt32(Console.ReadLine());

            if(infracciotransit > 1){
                Console.WriteLine("No acceptem gent amb més de 1 infracció de trànsit greu registrada en els últims 5 anys.");
                break;
            }

                //Si totes les condicions han donat false li diem que cumpleix les condicions i trenquem el codi
                Console.WriteLine("Molt bé! Cumpleixes les condicions!");
                break;
            

            //Qualsevol altre valor que no sigui un exercici:
            default:

                //Li diem que és un exercici invalid i tornem a executar la funció per triar un exercici.
                Console.WriteLine("Exercici no vàlid, torna a escullir si us plau.\n");
                TriarEx();

                //Trenquem el codi
                break;
        }
    }
}
