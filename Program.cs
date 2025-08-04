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
        Console.WriteLine("Welcome to the village of Perithia!\nThe village is very small, almost forgotten, and lonesome with some villagers.\nThere is a small post office, and a friendly postman Iapetus with little alzheimers who faces problem to deliver the letters accordingly.\nCan you help him?");
        Console.ReadKey();
        Console.WriteLine("You will be given names of villagers, along with the hints. Match the hints with the letters to find the correct receivers. You will earn points for each correct match.");
        Console.ReadKey();
        Console.WriteLine("Let's start the game! You will understand the rules more clearly as you play it. Happy playing!");
        Console.ReadKey();
        int score = 0;
        int rounds = 3;
        int question = 3;
        Random rnd = new Random();
        List<Villager> Villagers = new List<Villager>
        {
            new Villager { Name = "Daphne", Hint = "She has kneelength hair which everyone admires."},
            new Villager { Name = "Alec", Hint = "He is the best harp player villagers ever heard of."},
            new Villager { Name = "Lydia", Hint = "She has a thing for cats. People think of her whenever they see any cat."},
            new Villager { Name = "Nikos", Hint = "He is the teacher in the village school, and loves teaching kids."},
            new Villager { Name = "Iris", Hint = "She just loves her garden! Specially the fresh Olive saplings from Athens."},
            new Villager { Name = "Linus", Hint = "He is the charming farmer guy, who takes care of anyone sick in the village too."},
            new Villager { Name = "Lena", Hint = "She weaves beautiful patterns into soft woolen clothes, and is known for her kindness."},
            new Villager { Name = "Theo", Hint = "He is the blacksmith, known for his strength and skill in crafting tools."},
            new Villager { Name = "Mira", Hint = "She is the healer, using herbs and remedies to help the sick."},
            new Villager { Name = "Orion", Hint = "He is the storyteller, sharing tales of old with the children, being their favourite"},
            new Villager { Name = "Cassia", Hint = "She is the baker, known for her delicious bread and pastries, always welcoming with a smile."},
            new Villager { Name = "Elias", Hint = "He is the carpenter, crafting furniture and repairing homes with great care."},
            new Villager { Name = "Selene", Hint = "She is the seer, known for her visions and wisdom, often sought for advice by the villagers."},
            new Villager { Name = "Lukas", Hint = "He is the fisherman, bringing fresh fish from the nearby river, always cheerful and friendly."},
        };
        List<Letter> Letters = new List<Letter>
        {
            new Letter { Hint = "Guess the person with a passion for plants and contact with her for fresh Olives", CorrectReceiver = "Iris"},
            new Letter { Hint = "Guess the person who can clearly play harp magically good", CorrectReceiver = "Alec"},
            new Letter { Hint = "Guess the person who recently taught the kids about the legend of Troy", CorrectReceiver = "Nikos"},
            new Letter { Hint = "Guess the person whom you always can be seen buying catfood", CorrectReceiver = "Lydia"},
            new Letter { Hint = "Guess the person who was taking care of Iapetus when he had a fever", CorrectReceiver = "Linus"},
            new Letter { Hint = "Guess the person combing her kneelength hair gracefully", CorrectReceiver = "Daphne"},
            new Letter { Hint = "Guess the person who is known for her beautiful woolen clothes", CorrectReceiver = "Lena"},
            new Letter { Hint = "Guess the person who is the strongest in the village, and can lift heavy things easily", CorrectReceiver = "Theo"},
            new Letter { Hint = "Guess the person who is always seen with a basket of herbs, helping the sick", CorrectReceiver = "Mira"},
            new Letter { Hint = "Guess the person who tells the best stories to the children, making them laugh and learn", CorrectReceiver = "Orion"},
            new Letter { Hint = "Guess the person who bakes the most delicious bread and pastries, always with a smile", CorrectReceiver = "Cassia"},
            new Letter { Hint = "Guess the person who crafts beautiful furniture and repairs homes with great care", CorrectReceiver = "Elias"},
            new Letter { Hint = "Guess the person who is known for her visions and wisdom, often sought for advice", CorrectReceiver = "Selene"},
            new Letter { Hint = "Guess the person who brings fresh fish from the nearby river, always cheerful", CorrectReceiver = "Lukas"},
        };
        List<Letter> availableLetters = new List<Letter>(Letters);
        List<Villager> RandomVillagers (int count)
        {
            List<Villager> shuffled = new List<Villager>(Villagers);
            for (int i = 0; i < shuffled.Count; i++)
            {
                int swapIndex = rnd.Next(i, shuffled.Count);
                var temp = shuffled[i];
                shuffled[i] = shuffled[swapIndex];
                shuffled[swapIndex] = temp;
            }
            return shuffled.GetRange(0, count);
        }
        for (int day = 1; day <= rounds; day++)
        {
            Console.WriteLine($"\nDay {day}:");
            Console.ReadKey();
            List<Villager> villagers = RandomVillagers(5);
            for (int q = 1; q <= question; q++)
            {
                List<Letter> letters = availableLetters.FindAll(l => villagers.Exists(v => v.Name == l.CorrectReceiver));
                if (availableLetters.Count == 0) break;
                if (letters.Count == 0) break;
                Console.WriteLine($"Question {q}:");
                Console.WriteLine("Here are the villagers and their hints:");
                foreach (var villager in villagers)
                {
                    Console.WriteLine($"- {villager.Name}: {villager.Hint}");
                }
                int index = rnd.Next(letters.Count);
                Letter currLetter = letters[index];
                availableLetters.RemoveAll(l => l.CorrectReceiver == currLetter.CorrectReceiver);
                Console.WriteLine($"\nToday's letter hint: {currLetter.Hint}");
                Console.WriteLine("Ooh dear! Poor Iapetus can't remember who's this. Can you tell who's the correct receiver?");
                Console.WriteLine("You have 30 seconds to answer. Type the name of the villager you think. Good luck!");
                string answer = string.Empty;
                DateTime startTime = DateTime.Now;
                while ((DateTime.Now - startTime).TotalSeconds < 30 && string.IsNullOrWhiteSpace(answer))
                {
                    if (Console.KeyAvailable)
                    {
                        answer = Console.ReadLine()?.Trim() ?? string.Empty;
                    }
                    System.Threading.Thread.Sleep(100);
                }
                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("Time's up! You are on same boat as Iapetus.");
                }
                if (!string.IsNullOrWhiteSpace(answer) && answer.Equals(currLetter.CorrectReceiver, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("God you are truly a lifesaver! You saved Iapetus from another embarrassment! Thank youuu!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Oh no! It would be {currLetter.CorrectReceiver}");
                }
                Console.ReadKey();
            }
        }
        Console.WriteLine($"\nHoly Styx! You made Iapetus' day! Here is your score: {score} out of {rounds * question}");
        Console.ReadKey();
        Console.WriteLine("Thanks for playing the game! Remember, Iapetus will never not need your help. Feel free to help him anytime!");
        Console.ReadKey();
    }
}