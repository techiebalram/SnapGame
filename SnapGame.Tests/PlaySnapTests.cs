namespace SnapGame.Tests
{
    [TestClass]
    public class PlaySnapTests
    {
        [TestMethod]
        public void PlaySnap_FaceMatch_ShouldAwardCardsToPredictableWinner()
        {
            // Arrange: create a small custom deck that guarantees a match
            var deck = new List<Card>
            {
                new Card("7", "hearts"),
                new Card("7", "spades"), // face match
                new Card("Q", "clubs"),
                new Card("Q", "diamonds") // another face match
            };

            var rng = new Random(0); // predictable winner choice
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.PlaySnap(deck, "face", rng);

            // Assert
            var output = sw.ToString();
            Assert.IsTrue(output.Contains("SNAP! 7 of hearts and 7 of spades match!"));
            Assert.IsTrue(output.Contains("Game over!"));
        }

        [TestMethod]
        public void PlaySnap_NoMatch_ShouldDiscardPileAndEndWithZeroScores()
        {
            // Arrange: deck with no consecutive matches
            var deck = new List<Card>
            {
                new Card("2", "hearts"),
                new Card("3", "spades"),
                new Card("4", "clubs")
            };

            var rng = new Random(0);
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.PlaySnap(deck, "face", rng);

            // Assert
            var output = sw.ToString();
            Assert.IsTrue(output.Contains("Game over!"));
            Assert.IsTrue(output.Contains("Player 1 total cards: 0"));
            Assert.IsTrue(output.Contains("Player 2 total cards: 0"));
        }
    }
}
