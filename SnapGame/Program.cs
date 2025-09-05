namespace SnapGame
{
    public class Program
    {
        static readonly string[] Suits = { "hearts", "diamonds", "clubs", "spades" };
        static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        /// <summary>
        /// Main entry point for the Snap game
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snap!\n");

            int packs = GetNumberOfPacks();
            string condition = GetMatchingCondition();

            var deck = CreateDeck(packs);
            Shuffle(deck);

            PlaySnap(deck, condition);
        }

        /// <summary>
        /// Prompt user for number of packs and validate input
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfPacks()
        {
            int n;
            while (true)
            {
                Console.Write("Enter number of packs (N): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    return n;
                }
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }

        /// <summary>
        /// Prompt user for matching condition and validate input
        /// </summary>
        /// <returns></returns>
        public static string GetMatchingCondition()
        {
            while (true)
            {
                Console.Write("Enter matching condition (face/suit/both): ");
                string? input = Console.ReadLine(); // Use nullable string
                if (!string.IsNullOrEmpty(input)) // Check for null or empty
                {
                    input = input.ToLower();
                    if (input == "face" || input == "suit" || input == "both")
                    {
                        return input;
                    }
                }
                Console.WriteLine("Invalid condition. Choose from face/suit/both.");
            }
        }

        /// <summary>
        /// Create a deck with the specified number of packs
        /// </summary>
        /// <param name="packs"></param>
        /// <returns></returns>
        public static List<Card> CreateDeck(int packs)
        {
            var deck = new List<Card>();
            for (int p = 0; p < packs; p++)
            {
                foreach (var suit in Suits)
                {
                    foreach (var rank in Ranks)
                    {
                        deck.Add(new Card(rank, suit));
                    }
                }
            }
            return deck;
        }

        /// <summary>
        /// Shuffle the deck using Fisher-Yates algorithm
        /// </summary>
        /// <param name="deck"></param>
        public static void Shuffle(List<Card> deck)
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = deck[k];
                deck[k] = deck[n];
                deck[n] = temp;
            }
        }

        /// <summary>
        /// Check if two cards match based on the given condition
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsMatch(Card c1, Card c2, string condition)
        {
            return condition switch
            {
                "face" => c1.Rank == c2.Rank,
                "suit" => c1.Suit == c2.Suit,
                "both" => c1.Rank == c2.Rank && c1.Suit == c2.Suit,
                _ => throw new ArgumentException("Invalid condition")
            };
        }

        /// <summary>
        /// Play the Snap game with two players
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="condition"></param>
        // In Program.cs
        public static void PlaySnap(List<Card> deck, string condition, Random rng = null)
        {
            rng ??= new Random();
            var scores = new Dictionary<string, int>
            {
                { "Player 1", 0 },
                { "Player 2", 0 }
            };

            var pile = new List<Card>();

            foreach (var card in deck)
            {
                pile.Add(card);
                if (pile.Count >= 2)
                {
                    var last = pile[^1];
                    var secondLast = pile[^2];

                    if (IsMatch(last, secondLast, condition))
                    {
                        string winner = rng.Next(2) == 0 ? "Player 1" : "Player 2";
                        scores[winner] += pile.Count;

                        Console.WriteLine($"SNAP! {secondLast} and {last} match! {winner} wins {pile.Count} cards.");
                        pile.Clear();
                    }
                }
            }

            Console.WriteLine("\nGame over!");
            Console.WriteLine($"Player 1 total cards: {scores["Player 1"]}");
            Console.WriteLine($"Player 2 total cards: {scores["Player 2"]}");

            if (scores["Player 1"] > scores["Player 2"])
                Console.WriteLine("Winner: Player 1 🎉");
            else if (scores["Player 2"] > scores["Player 1"])
                Console.WriteLine("Winner: Player 2 🎉");
            else
                Console.WriteLine("It's a draw!");
        }

    }
}
