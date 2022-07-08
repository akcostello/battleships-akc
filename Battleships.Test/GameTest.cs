using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleships;
using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlayNoHits()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };
            Game.Play(ships, guesses).Should().Be(0);
        }

        [Fact]
        public void TestPlayOneHorizontalShipHits()
        {
            var ships = new[] { "3:2,3:2" };
            var guesses = new[] { "7:0", "3:3", "3:2", "3:4","3:5" };

            Game.Play(ships, guesses).Should().Be(1);
        }


        [Fact]
        public void TestPlayVerticalOneShipHits()
        {
            var ships = new[] { "4:2,6:2" };
            var guesses = new[] { "7:0", "3:3", "4:2", "3:2", "5:2", "6:2", "3:3" };

            Game.Play(ships, guesses).Should().Be(1);
        }

        [Fact]
        public void TestPlayTwoHorizontalShipHits()
        {
            var ships = new[] { "3:2,3:5", "7:2, 7:5" };
            var guesses = new[] { "7:3", "7:4", "7:5", "7:2", "3:3", "3:2", "3:4", "3:5", "9:0" };

            Game.Play(ships, guesses).Should().Be(2);
        }

        [Fact]
        public void TestPlayThreeShipHorizontalVerticalHits()
        {
            var ships = new[] { "3:2,3:5", "5:2,5:5", "4:2,6:2" };
            var guesses = new[] { "4:2", "5:2", "6:2", "3:2", "3:3", "3:4", "3:5", "5:2", "5:3","5:4", "5:5" };

            Game.Play(ships, guesses).Should().Be(3);
        }

    }
}
