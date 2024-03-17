using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWarGame();
        }

        static void PlayWarGame()
        {
            // Initialize deck
            var deck = InitializeDeck();
            var random = new Random();
            // Shuffle deck
            deck = deck.OrderBy(card => random.Next()).ToList();

            // Split deck between two players
            var player1Deck = new Queue<Card>(deck.Take(26));
            var player2Deck = new Queue<Card>(deck.Skip(26));

            int round = 0;

            while (player1Deck.Any() && player2Deck.Any())
            {
                round++;
                var card1 = player1Deck.Dequeue();
                var card2 = player2Deck.Dequeue();

                Console.WriteLine($"Round {round}: Player 1 plays {card1} vs Player 2 plays {card2}");

                if (card1.Value > card2.Value)
                {
                    player1Deck.Enqueue(card1);
                    player1Deck.Enqueue(card2);
                    Console.WriteLine("Player 1 wins the round.");
                }
                else if (card2.Value > card1.Value)
                {
                    player2Deck.Enqueue(card1);
                    player2Deck.Enqueue(card2);
                    Console.WriteLine("Player 2 wins the round.");
                }
                else
                {
                    Console.WriteLine("War! Players draw another card.");
                    // Simple war mechanic
                    if (player1Deck.Any() && player2Deck.Any())
                    {
                        var warCard1 = player1Deck.Dequeue();
                        var warCard2 = player2Deck.Dequeue();
                        if (warCard1.Value > warCard2.Value)
                        {
                            player1Deck.Enqueue(card1);
                            player1Deck.Enqueue(card2);
                            player1Deck.Enqueue(warCard1);
                            player1Deck.Enqueue(warCard2);
                            Console.WriteLine("Player 1 wins the war.");
                        }
                        else
                        {
                            player2Deck.Enqueue(card1);
                            player2Deck.Enqueue(card2);
                            player2Deck.Enqueue(warCard1);
                            player2Deck.Enqueue(warCard2);
                            Console.WriteLine("Player 2 wins the war.");
                        }
                    }
                }

                if (!player1Deck.Any() || !player2Deck.Any())
                {
                    string winner = player1Deck.Any() ? "Player 1" : "Player 2";
                    Console.WriteLine($"{winner} wins the game in {round} rounds!");
                    break;
                }
            }
        }

        static List<Card> InitializeDeck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var values = Enumerable.Range(2, 13); // 2 to Ace
            var deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    deck.Add(new Card { Suit = suit, Value = value });
                }
            }

            return deck;
        }
    }

    class Card
    {
        public string Suit { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            var valueName = Value switch
            {
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                14 => "Ace",
                _ => Value.ToString()
            };

            return $"{valueName} of {Suit}";
        }
    }
}
