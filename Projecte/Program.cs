namespace Projecte;

/*IMPORTANT: Tots els Thread.Sleep son per mera decoració, el que fan és que el codi es pausi els milisegons indicats.
És util per donar sensació de carrega entre altres.*/

/*Utilitzare NAudio.Wave, un packet per poder reproduir audio a la terminal.
L'usare per poder posar música i efectes de so a vegades.*/
using NAudio.Wave;
class Program
{
    static void Main(string[] args)
    {
        //En el main hi haura les 2 funcions principals, la pantalla de carrega i el casino.
        PantallaCarrega();
        IniciarCasino();
    }

    //Declarem la pantalla de carrega
    static void PantallaCarrega(){

        /*Aqui primer declarem la funcio per reproduir so a la pantalla de carrega
        El 2 en el nom és perquè va ser el segon que vaig fer, ja que havia de fer un per
        el casino */
        void ReproduirSo2(string? arxiu, int pausasistema){
        
        //Tot el codi de la funció és el us estandar de la documentació de NAudio. Igualment l'explicare.
        
        //Primer crea una "funció" que s'executa en aquell instant (using) amb una variable que almacena la ruta del arxiu a reproduir.
        using (var audioFile = new AudioFileReader(arxiu))

            //Ara fa un altre funció amb la variable com a esvediment que reprodueix el arxiu.
            using (var outputDevice = new WaveOutEvent())
            {
                //Primer es prepara el arxiu al output i despres es reprodueix.
                outputDevice.Init(audioFile);
                outputDevice.Play();

                /*Aquest és perquè el codi s'esperi mentre el so es reprodueix, perquè si no ignora el so
                i es segueix executant sense que soni l'arxiu. També serveix per fer un minidelay al final del so.*/
                while (outputDevice.PlaybackState == PlaybackState.Playing){
                    Thread.Sleep(pausasistema);
                }
            }
    }
        //Ara s'escriu una pantalla de carrega decorada per pantalla.
        Console.WriteLine("**************************************************");
        Console.WriteLine("*                                                *");
        Console.WriteLine("*           Benvinguts al Casino Dreemurr!       *");
        Console.WriteLine("*           Carregant, esperi si us plau...      *");
        Console.WriteLine("*       +---------+   +---------+   +---------+  *");
        Console.WriteLine("*       |  777777 |   |  777777 |   |  777777 |  *");
        Console.WriteLine("*       |    77   |   |    77   |   |    77   |  *");
        Console.WriteLine("*       |   77    |   |   77    |   |   77    |  *");
        Console.WriteLine("*       |  77     |   |  77     |   |  77     |  *");
        Console.WriteLine("*       | 77      |   | 77      |   | 77      |  *");
        Console.WriteLine("*       +---------+   +---------+   +---------+  *");
        Console.WriteLine("*                                                *");
        Console.WriteLine("*              Saldo Inicial: 5000€              *");
        Console.WriteLine("*                                                *");
       
        /*Aqui sóna la canço en paralel deixant 100 milisegons de marge despres de que soni.
        Task.Run el que fa és que el codi dins de els {} s'executi paralelament en un altre fil
        del nucli perquè no es bloqueji el programa.*/
        Task.Run(() => {
        ReproduirSo2("./CarregaMusicaBucle.mp3", 100);
        });
        Console.Write("*                 "); 
        
        //Aquest bucle simula els punts que apareixen lentament a la pantalla de carrega
        int maxPunts = 4; 
        for (int i = 0; i < maxPunts; i++)
        {
            Console.Write(".   "); 
            Thread.Sleep(3250);
        }

        //Acabem la impressió, fem que soni la canço del final i retornem al codi
        Console.Write("               *\n");
        Console.WriteLine("*                                                *");
        Console.WriteLine("**************************************************");
        ReproduirSo2("./CarregaMusicaFinal.mp3", 0);
        Thread.Sleep(1000);
        return;
    }

