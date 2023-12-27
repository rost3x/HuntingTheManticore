namespace HuntingTheManticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cityHealth = 15;
            int manticoreHealth = 10;
            int manticoreDistance = 0;
            bool wasHit = false;
            int round = 1;

            Console.WriteLine("Welcome to Hunting The Manticore.\nYour job is to defend the city of Consolas against the Uncoded One's airship, the Manticore.\nPress Enter to play or type in 'exit' to abort.");
            string readResult = Console.ReadLine();
            if (readResult == "exit")
                return;

            do
            {
                Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
                manticoreDistance = Convert.ToInt32(Console.ReadLine());

            } while (manticoreDistance < 0 || manticoreDistance > 100);
            Console.Clear();

            do
            {
                Console.WriteLine("Player 2, its is your turn.");
                Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
                Console.WriteLine($"The cannon is expected to deal {CannonDamage(round)} damage this round");
                Console.Write("Enter desired cannon range: ");
                int cannonRange = Convert.ToInt32(Console.ReadLine());
                hitResult(cannonRange);
                Console.WriteLine("---------------------------------------------------------");
                round++;
            } while (manticoreHealth > 0 && cityHealth > 0);
            Console.Read();
            

            int CannonDamage(int roundNumber)
            { 
                if ((roundNumber % 3 == 0) && (roundNumber % 5 == 0))  
                    return 10;
                else if ((roundNumber % 3 == 0) || (roundNumber % 5 == 0))
                    return 3;
                else
                    return 1;
            }

            void hitResult(int cannonRange)
            {
                if (cannonRange == manticoreDistance)
                {
                    Console.WriteLine("That round was a DIRECT HIT!");
                    wasHit = true;
                    manticoreHealth -= CannonDamage(round);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (cannonRange < manticoreDistance)
                {
                    Console.WriteLine("That round FELL SHORT of the target.");
                    wasHit = false;
                    cityHealth -= 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (cannonRange > manticoreDistance)
                {
                    Console.WriteLine("That round OVERSHOT the target.");
                    wasHit = false;
                    cityHealth -= 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }

        }

        
    }
}
