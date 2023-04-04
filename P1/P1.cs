using System;
using lumenCS;

// PROGRAMMER Name: Sergio Satyabrata
// Date: 4/4/2023
// Revision History: Revised
// Platform: Windows 10



// Assumptions: brightness, size, and power are positive (greater than 0)

namespace driver
{
    public class P1
    {
        static void Main()
        {
            Lumen[] lumens = InitializeLumenObject1();
            Lumen[] lumeno = InitializeLumenObject2();

            Console.WriteLine("First Glow:");
            DisplayGlows(lumens);

            Console.WriteLine("---------------------------------------------------------");

            PerformGlowRequests(lumens);
            DisplayGlows(lumens);

            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine("\nGlow after reset attempts:");
            AttemptResets(lumens);
            DisplayGlows(lumens);

            Console.WriteLine(" ");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("\nInitial Glow of Second Test: ");
            DisplayGlows(lumeno);


            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("\nGlow 6 times to get erratic value: ");
            Console.WriteLine(" ");
            GlowV2(lumeno);
            DisplayGlows(lumeno);

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("\nGlow Value After Reset: ");
            AttemptResets(lumeno);
            DisplayGlows(lumeno);

            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("\nGlow Until Inactive: ");
            GlowTillDim(lumeno);
            DisplayGlows(lumeno);
        }

        static Lumen[] InitializeLumenObject1()
        {
            Random random = new Random();
            const int SIZE = 4;

            // Create an array of four Lumen objects with random values
            Lumen[] lumens = new Lumen[SIZE];
            for (int i = 0; i < lumens.Length; i++)
            {
                int brightness = random.Next(1, 26);  // Random integer between 1 and 25
                int size = random.Next(1, 5);         // Random integer between 1 and 4
                int power = random.Next(20, 81);      // Random integer between 20 and 80

                lumens[i] = new Lumen(brightness, size, power);
            }
            return lumens;
        }

        static Lumen[] InitializeLumenObject2()
        {
            const int SIZE = 1;
            Lumen[] lumeno = new Lumen[SIZE];
            int brightness_1 = 10;
            int size_1 = 2;
            int power_1 = 10;

            lumeno[0] = new Lumen(brightness_1, size_1, power_1);
            return lumeno;
        }

        static void DisplayGlows(Lumen[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                string status = "";

                if (!a[i].isActive())
                {
                    status = " (inactive)";
                }
                else
                {
                    status = " (active)";
                }

                Console.WriteLine($"\nLumen {i + 1} -- Glow Value : {a[i].glow()}{status}");
            }
        }

        static void PerformGlowRequests(Lumen[] a)
        {
            int rnd = new Random().Next(1, 20);
            Console.WriteLine($"Glow after {rnd - 1} requests:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(" ");
                for (int j = 1; j < rnd; j++)
                {
                    int glowVal = a[i].glow();
                    Console.WriteLine($"Lumen {i + 1} -- Glow value: {glowVal}");
                }
            }
        }

        static void GlowV2(Lumen[] a)
        {
            const int GLOW_UNTIL_ERRATIC = 7;
            Console.WriteLine($"Glow after {GLOW_UNTIL_ERRATIC - 1} requests:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(" ");
                for (int j = 1; j < GLOW_UNTIL_ERRATIC; j++)
                {
                    int glowVal = a[i].glow();
                    Console.WriteLine($"Lumen {i + 1} -- Glow value: {glowVal}");
                }
            }
        }

        static void GlowTillDim(Lumen[] a)
        {
            const int GLOW_UNTIL_INACTIVE = 10;
            Console.WriteLine($"Glow after {GLOW_UNTIL_INACTIVE - 1} requests:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(" ");
                for (int j = 1; j < GLOW_UNTIL_INACTIVE; j++)
                {
                    int glowVal = a[i].glow();
                    Console.WriteLine($"Lumen {i + 1} -- Glow value: {glowVal}");
                }
            }
        }

        static void AttemptResets(Lumen[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].reset();
            }
        }
    }
}


