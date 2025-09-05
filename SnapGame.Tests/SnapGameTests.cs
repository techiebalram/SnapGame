using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SnapGame;

namespace SnapGame.Tests
{
    [TestClass]
    public class SnapGameTests
    {
        [TestMethod]
        public void CreateDeck_WithOnePack_ShouldHave52Cards()
        {
            var deck = Program.CreateDeck(1);
            Assert.AreEqual(52, deck.Count);
        }

        [TestMethod]
        public void CreateDeck_WithTwoPacks_ShouldHave104Cards()
        {
            var deck = Program.CreateDeck(2);
            Assert.AreEqual(104, deck.Count);
        }

        [TestMethod]
        public void IsMatch_ByFace_ShouldReturnTrue_ForSameRankDifferentSuit()
        {
            var card1 = new Card("7", "hearts");
            var card2 = new Card("7", "spades");

            bool result = Program.IsMatch(card1, card2, "face");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_BySuit_ShouldReturnTrue_ForDifferentRankSameSuit()
        {
            var card1 = new Card("3", "diamonds");
            var card2 = new Card("9", "diamonds");

            bool result = Program.IsMatch(card1, card2, "suit");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_ByBoth_ShouldReturnTrue_ForIdenticalCards()
        {
            var card1 = new Card("Q", "hearts");
            var card2 = new Card("Q", "hearts");

            bool result = Program.IsMatch(card1, card2, "both");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_ByBoth_ShouldReturnFalse_ForDifferentCards()
        {
            var card1 = new Card("Q", "hearts");
            var card2 = new Card("Q", "clubs");

            bool result = Program.IsMatch(card1, card2, "both");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Shuffle_ShouldChangeDeckOrder()
        {
            var deck = Program.CreateDeck(1);
            var originalOrder = new List<Card>(deck);

            Program.Shuffle(deck);

            CollectionAssert.AreNotEqual(originalOrder, deck);
        }
    }
}