    //Declarem la funció que serà el casino
    static void IniciarCasino(){

        /*Declarem saldo, tots els double serà perquè es puguin posar decimals, el joc a escollir com a string buida
        I la aposta com a 0 de moment.*/
        double saldo = 5000;
        string? joc = "";
        double aposta = 0;

    //Posem una funció que serà la encarregada d'actualitzar el saldo. Que li sumara al saldo el que sigui declarat com a valor.
    void ActualitzarSaldo(ref double saldo, double valor){
            saldo += valor;
            return;
        }

    //La funció per veure el saldo, on com a parametre tindra el saldo
    void VeureSaldo(ref double saldo){

        //Primer comproba que el saldo no sigui 0, si es així et fa fora.
        if (saldo == 0){
            Thread.Sleep(1000);
            Console.Write("T'has quedat sense saldo, t'hem de fer fora!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        //Si no, et diu el teu saldo y retorna al codi
        else{
            Console.WriteLine($"Tens actualment {saldo} € de saldo");
            Thread.Sleep(1000);
            return;
        }
    }

    //Ara declarem la funció que servira en cas de necessitar gestionar errors.
    void errorhandler(ref double aposta, ref double saldo){

        /*Hi haura una string que es diu "elecció" on l'usuari dirà si vol tornar al menú principal o no.
        Això es veura més a fons en el cas particular de cada tros que necessiti el errorhandler.*/
        string? eleccio;
        Thread.Sleep(2000);
        Console.WriteLine("1 = Sí, 2 = No.");
        Console.Write("Inserta la teva resposta: ");
        eleccio = Console.ReadLine();

        //Aqui mentre eleccio no sigui 1 o 2 et fa intentar-ho de nou.
        while (eleccio != "1" && eleccio != "2"){
        Thread.Sleep(1000);
        Console.WriteLine("Resposta no vàlida. Intenta-ho de nou. 1 = Sí, 2 = No.");
        Console.Write("Inserta la teva elecció: ");
        eleccio = Console.ReadLine();
    }
        //Sí la elecció és 1, torna al menu principal.
        if (eleccio == "1"){
            Thread.Sleep(1000);
            Console.WriteLine("Vale, tornant al menú principal...");
            Thread.Sleep(1000);
            return;
        }

        //Sí la elecció és 2, torna al joc en el que estaba abans mitjançant la funció IniciarJoc.
        else if(eleccio == "2"){
            Thread.Sleep(1000);
            Console.WriteLine("Vale, tornant al joc...");
            Thread.Sleep(1000);
            IniciarJoc(ref saldo, ref joc, ref aposta);
        }

        //Sí no es reconeix la resposta torna al menú principal de totes formes.
        else{
            Thread.Sleep(1000);
            Console.Write("Resposta no vàlida, tornant al menú principal...");
            Thread.Sleep(1000);
            return;
        }

        //Aqui fem un return per evitar possibles errors.
        return;
    }

    //Aquí iniciem una funció que servira per saber si vols veure el saldo.
    void volsveuresaldo(){

        /*elecciosaldo veura si vols veure el saldo, si poses 1 fara la funció de veure saldo.
        Sí poses qualsevol altre cosa fara return.*/
        string? elecciosaldo;
        Thread.Sleep(2000);
        Console.WriteLine("Vols veure el teu saldo? 1 - Sí, Qualsevol altre cosa - No");
        Thread.Sleep(1000);
        Console.Write("Inserta la resposta: ");
        elecciosaldo = Console.ReadLine();

        if (elecciosaldo == "1"){
            VeureSaldo(ref saldo);
        }
        return;
    }

        //Iniciem la funció que fara de ruleta amb el saldo, el joc actual i la aposta.
        void Ruleta(ref double saldo, ref string? joc, ref double aposta){

            //Iniciem un try per si hi han errors
            try{
                
                //Iniciem un nou random que serà el número de la ruleta.
                Random random = new Random();
                int numruleta = random.Next(0,37);

                //Fem una string que sera la eleccio de la ruleta
                string? eleccioruleta; 

                //Fem un grup de numeros que seran els vermells i negres.
                int[] vermells = {1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36};
                int[] negres = {2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35};

                //I fem un grup de eleccions valides
                string[] eleccionsvalides = {"vermell", "negre", "parell", "imparell", "0", "1", "3", "5", "7", "9", "12", "14", "16", "18", "19", "21", "23", "25", "27", "30", "32", 
                "34", "36", "2", "4", "6", "8", "10", "11", "13", "15", "17", "20", "22", "24", "26", "28", "29", "31", "33", "35"};

                /*Preguntem a quina opció volen apostar i quines opcions tenen.
                Utilitzem ? perquè no doni l'advertencia de "possible null dereference" i 
                ToLower perquè la resposta sempre s'agafi en minuscules.*/
                Thread.Sleep(2000);
                Console.WriteLine("Posa o un numero del 0 al 36, vermell o negre o sí no parell o imparell");
                Thread.Sleep(1000);
                Console.Write("Inserta a quina casella apostaras: ");
                eleccioruleta = Console.ReadLine()?.ToLower();
                
                
                /*Si la eleccio de la ruleta no està en el grup d'eleccions valides no et deixa tirar.
                Et retorna els diners de la aposta i activa el errorhandler.*/
                if(!eleccionsvalides.Contains(eleccioruleta)){
                    Thread.Sleep(1000);
                    Console.WriteLine("Això no és un valor vàlid de la ruleta, vols tornar al menú principal?");
                    ActualitzarSaldo(ref saldo, aposta);
                    errorhandler(ref aposta, ref saldo);
                    return;
                }

                //Diem que està fent la tirada i fem un so de ruleta.
                Thread.Sleep(1000);
                Console.WriteLine("Fent la tirada...");
                ReproduirSo("./Ruleta.m4a", 100);

                /*Si la elecció es parell i el numeró ho es, li informem que ha guanyat.
                Li diem el numero i li donem la aposta * 2, amb un so de diners. 
                Finalment li preguntem si vol veure el saldo actual.*/
                if(numruleta % 2 == 0 && eleccioruleta == "parell"){
                    Thread.Sleep(1000);
                    Console.WriteLine($"Ha donat a {numruleta}! Has guanyat {aposta * 2}€!");
                    ActualitzarSaldo(ref saldo, aposta * 2);
                    ReproduirSo("./Diners.mp3",100);
                    volsveuresaldo();
                }

                /*Si la elecció es imparell i el numeró ho es, li informem que ha guanyat.
                Li diem el numero i li donem la aposta * 2, amb un so de diners. 
                Finalment li preguntem si vol veure el saldo actual.*/  
                else if(numruleta % 2 != 0 && eleccioruleta == "imparell"){
                    Thread.Sleep(1000);
                    Console.WriteLine($"Ha donat a {numruleta}! Has guanyat {aposta * 2}€!");
                    ActualitzarSaldo(ref saldo, aposta * 2);
                    ReproduirSo("./Diners.mp3",100);
                    volsveuresaldo();
                }

                /*Si la elecció es del grup vermell i el numeró ho es, li informem que ha guanyat.
                Li diem el numero i li donem la aposta * 2, amb un so de diners. 
                Finalment li preguntem si vol veure el saldo actual.*/
                else if(vermells.Contains(numruleta) && eleccioruleta == "vermell"){
                    Thread.Sleep(1000);
                    Console.WriteLine($"Ha donat a {numruleta} de color vermell! Has guanyat {aposta * 2}€!");
                    ActualitzarSaldo(ref saldo, aposta * 2);
                    ReproduirSo("./Diners.mp3",100);
                    volsveuresaldo();
                }
                
                /*Si la elecció es del grup negre i el numeró ho es, li informem que ha guanyat.
                Li diem el numero i li donem la aposta * 2, amb un so de diners. 
                Finalment li preguntem si vol veure el saldo actual.*/
                else if(negres.Contains(numruleta) && eleccioruleta == "negre"){
                    Thread.Sleep(1000);
                    Console.WriteLine($"Ha donat a {numruleta} de color negre! Has guanyat {aposta * 2}€!");
                    ActualitzarSaldo(ref saldo, aposta * 2);
                    ReproduirSo("./Diners.mp3",100);
                    volsveuresaldo();
                }

                /*Si la elecció es el mateix que el numeró, li informem que ha guanyat.
                Li diem el numero i li donem la aposta * 30, amb un so de diners. 
                Finalment li preguntem si vol veure el saldo actual.
                Utilitzem TryParse perquè es una funció que intenta convertir un string a int, si es pot
                retorna true i almaçena el resultat a la variable out, no com convert.toint32 que retornaria
                el numero ASCII i no ho detectaria com a número encara que dones.*/
                else if(int.TryParse(eleccioruleta, out int eleccioNum) && numruleta == eleccioNum){
                    Thread.Sleep(1000);
                    Console.WriteLine($"HA DONAT A {numruleta}!!!!! Has guanyat {aposta * 30}€!");
                    ActualitzarSaldo(ref saldo, aposta * 2);
                    ReproduirSo("./Diners.mp3",100);
                    volsveuresaldo();
                }

                //Si no acerta de cap manera.
                else{

                    //Si es vermell li diem el numero i el color i que no ha encertat res, posem un so de perdut.
                    if (vermells.Contains(numruleta)){
                        Thread.Sleep(1000);
                        Console.WriteLine($"Ha donat a {numruleta} de color vermell, una pena, no has encertat res.");
                        ReproduirSo("./Perdut.m4a", 100);
                    }
                    
                    //Si es negre li diem el numero i el color i que no ha encertat res, posem un so de perdut.
                    else if (negres.Contains(numruleta)){
                        Thread.Sleep(1000);
                        Console.WriteLine($"Ha donat a {numruleta} de color negre, una pena, no has encertat res.");
                        ReproduirSo("./Perdut.m4a", 100);    
                    }
                    
                    //Si no és cap color (0) li diem el numero només i que no ha encertat res, posem un so de perdut.
                    else{
                        Thread.Sleep(1000);
                        Console.WriteLine($"Ha donat a {numruleta}, una pena, no has encertat res.");
                        ReproduirSo("./Perdut.m4a", 100);
                    }

                //Preguntem si vols veure saldo
                volsveuresaldo();

                }
            }

            /*Si dona un error diem que no és un valor valid de la ruleta (que és l'unic Write), retornem els diners de la aposta
            i activem l'error handler.*/
            catch{
                Thread.Sleep(2000);
                Console.WriteLine("Això no és un valor vàlid de la ruleta, vols tornar al menú principal?");
                ActualitzarSaldo(ref saldo, aposta);
                errorhandler(ref aposta, ref saldo);
                return;
            }
        }

        //Declarem blackjack amb el saldo, el joc actual i la aposta com a parametres.
        void BlackJack(ref double saldo, ref string? joc, ref double aposta){

            //No fem try perquè l'unic input aqui està controlat.

            //Creem la llista de la mà del jugador i de la banca, i el valor aleatori que usarem.
            List<int> jugadorMa = new List<int>();
            List<int> bancaMa = new List<int>();
            Random randBJ = new Random();

            /*La funció que retornara un int RobarCarta
            Declarara carta com un numero aleatori entre 1 i 13
            el format "condicio ? true : false" és una manera més corta de
            fer if, si la carta es major que 10 retorna 10, si no retorna el
            valor de la carta. Això es fa perquè en el BJ existeixen la J, Q i K que
            en altres jocs són 11, 12 i 13, pero en el BJ totes aquestes son 10. 
            Li dono un tó més de BlackJack al codi.*/
            int RobarCarta()
            {
                int carta = randBJ.Next(1, 2); 
                return carta > 10 ? 10 : carta; 
            }

            /*La funcio CalcularTotal que te com a parametre la llista "ma" i retorna un int
            el total és la suma de mà, i els ases són totes les cartes en la mà que siguin = 1.
            Com que el às a blackjack pot actuar com a 11 o com a 1 en temps real depenent en que
            et benefici més, fem que si téns més d'un as en la mà i el valor actual + 10 és menys de 21
            (ha de ser + 10 perquè la carta del às ja és un 1, aleshores 1 + 10 = 11), es sumi 10 al total
            i es resti un às. Si el às fa que et pasis de 21 torna a ser 1 automaticament.
            
            Després de la llarga explicació dels ases, finalment retorna el total.*/
            int CalcularTotal(List<int> Ma)
            {
                int total = Ma.Sum();
                int ases = Ma.Count(c => c == 1);

                while (ases > 0 && total + 10 <= 21){
                    total += 10;
                }

                return total;
            }


            //Comença el jugador i la banca robant 2 cartas
            jugadorMa.Add(RobarCarta());
            jugadorMa.Add(RobarCarta());
            bancaMa.Add(RobarCarta());
            bancaMa.Add(RobarCarta());

            //Fem un so de robar cartas mentre li diem que roba les primeres cartes.
            Console.WriteLine("Robes les primeres cartes...");
            ReproduirSo("./RobarCartes.mp3", 400);
            
            /*Diem que les seves inicials son cada element de jugadorMa amb un delimitador que serien les ,
            String.Join faria que es veies cada element de jugadorMa amb una , entre element i element.
            També informem de que el total seria el calcul del total de jugadorMa.*/
            Console.WriteLine($"Les teves cartes inicials són: {string.Join(", ", jugadorMa)} (Total: {CalcularTotal(jugadorMa)})");
            Thread.Sleep(1500);

            //Fem un so de que picar la taula per simular que la banca ensenya una carta.
            ReproduirSo("./PicarTaula.mp3", 2000);
            Console.WriteLine($"La banca mostra una carta: {bancaMa[0]}");

            //Iniciem un bucle infinit per simular l'inici de la partida.
            while (true){
                /*Preguntem si vol plantar (p) o si vols robar (r).
                El parametre .ToUpper fa que s'agafi en majuscules automaticament. */
                Thread.Sleep(1000);
                Console.WriteLine("Vols plantarte o robar una carta? (Posa P per plantarte o R per robar)");
                Thread.Sleep(1000);
                Console.Write("Inserta la teva elecció: ");
                string? eleccio = Console.ReadLine()?.ToUpper();

                //Si posa "R" (robar)
                if (eleccio == "R"){
                    //Es roba una nova carta i es guarda en novaCarta, amb el so de robar carta.
                    int novaCarta = RobarCarta();
                    ReproduirSo("./Roba1Carta.mp3", 1000);

                    //S'afageix a la llista jugadorMa el valor novaCarta
                    jugadorMa.Add(novaCarta);
                    Console.WriteLine($"Has robat una carta: {novaCarta}");
                    Thread.Sleep(1000);

                    //Li diem la seva mà actual amb el metodè d'abans
                    Console.WriteLine($"La teva mà actual és: {string.Join(", ", jugadorMa)} (Total: {CalcularTotal(jugadorMa)})");

                    //Ara mira si s'ha passat de 21 o encara no.
                    if (CalcularTotal(jugadorMa) > 21){

                        //Sí és aixó diu que t'has passat de 21, has perdut i fa el so de quan perds i surt.
                        Thread.Sleep(1000);
                        Console.WriteLine("T'has passat de 21! Has perdut.");
                        ReproduirSo("./Perdut.m4a", 100);
                        return;
                    }
                }

                //Si posa "P" (plantarse)
                else if (eleccio == "P"){

                    //Fa el so de picar taula perquè et planes i diu amb quan et plantes i termina el bucle de robar.
                    ReproduirSo("./PicarTaula.mp3", 1000);
                    Console.WriteLine($"Et plantes amb: {string.Join(", ", jugadorMa)} (Total: {CalcularTotal(jugadorMa)})");
                    break;
                }

                //Si no selecciona cap d'això diu que no és vàlid i que torni a intentar-ho.
                else{
                    Thread.Sleep(1000);
                    Console.WriteLine("Opció no vàlida. Intenta-ho de nou.");
                }
            }

            //Les diem que les cartes de la banca inicials són i les ensenyo:
            Thread.Sleep(1000);
            Console.WriteLine($"Les cartes inicials de la banca són: {string.Join(", ", bancaMa)} (Total: {CalcularTotal(bancaMa)})");
            
            //Mentre el total de la banca no es passi de 17 (un bon número per parar).
            while (CalcularTotal(bancaMa) < 17){

                //Fem una variable que és diu novaCarta que guarda el valor de RobarCarta i reproduim el só per simular que roba una carta.
                int novaCarta = RobarCarta();
                bancaMa.Add(novaCarta);
                ReproduirSo("./Roba1Carta.mp3", 1000);

                //Diem quina carta ha robat i informem de la mà actual
                Console.WriteLine($"La banca roba una carta: {novaCarta}");
                Thread.Sleep(1000);
                Console.WriteLine($"Les cartes de la banca són ara: {string.Join(", ", bancaMa)} (Total: {CalcularTotal(bancaMa)})");
            }

            //Finalment després del calcul de la banca calculem les 2 mans finals i les guardem en una variable cadascuna.
            int totalJugador = CalcularTotal(jugadorMa);
            int totalBanca = CalcularTotal(bancaMa);

            //Si la banca es passa de 21 o el teu total és més gran que el de la banca.
            if (totalBanca > 21 || totalJugador > totalBanca){

                //T'informem que has guanyat, quan has guanyat, et posem els diners i reproduim el so dels diners.
                Thread.Sleep(1000);
                Console.WriteLine($"Has guanyat! El teu total: {totalJugador}. Total de la banca: {totalBanca}");
                ActualitzarSaldo(ref saldo, aposta * 2);
                Thread.Sleep(1000);
                Console.WriteLine($"Has aconseguit {aposta * 2}€ de premi!");
                ReproduirSo("./Diners.mp3", 100);
            }

            //Si el resultat és igual.
            else if (totalJugador == totalBanca){

                //Informem que heu empatat, que recuperes els teus diners, te'ls retornem i reproduim el so del empat.
                Thread.Sleep(1000);
                Console.WriteLine($"Empat! El teu total: {totalJugador}. Total de la banca: {totalBanca}");
                Console.Write("Recuperes els teus diners.");
                ActualitzarSaldo(ref saldo, aposta);
                ReproduirSo("./Empat.mp3", 100);
            }

            //Sí cap dels anteriors (has perdut).
            else{

                //T'informem que hes perdut, i posem el so de que has perdut.
                Thread.Sleep(1000);
                Console.WriteLine($"Has perdut. El teu total: {totalJugador}. Total de la banca: {totalBanca}");
                ReproduirSo("./Perdut.m4a", 100);
            }

            //Et preguntem si vols veure el teu saldo
            volsveuresaldo();
}

        //Declarem el escurabutxaques amb els parametres saldo, joc actual i aposta.
        void Escurabutxaques(ref double saldo, ref string? joc, ref double aposta){

            //El que més he disfrutant fent es aquest :D.

            //Aquest no té try y catch perquè no n'hi ha cap input.
            
            // Fem la llista de strings "🍒", "🍋", "🍊", "🍉", "🍇", "⭐", "💎" que serviran com a posibles caselles.
            List<string> icones = new List<string> {"🍒", "🍋", "🍊", "🍉", "🍇", "⭐", "💎"};
            
            //La array resultat sera una array de strings de 3 caselles.
            string[] resultat = new string[3];

            //Fem un new random que es diu randEb (RandomEscurabutxaques)
            Random randEb = new Random();

            //Fem un bucle que es repetira 3 vegades
            for (int i = 0; i < 3; i++)
            {
                /*A cada iteració es posara com a casella de la iteració una string random d'icones.
                Explicació: resultat[i] =, això diu que es declarara com a casella de la iteració actual
                el que està després del =, icones[randEb.Next(icones.Count)], aqui agafa un random de la array
                icones que sera un random que tindra quantes caselles hi ha a icones com a paràmetre.*/
                resultat[i] = icones[randEb.Next(icones.Count)];
            }

            //Diem que s'està fent la tirada (encara que ja s'ha fet, però l'usuari no ho ha de saber això).
            Console.WriteLine("FENT LA TIRADA!!!");

            //Reproduim el so del escurabutxaques.
            ReproduirSo("./Escurabutxaquestirada.mp3", 500);

            /*Posem el resultat de cada casella amb una mica de decoració, fent el so de
            detenir casella entre cada stop.*/
            Thread.Sleep(1000);
            Console.WriteLine("Resultat:");
            ReproduirSo("./DetenirCasella.mp3", 100);
            Console.Write($"{resultat[0]} | ");
            ReproduirSo("./DetenirCasella.mp3", 100);
            Console.Write($"{resultat[1]} | ");
            ReproduirSo("./DetenirCasella.mp3", 100);
            Console.Write($"{resultat[2]}\n");

            //Ara fem que en la variable premi s'almaçeni el resultat de la funcio ComprobarCombinacio. 
            double premi = ComprobarCombinacio(resultat, ref aposta, ref saldo);

            //Si el premi és major que 0
            if (premi > 0){
                
                //Informem que has guanyat el premi y li actualitzem el saldo amb aquest premi.
                Thread.Sleep(1000);
                Console.WriteLine($"Has guanyat un premi de {premi}€!");
                ActualitzarSaldo(ref saldo, premi);
            }

            //Sí no diem que has perdut i posem el so de quan perds.
            else{
                Thread.Sleep(1000);
                Console.WriteLine("No has guanyat res.");
                ReproduirSo("./Perdut.m4a", 100);
            }

            /*La funció que comprobara la combinació te com a parametres
            el resultat, la aposta i el saldo*/
            double ComprobarCombinacio(string[] resultat, ref double aposta, ref double saldo){
            
            /*Primer comprobem si la array té tot igual.
            Per fer això utilitzarem Distinct que treuria tots els duplicats
            i després contaria quants hi queden de caselles, finalment si només
            hi ha 1, vol dir que els 3 eren iguals.*/
            if (resultat.Distinct().Count() == 1){

                //Si la primera casella de resultat (ara la unica que hi ha) és el diamant
                if (resultat[0] == "💎"){

                    //Imprimim JACKPOT! amb decoració i de fons sonaria la canço del Jackpot.
                    Thread.Sleep(600);
                    Task.Run(() => {
                    ReproduirSo("./JACKPOT!!!.mp3", 100);
                    });
                    Thread.Sleep(1000);
                    Console.Write("J");
                    Thread.Sleep(1000);
                    Console.Write("A");
                    Thread.Sleep(1000);
                    Console.Write("C");
                    Thread.Sleep(1000);
                    Console.Write("K");
                    Thread.Sleep(1000);
                    Console.Write("K");
                    Thread.Sleep(1000);
                    Console.Write("P");
                    Thread.Sleep(1000);

                    //Aqui fariem un bucle per posar 8 O ja que queda millor que 8 Console.Write del mateix.
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("O");
                        Thread.Sleep(1000);
                    }
                    Console.Write("T");
                    Thread.Sleep(1000);
                    Console.Write("!");
                    Thread.Sleep(1000);
                    Console.Write("!");
                    Thread.Sleep(1000);
                    Console.Write("!");
                    Thread.Sleep(1000);
                    Console.Write("🎰");
                    Thread.Sleep(1000);
                    Console.Write("💎");
                    Thread.Sleep(1000);
                    Console.Write("💎");
                    Thread.Sleep(1000);
                    Console.Write("💎");
                    Thread.Sleep(13000);

                    /*Aqui només si hi ha 3 diamants, fem un now random
                     que es diu randJK (random jujutsu kaisen), que serà
                     un mini easter egg amb molt poca probabilitat amb referencia
                     a la serie jujutsu kaisen.*/
                    Random randJK = new Random();

                    //El numero referencia sera un valor aleatori entre 1 i 999.
                    int referencia = randJK.Next(1, 1000);

                    //Si dona al 777.
                    if(referencia == 777){

                        //Imprimirem el dialogue caracteristic del narrador quan va presentar a hakari amb una canço de fons.
                        Thread.Sleep(1000);
                        Task.Run(() => {
                        ReproduirSo("./Hakari.mp3", 100);
                        }
                        );
                        Console.WriteLine("\nHakari mai va obtenir la tecnica maleita inversa.");
                        Thread.Sleep(4000);
                        Console.WriteLine("Però, la quantitat infinita d'energia que rebosaba en el cos de Hakari li permitia fer reflexivament utilitzarla per tal de no recibir cap dany.");
                        Thread.Sleep(11000);
                        Console.WriteLine("En altres paraules, en els 4 minuts y 11 segons després d'un Jackpot, Hakari és efectivament immortal.");
                        Thread.Sleep(16000);

                        //Aqui finalment diem les posibilitats de que això et surti, ja que el client no ho sabría això.
                        Console.WriteLine("(Si t'ha sortit això tens molta sort, hi ha 1 entre 1000 posibilitats, o sigui 0,001%, a sobre de necessitar 3 diamants al joc.)");
                    }

                    //Finalment retornem com a valor 20 vegades la aposta
                    return aposta * 20;
                }

                //Si surten 3 esterlles.
                else if (resultat[0] == "⭐"){

                    //Imprimim Premi! i retornem la aposta * 10 amb el so del premi de fons.
                    Console.WriteLine("Premi!");
                    ReproduirSo("./PREMI!!.mp3", 100);
                    return aposta * 10;
                }

                else{
                //Si es qualsevol altre, imprimim Premi! i retornem la aposta * 5 amb el so del premi de fons.
                Console.WriteLine("Premi!");
                ReproduirSo("./PREMI!!.mp3", 100);
                return aposta * 5;
                }
            }

            //Ara si no son 3 iguals, és comprova que 2 siguin iguals.
            else if (resultat[0] == resultat[1] || resultat[1] == resultat[2] || resultat[0] == resultat[2]){  

                //Imprimim Premi! i retornem la aposta * 2 amb el so del premi de fons.
                Console.WriteLine("Premi!");
                ReproduirSo("./PREMI!!.mp3", 100);
                return aposta * 2;
            }

            //Si no guanyes res retorna 0.
            else{
            return 0;
            }
        }

        //Et pregunta si vols veure el saldo
        volsveuresaldo();
}

    /*La funció ReproduirSo és exactament el mateix que ReproduirSo2, sols que com que estàn en funcions
    diferents, hem fet 2, és el estandar de Naudio.Wave.*/
    void ReproduirSo(string? arxiu, int pausasistema){
        using (var audioFile = new AudioFileReader(arxiu))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing){
                    Thread.Sleep(pausasistema);
                }
            }
    }

