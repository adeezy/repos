using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class ModifiedStringTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.AreEqual(4, Add(2, 2));
        }

        [Fact]
        public void ValidString()
        {
            // Arrange
            var inputString = "KaTTyPerry";


            // Act


            // Assert
            Assert.AreSame(inputString, "Katty Perry");
        }

        int Add(int x, int y)
        {
            return x + y;
        }
        //string[] words = text.Split(" .".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
}

