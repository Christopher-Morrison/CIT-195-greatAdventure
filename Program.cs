using System;
using System.Reflection.PortableExecutable;

namespace greatAdventure
{

    class versionOne
    {
        static void initValues(ref int lives, ref int magic, ref int health,Random r)
        {
            lives = r.Next(1, 11);
            magic = r.Next(5, 16);
            health = r.Next(5, 15);
        }
        static int chooseDirection()
        {
            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and a 2 to travel right.");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
        static void actions(int num, ref int lives, ref int magic, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("" +
                        "                \\||/\r\n" +
                        "                |  @___oo\r\n" +
                        "      /\\  /\\   / (__,,,,|\r\n" +
                        "     ) /^\\) ^\\/ _)\r\n" +
                        "     )   /^\\/   _)\r\n" +
                        "     )   _ /  / _)\r\n" +
                        " /\\  )/\\/ ||  | )_)\r\n" +
                        "<  >      |(,,) )__)\r\n" +
                        " ||      /    \\)___)\\\r\n" +
                        " | \\____(      )___) )___\r\n" +
                        "  \\______(_______;;; __;;;");
                    Console.WriteLine("A worst case senario. You meet a dragon!\n " +
                                      "The flames were so intense you barely escape.");
                    Console.WriteLine("You lose 5 unit of health and 1 unit of magic");
                    health -= 5;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You come face to face with an evil monk.\n " +
                        "He engages you in a serious magical duel but does no damage.");
                    Console.WriteLine("You lost 5 units of magic");
                    magic -= 5;          
                    break;
                case 2:
                    Console.WriteLine("The ground slides out from underneath you!");
                    Console.WriteLine("You lost 1 life in a land slide.");
                    lives -= 1;
                    break;

                case 3:
                    Console.WriteLine("A group of goblins ambushes you from the bushes!.");
                    Console.WriteLine("You lost 5 units of health and magic");
                    magic -= 5;
                    health -= 5;
                    break;

                case 4:
                    Console.WriteLine("A dead end, you turn around but the path is gone.\n" +
                                 "You are lost and must use magic to find the path again.");
                    Console.WriteLine("You lost 1 unit of magic");
                    magic -= 1;
                    break;
                case 5:
                    Console.WriteLine("A beautiful woman on the path blew you a kiss.\n You feel energized.");
                    Console.WriteLine("The woman granted you 1 unit of health, magic");
                    health += 1;
                    magic += 1;
                    break;
                case 6:
                    Console.WriteLine("A broken wagon blocks the path. \n You help the merchant fix his wagon.");
                    Console.WriteLine("The merchant gives 2 units of health and magic");
                    health += 2;
                    magic += 2;
                    break;
                case 7:
                    Console.WriteLine("You find a place to rest in a wagon caravan.\n " +
                        "You use your magic to set up a barrier for the evening.");
                    Console.WriteLine("You gain 3 units of health and lose 2 units of magic.");
                    magic -= 2;
                    health += 3;
                    break;
                case 8:
                    Console.WriteLine("The path is barren, there is nothing to do or see.\n" +
                        "You are almost bored to death and spend your time saving mana.");
                    Console.WriteLine("You lost 1 units of health gain 3 units of magic.");
                    magic += 3;
                    health -= 1;
                    break;

                case 9:
                    Console.WriteLine("A weary traveler trades a cup with strange engravings for some food.\n" +
                        "You drink from the cup and it crumbles away.");
                    Console.WriteLine("You gain 1 life");
                    lives += 1;
                    break;

                default:
                    Console.WriteLine("You save a woman being eaten by a giant frog.\n " +
                        "The woman was a goddess.");
                    Console.WriteLine("You gain 2 lives and 5 units of magic and health.");
                    magic += 5;
                    lives += 2;
                    health += 5;
                    break;
            }
        }
        static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            round += 1;
            Console.WriteLine($"======= Round {round} =======");
            Console.WriteLine($"Lives: {lives}, Magic: {magic}, Health {health}");
            if ( round >= 25 ) 
            {
                win = true; 
            }
            return;
        }
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref magic, ref health, r);
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }


    }
}