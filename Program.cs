namespace HuntingTheManticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cityHealth = 15;
            int manticoreHealth = 10;
            int manticoreDistance = 0;

            Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
            manticoreDistance = Convert.ToInt32(Console.ReadLine());

            do
            {

                for (int i = 1; i < 25; i++)
                {
                    Console.WriteLine("Player 2, its is your turn.");

                    Console.WriteLine($"STATUS: Round: {i} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
                    CannonDamage(i);
                    Console.Write("Enter desired cannon range: ");
                    int cannonRange = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("That round ......");
                }

            } while (manticoreHealth > 0 || cityHealth > 0);

            void CannonDamage(int roundNumber)
            {  
                    if ((roundNumber % 3 == 0) && (roundNumber % 5 == 0))
                        Console.WriteLine($"The cannon is expected to deal 10 damage this round");
                    else if ((roundNumber % 3 == 0) || (roundNumber % 5 == 0))
                        Console.WriteLine($"The cannon is expected to deal 3 damage this round");
                    else
                        Console.WriteLine($"The cannon is expected to deal 1 damage this round");
            }

        }

        
    }
}