        //InciarJoc amb els paràmetres saldo, joc i aposta. Que serà el responsable de inciar tots els jocs.
        void IniciarJoc(ref double saldo, ref string? joc, ref double aposta){

                //Inicia un try
                try{

                    //Imprimeix quan vols apostar amb decoracions.
                    Console.WriteLine("--------");
                    Thread.Sleep(2000);
                    Console.Write($"Inserta quan vols apostar, tens {saldo}€ (DECIMAL AMB ,): ");

                    //Et llegeix la aposta com a double
                    aposta = Convert.ToDouble(Console.ReadLine());
                    Thread.Sleep(1000);

                    //Et diu graciés per jugar i després comprova si tot està bé.
                    Console.WriteLine("Graciès per jugar! Espera mentre comprovem si tot està bé...");

                    /*Si la aposta és major que el saldo et diu que no tens suficient saldo, vols sortir? 
                    I s'activa el errorhandler.*/
                    if (aposta > saldo){
                        Thread.Sleep(1000);
                        Console.WriteLine("No tens suficient saldo, vols sortir?");
                        errorhandler(ref aposta, ref saldo);
                        return;
                        }

                    /*Després si el numero posat és 0 o negatiu et diu que no pots apostar això, vols sortir?
                    I s'activa el famós errorhandler.*/
                    else if (0 >= aposta){
                        Thread.Sleep(1000);
                        Console.WriteLine("No pots apostar un numero negatiu o 0, vols sortir?");   
                        errorhandler(ref aposta, ref saldo);
                        return;
                    }
                }

                /*Si poses alguna cosa rara al input et diu que no pots posar aquest valor com a aposta, si vols sortir.
                I s'activa el errorhandler*/
                catch {
                    Thread.Sleep(2000);
                    Console.WriteLine("No pots posar aquest valor com a aposta, vols sortir?");
                    errorhandler(ref aposta, ref saldo);
                    return;
                }

                //Si cap del anterior s'activa et diu que endavant, i sona el so dels diners i et treuen la aposta del saldo.
                Thread.Sleep(2000);
                Console.WriteLine("Vale, endavant!");
                ReproduirSo("./Diners.mp3", 100);
                ActualitzarSaldo(ref saldo, -aposta);

                //Si el joc és el primer et diu benvingut a la ruleta i s'executa.
                if (joc == "1"){   
                    Console.WriteLine("--------");
                    Thread.Sleep(1000);
                    Console.WriteLine("Benvingut a la ruleta!");
                    Ruleta(ref saldo, ref joc, ref aposta);
                }

                //Si el joc és el segon et diu benvingut al blackjack i s'executa.
                else if (joc == "2"){   
                    Console.WriteLine("--------");
                    Thread.Sleep(1000);
                    Console.WriteLine("Benvingut al blackjack!");
                    Console.WriteLine("IMPORTANT: La carta '1' significa un às.");
                    BlackJack(ref saldo, ref joc, ref aposta);
                }

                //Si el joc és el tercer (l'unica possibilitat que queda) et diu benvingut al escurabutxaques i s'executa.
                else{
                    Console.WriteLine("--------");
                    Thread.Sleep(1000);
                    Console.WriteLine("Benvingut al escurabutxaques!");
                    Escurabutxaques(ref saldo, ref joc, ref aposta);
                }
            }

