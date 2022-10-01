using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryAssignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment1.Tests
{
    [TestClass()]
    public class FootballPlayerTests
    {
        FootballPlayer footballPlayer1Good = new FootballPlayer() { Id = 1, Name = "Martin", Age = 29, ShirtNumber = 10 };
        FootballPlayer footballPlayer2NullName = new FootballPlayer() { Id = 2, Age = 29, ShirtNumber = 10 };
        FootballPlayer footballPlayer3TooShortName = new FootballPlayer() { Id = 3, Name = "H", Age = 29, ShirtNumber = 10 };
        FootballPlayer footballPlayer4JustEnoughName = new FootballPlayer() { Id = 4, Name = "Hi", Age = 29, ShirtNumber = 10 };
        FootballPlayer footballPlayer5BlankName = new FootballPlayer() { Id = 5, Name = "  ", Age = 29, ShirtNumber = 10 };
        FootballPlayer footballPlayer6TooYoung = new FootballPlayer() { Id = 6, Name = "Morten", Age = 1, ShirtNumber = 11 };
        FootballPlayer footballPlayer7GoodAge = new FootballPlayer() { Id = 7, Name = "Martin", Age = 2, ShirtNumber = 10 };
        FootballPlayer footballPlayer9TooLowShirt = new FootballPlayer() { Id = 9, Name = "Martin", Age = 29, ShirtNumber = 0 };
        FootballPlayer footballPlayer10GoodShirt = new FootballPlayer() { Id = 10, Name = "Martin", Age = 29, ShirtNumber = 1 };
        FootballPlayer footballPlayer11JustgoodShirt = new FootballPlayer() { Id = 11, Name = "Martin", Age = 29, ShirtNumber = 99 };
        FootballPlayer footballPlayer12TooHighShirt = new FootballPlayer() { Id = 12, Name = "Martin", Age = 29, ShirtNumber = 100 };

        [TestMethod()]
        public void ValidateNameTest()
        {
            footballPlayer1Good.ValidateName();
            footballPlayer4JustEnoughName.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => footballPlayer2NullName.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayer3TooShortName.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => footballPlayer5BlankName.ValidateName());
        }

        [TestMethod()]
        public void ValidateAgeTest()
        {
            footballPlayer1Good.ValidateAge();
            footballPlayer7GoodAge.ValidateAge();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayer6TooYoung.ValidateAge());           
        }

        [TestMethod()]
        public void ValidateShirtNumberTest()
        {
            footballPlayer1Good.ValidateShirtNumber();
            footballPlayer10GoodShirt.ValidateShirtNumber();
            footballPlayer11JustgoodShirt.ValidateShirtNumber();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayer9TooLowShirt.ValidateShirtNumber());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayer12TooHighShirt.ValidateShirtNumber());
        }

        [TestMethod()]
        public void ValidateToStringTest()
        {
            Assert.AreEqual("{Id=1, Name=Martin, Age=29, ShirtNumber=10}", footballPlayer1Good.ToString());
        }

        [TestMethod()]
        public void Validate()
        {
            ValidateNameTest();
            ValidateAgeTest();
            ValidateShirtNumberTest();
            ValidateToStringTest();
        }
    }
}