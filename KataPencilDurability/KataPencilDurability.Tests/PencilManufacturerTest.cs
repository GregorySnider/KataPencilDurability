using System;
using Xunit;

namespace KataPencilDurability.Tests
{
    public class PencilManufacturerTest
    {
        [Theory]
        [InlineData(4, "text", "text")]
        //[InlineData(4, "Text", "Tex ")]

        public void TestPencilManufacturer(int durability,string textToWrite,string expectedValue)
        {
            //Arrange
            String paper = "";

            //Act
            Pencil pencil = new Pencil();
            pencil.Durability = durability;
            paper = paper + pencil.Write(textToWrite);


            //Assert
            Assert.Equal(expectedValue, paper);


        }
    }
}