            //Finalment la funció per escollir joc. Tindra com a parametre el joc actual i l'aposta
            void EscollirJoc(ref string? joc, ref double aposta){

                //Inicia un bucle infinit
                while (true){

                //Primer comproba que el saldo no sigui 0, si no et fa fora.
                if (saldo == 0){
                Thread.Sleep(1000);
                Console.Write("T'has quedat sense saldo, t'hem de fer fora!");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }

                //Et diu amb decoracions a quin joc vols jugar.
                Console.WriteLine("--------");
                Console.WriteLine("A quin joc vols jugar?");
                Console.WriteLine("--------");
                Thread.Sleep(1000);
                Console.WriteLine("1 - Ruleta");
                Thread.Sleep(1000);
                Console.WriteLine("2 - BlackJack");
                Thread.Sleep(1000);
                Console.WriteLine("3 - Escurabutxaques");
                Thread.Sleep(1000);
                Console.WriteLine("4 - Veure Saldo");
                Thread.Sleep(1000);
                Console.WriteLine("5 - Sortir");
                Console.WriteLine("--------");
                Console.WriteLine("--------");
                Thread.Sleep(500);

                //Diu que posis la teva elecció que serà la variable joc.
                Console.Write("Inserta la teva elecció: ");
                joc = Console.ReadLine();

                //S'incia un switch
                switch (joc)
                {
                    /*Si posem 1, 2 o 3 es fa la funció IniciarJoc.
                    Se que és el case pero així m'agrada, es sent
                    més polit.*/
                    case "1":
                    Thread.Sleep(1000);
                    IniciarJoc(ref saldo, ref joc, ref aposta);
                    break;

                    case "2":
                    Thread.Sleep(1000);
                    IniciarJoc(ref saldo, ref joc, ref aposta);                    
                    break;

                    case "3":
                    Thread.Sleep(1000);
                    IniciarJoc(ref saldo, ref joc, ref aposta);
                    break;

                    //Si posa 4, s'activa el VeureSaldo.
                    case "4":
                    Thread.Sleep(1000);
                    VeureSaldo(ref saldo);                   
                    break;

                    //Si posa 5, et diu adeu amb el teu balanç final i s'apaga.
                    case "5":
                    Thread.Sleep(1000);
                    Console.WriteLine($"Vale, adeu! El teu balanç final ha sigut {saldo}");
                    Environment.Exit(0);
                    break;

                    //Si posa qualsevol altre cosa, diu que és invalid i continua el bucle.
                    default:
                    Thread.Sleep(1000);
                    Console.WriteLine("Valor invalid, torna a provar.");
                    continue;
                }
            }
        }

        //Executem EscollirJoc per iniciar tot el script. (Ironic com el principi de tot està al final).
        EscollirJoc(ref joc, ref aposta);
    }

}
