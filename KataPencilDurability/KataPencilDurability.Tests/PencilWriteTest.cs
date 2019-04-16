using System;
using Xunit;

namespace KataPencilDurability.Tests
{
    public class PencilWriteTest
    {
        [Fact]
        public void TestPencilWriter()
        {
            //Arrange
            String paper = "She sells sea shells";

            //Act
            //Write with our pencil " down by the sea shore";
            String textToWrite = " down by the sea shore";
           // paper = paper + textToWrite;


            //Assert
            String expectedValue = "She sells sea shells down by the sea shore";
            Assert.Equal(expectedValue, paper);


        }
    }
}
