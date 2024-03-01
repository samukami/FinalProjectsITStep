using System;
using System.IO;

class ATM
{
    static void Main(string[] args)
    {        
        string path = "C:\\Users\\Lenovo\\Desktop\\users.txt";

        while (true)
        {
            Console.WriteLine("airchiet operacia:");
            Console.WriteLine("1. balansis shemowmeba");
            Console.WriteLine("2. tanxis shetana");
            Console.WriteLine("3. tanxis gatana");
            Console.WriteLine("4. dasruleba");
            Console.Write("sheiyvanet sasurveli operacia: ");

            string operacia = Console.ReadLine();

            switch (operacia)
            {
                case "1":
                    balansisshemowmeba(path);
                    break;
                case "2":
                    tanxisshetana(path);
                    break;
                case "3":
                    tanxisgatana(path);
                    break;
                case "4":
                    Console.WriteLine("warmatebit gamoxvedit ATM-dan");
                    return;
                default:
                    Console.WriteLine("araswori operacia, scadet tavidan");
                    break;
            }
        }
    }

    static void balansisshemowmeba(string path)
    {
        string[] users = File.ReadAllLines(path);
        
        Console.WriteLine("sheiyvanet piradi nomeri");

        string piradinomeri = Console.ReadLine();

        Console.WriteLine("sheiyvanet pin kodi");

        string pin = Console.ReadLine();

        foreach (string user in users)
        {
            string[] userInfo = user.Split(',');
            if (userInfo.Length == 3 && userInfo[0] == piradinomeri && userInfo[1] == pin)
            {
                Console.WriteLine($"balansi: {userInfo[2]}");
                return;
            }
        }

        Console.WriteLine("am monacemebit momxmarebeli ver moidzebna");
    }

    static void tanxisshetana(string path)
    {
        string[] users = File.ReadAllLines(path);

        Console.WriteLine("sheiyvanet piradi nomeri");

        string piradinomeri = Console.ReadLine();

        Console.WriteLine("sheiyvanet pin kodi");

        string pin = Console.ReadLine();

        foreach (string user in users)
        {
            string[] userInfo = user.Split(',');
            if (userInfo.Length == 3 && userInfo[0] == piradinomeri && userInfo[1] == pin)
            {
                Console.WriteLine("sheiyvanet ramdeni tanxis shetana gindat");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    double balance = double.Parse(userInfo[2]);
                    balance += amount;
                    userInfo[2] = balance.ToString();
                    File.WriteAllLines(path, users);
                    Console.WriteLine($"tanxa warmatebit sheitanet, balansi: {balance}");
                    return;
                }
                else
                {
                    Console.WriteLine("tanxa arasworad aris mititebuli");
                    return;
                }
            }
        }

        Console.WriteLine("am monacemebit momxmarebeli ver moidzebna");
    }

    static void tanxisgatana(string path)
    {
        string[] users = File.ReadAllLines(path);

        Console.WriteLine("sheiyvanet piradi nomeri");

        string piradinomeri = Console.ReadLine();

        Console.WriteLine("sheiyvanet pin kodi");

        string pin = Console.ReadLine();

        foreach (string user in users)
        {
            string[] userInfo = user.Split(',');
            if (userInfo.Length == 3 && userInfo[0] == piradinomeri && userInfo[1] == pin)
            {
                Console.WriteLine("sheiyvanet ramdeni tanxis gamotana gindat");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    double balance = double.Parse(userInfo[2]);
                    if (balance >= amount)
                    {
                        balance -= amount;
                        userInfo[2] = balance.ToString();
                        File.WriteAllLines(path, users);
                        Console.WriteLine($"tanxa warmatebit gamoitanet, balansi: {balance}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("angarishze sakmarisi tanxa ar aris :(");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("tanxa arasworad aris mititebuli");
                    return;
                }
            }
        }

        Console.WriteLine("am monacemebit momxmarebeli ver moidzebna");
    }
}


