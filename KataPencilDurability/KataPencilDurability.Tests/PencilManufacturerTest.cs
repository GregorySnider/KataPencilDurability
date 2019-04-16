using System;
using Xunit;

namespace KataPencilDurability.Tests
{
    public class PencilManufacturerTest
    {
        [Theory]
        [InlineData(4, "text", "text")]
        [InlineData(4, "Text", "Tex ")]

        public void TestPencilManufacturer(int durability,string textToWrite,string expectedValue)
        {
            //Arrange
            String paper = "";

            //Act
            
            paper = paper + textToWrite;


            //Assert
            Assert.Equal(expectedValue, paper);


        }
    }
}
