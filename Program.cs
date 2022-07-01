namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "";
            uint index = 0;
            string search = "";

            try
            {
                filePath = args[0];
                index = Convert.ToUInt32(args[1]);
                search = args[2];
            }
            catch (IndexOutOfRangeException)
            {
                WriteErrorMessage("Non sono stati inseriti tutti gli argomenti: percorso file, indice di colonna e chiave da ricercare");
            }
            catch (FormatException)
            {
                WriteErrorMessage("Formato dell'indice non valido: deve essere un numero intero positivo");
            }
            catch (OverflowException)
            {
                WriteErrorMessage("Formato dell'indice non valido: deve essere un numero intero positivo");
            }

            if (!File.Exists(filePath))
            {
                WriteErrorMessage("Il file non è stato trovato o non esiste");
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                var cells = line.Substring(0, line.Length - 1).Split(','); // Rimuove l'ultimo ; e divide i dati della riga.

                if (cells[index].Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void WriteErrorMessage(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(-1);
        }
    }
}