using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShoud
    {
        [Fact]
        public void BeInexperienedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Bo";
            sut.LastName = "Kristensen";

            Assert.Equal("Bo Kristensen", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Bo";
            sut.LastName = "Kristensen";

            Assert.StartsWith("Bo", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgonreCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "BO";
            sut.LastName = "KRISTENSEN";

            Assert.Equal("Bo Kristensen", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubStringTestWithContains()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Bo";
            sut.LastName = "Kristensen";

            Assert.Contains("o Kris", sut.FullName);
        }

        [Fact]
        public void StartWith100Hp()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWith100Hp_NotEqual()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(42, sut.Health);
        }

        [Fact]
        public void IncreaseHPAfterSleep()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

            Assert.InRange(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNicknameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            // Here we look for a complete match for an element in the collection
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void HaveASword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            // First is the collection and next is the filter
            // Here we can look for parsial match for the elemet and not the complete one
            Assert.Contains(sut.Weapons, w => w.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            string[] expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            // Test all items in collection
            Assert.All(sut.Weapons, w => Assert.False(string.IsNullOrWhiteSpace(w)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(1));
        }
    }
}