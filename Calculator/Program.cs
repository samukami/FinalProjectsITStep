namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("sheiyvane ricxvebi da operacia spacebis gamokenebit mag.: 1 + 2"); // user xedavs dasawyisshi

                string x = Console.ReadLine(); // users sheyavs ricxvebi da operacia

                string[] xarray = x.Split(' '); // iuseris sheyvanili info gadayavs masivshi da yofs

                if (xarray.Length != 3)  // amowmebs users sworad akvs tu ara sheyvanili info
                {
                    Console.WriteLine("araswori formati - sheiyvane ricxvebi da operacia spacebis gamokenebit mag.: 1 + 2 ");
                    continue;
                }
                if (!double.TryParse(xarray[0], out double a) || !double.TryParse(xarray[2], out double b)) // amowmebs ricxviti mnishvnelobebis siswores
                {
                    Console.WriteLine("ricxvebi arasworad aris sheyvanili, sheiyvanet validuri ricxviti mnishvneloba ");
                    continue;
                }
                string y = xarray[1];// asaxavs operacias 

                double shedegi = 0; // asaxavs shedegs

                switch (y) // sxvadasxva operaciebi
                {
                    case "+":
                        shedegi = a + b;
                        break;
                    case "-":
                        shedegi = a - b;
                        break;
                    case "*":
                        shedegi = a * b;
                        break;
                    case "/":
                        if (b == 0)
                        {
                            Console.WriteLine("0ze gayofa sheudzlebelia sheiyavne sxva ricxvi");
                            continue;
                        }
                        shedegi = a / b;
                        break;
                    case "%":
                        shedegi = a * b / 100;
                        break;
                    default:
                        Console.WriteLine("sheiyvane swori operaciis simbolo +, -, *, /, %");
                        continue;


                }
                Console.WriteLine($"shedegi: {a} {y} {b} = {shedegi}"); // saboloo shedegi

                Console.WriteLine("kalkulatoris shewyvetistvis dawere nebismieri simbolo an gasagrdzeleblad daachire enters");
                string gagrdzeleba = Console.ReadLine().ToLower();
                if (gagrdzeleba != "")
                    break;
            }
            
        }
    }
}
