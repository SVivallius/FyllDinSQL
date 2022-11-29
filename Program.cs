using Flood_Labb1_SQL;

List<string> firstNames = new List<string>();
List<string> lastNames = new List<string>();
Random rollName = new Random();

//fetchNames.createFiles();
fetchNames.GetNames(ref firstNames, ref lastNames);


Console.Write("\tEnter number of generated entries: ");
Int32.TryParse(Console.ReadLine(), out int selection);

SQL_Injection.ConnectAndInsert(selection, firstNames, lastNames);
