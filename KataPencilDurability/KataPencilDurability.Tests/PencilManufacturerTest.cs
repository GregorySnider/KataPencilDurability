using System;
using Xunit;

namespace KataPencilDurability.Tests
{
    public class PencilManufacturerTest
    {
        [Theory] 
        //durability, textToWrite, expectedValue
        [InlineData(4, "text", "text")]
        [InlineData(4, "Text", "Tex ")]
        [InlineData(8, "Tex Mex", "Tex Mex")]
        [InlineData(6, "text \r\n me", "text \r\n me")]


        public void TestPencilManufacturer(int durability,string textToWrite,string expectedValue)
        {
            //Arrange
            String paper = "";

            //Act
            Pencil pencil = new Pencil(durability, 1);
            paper = paper + pencil.Write(textToWrite);


            //Assert
            Assert.Equal(expectedValue, paper);


        }
    }
}
