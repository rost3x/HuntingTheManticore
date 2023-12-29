            int cityHealth = 15;
            int manticoreHealth = 10;
            int manticoreDistance;
            int cannonRange;
            bool wasHit = false;
            int round = 1;
            string readResult;
            

            Console.WriteLine("Welcome to Hunting The Manticore.\nYour job is to defend the city of Consolas against the Uncoded One's airship, the Manticore.\nPress Enter to play or type in 'exit' to abort. ");
            readResult = Console.ReadLine();
            if (readResult.ToLower() == "exit")
                return;

            Console.Clear();

            Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
            while (!int.TryParse(Console.ReadLine(), out manticoreDistance) || manticoreDistance < 0 || manticoreDistance > 100)
            {
                Console.WriteLine("Input was incorrect. Please enter a distance between 0 and 100.");
            }

            Console.Clear();

            do
            {
                Console.WriteLine("Player 2, it is your turn.");
                Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
                Console.WriteLine($"The cannon is expected to deal {CannonDamage(round)} damage this round");
                Console.Write("Enter desired cannon range: ");
                int.TryParse(Console.ReadLine(),out cannonRange);
                HitResult(cannonRange);
                Console.WriteLine("---------------------------------------------------------");
                round++;
            } while (manticoreHealth > 0 && cityHealth > 0);

            if (manticoreHealth <= 0) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nThe city was saved! You've destroyed the Manticore");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nYour attempt to save the city failed.");
            }
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

            void HitResult(int cannonRange)
            {
                if (cannonRange == manticoreDistance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("That round was a DIRECT HIT!");
                    wasHit = true;
                    manticoreHealth -= CannonDamage(round);
                }
                else if (cannonRange < manticoreDistance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round FELL SHORT of the target.");
                    wasHit = false;
                    cityHealth -= 1;
                }
                else if (cannonRange > manticoreDistance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round OVERSHOT the target.");
                    wasHit = false;
                    cityHealth -= 1;
                }
            }