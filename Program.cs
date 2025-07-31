using System;
using System.Collections.Generic;
class Program
{
    class Villager
    {
        public string Name { get; set; } = "";
        public string Hint { get; set; } = "";
    }
    class Letter
    {
        public string Hint { get; set; } = "";
        public string CorrectReceiver { get; set; } = "";
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Now you are playing the game: WHISPERING POSTMAN");
        Console.ReadKey();
        Console.WriteLine("Welcome to the village of Perithia!\nThe village is very small, almost forgotten, and lonesome with some villagers.\n There is a small post office, and a friendly postman Iapetus with little alzheimers faces problem to deliver the lettrs accordingly.\nCan you help him?");
        Console.ReadKey();
        Console.WriteLine("You will be given names of villagers, along with the hints. Match the hints with the letters to find the correct receivers. You will earn points for each correct match.");
        Console.ReadKey();
        Console.WriteLine("Let's start the game! You will understand the rules more clearly as you play it. Happy playing!");
        Console.ReadKey();
        int score = 0;
        int rounds = 3;
        Random rnd = new Random();
        List<Villager> Villagers = new List<Villager>
        {
            new Villager { Name = "Daphne", Hint = "She has kneelength hair which everyone admires."},
            new Villager { Name = "Alec", Hint = "He is the best harp player villagers ever heard of."},
            new Villager { Name = "Lydia", Hint = "She has a thing for cats. People think of her whenever they see any cat."},
            new Villager { Name = "Nikos", Hint = "He is the teacher in the village school, and loves teaching kids."},
            new Villager { Name = "Iris", Hint = "She just loves her garden! Specially the fresh Olive saplings from Athens."},
            new Villager { Name = "Linus", Hint = "He is the charming farmer guy, who takes care of anyone sick in the village too."},
        };
        List<Letter> Letters = new List<Letter>
        {
            new Letter { Hint = "Guess the person with a passion for plants and contact with her for fresh Olives", CorrectReceiver = "Iris"},
            new Letter { Hint = "Guess the person who can clearly play harp magically good", CorrectReceiver = "Alec"},
            new Letter { Hint = "Guess the person who recently taught the kids about the legend of Troy", CorrectReceiver = "Nikos"},
            new Letter { Hint = "Guess the person whom you always can be seen buying catfood", CorrectReceiver = "Lydia"},
            new Letter { Hint = "Guess the person who was taking care of Iapetus when he had a fever", CorrectReceiver = "Linus"},
            new Letter { Hint = "Guess the person combing her kneelength hair gracefully", CorrectReceiver = "Daphne"},
        };
        for (int day = 1; day <= rounds; day++)
        {
            Console.WriteLine($"\nDay {day}:");
            Console.ReadKey();
            Console.WriteLine("Here are the villagers and their hints:");
            foreach (var villager in Villagers)
            {
                Console.WriteLine($"- {villager.Name}: {villager.Hint}");
            }
            Letter currLetter = Letters[rnd.Next(Letters.Count)];
            Console.ReadKey();
            Console.WriteLine($"\nToday's letter hint: {currLetter.Hint}");
            Console.WriteLine("Ooh dear! Poor Iapetus can't remember who's this. Can you tell who's the correct receiver?");
            string? input = Console.ReadLine();
            string answer = input?.Trim() ?? string.Empty;
            if (answer.Equals(currLetter.CorrectReceiver, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("God you are truly a lifesaver! You saved Iapetus from another embarrassment! Thank youuu!");
                Console.ReadKey();
                score++;
            }
            else
            {
                Console.WriteLine($"Oh no! It would be {currLetter.CorrectReceiver}");
                Console.ReadKey();
            }
        }
        Console.WriteLine($"\nHoly Styx! You made Iapetus' day! Here is your score: {score} out of {rounds}");
        Console.ReadKey();
        Console.WriteLine("Thanks for playing the game! Remember, Iapetus will never not need your help. Feel free to help him anytime!");
        Console.ReadKey();
    }
}