namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("programas chapikrebuli akvs ricxvi 1-dan 100-is chatvlit. gamoicani ricxvi 10 cdashi");

            Random x = new Random(); //agenerirebs random ricxvs

            int ricxvi = x.Next(1, 101); // gamosacnobi ricxvi 1dan 100mde

            int cda = 10; // cdebis raodenoba

            while (cda > 0)
            {
                Console.WriteLine($"darchenilia {cda} cda");

                cda--;

                Console.WriteLine("sheiyvane ricxvi");

                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("araswori formati - chaweret ricxviti mnishvneloba 1-dan 100-is chatvlit");
                    continue;
                }
                if (a < 1 || a > 100)
                {
                    Console.WriteLine("chaweret ricxvi 1-dan 100-is chatvlit");
                    continue;
                }
                if (ricxvi > a)
                {
                    Console.WriteLine("chapikrebuli ricxvi metia");
                    continue;
                }
                if (ricxvi < a)
                {
                    Console.WriteLine("chapikrebuli ricxvi naklebia");
                    continue;
                }
                else
                {
                    Console.WriteLine("warmatebit gamoicani ricxvi");
                    return;
                }

            }

            Console.WriteLine("ver gamoicani ricxvi");
        }
    }
}
