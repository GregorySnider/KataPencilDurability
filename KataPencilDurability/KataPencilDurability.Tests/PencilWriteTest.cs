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
            Pencil pencil = new Pencil(textToWrite.Length, 1);
            paper = paper + pencil.Write(textToWrite);


            //Assert
            String expectedValue = "She sells sea shells down by the sea shore";
            Assert.Equal(expectedValue, paper);


        }
        [Fact]
        public void TestPencilEraser()
        {
            //Arrange
            String paper = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";

            //Act
            String textToErase = "chuck";
            //Added EraserDurability to constructor
            Pencil pencil = new Pencil(textToErase.Length, 1, 100);
            paper = pencil.Erase(paper, textToErase);//Erase chuck once
            paper = pencil.Erase(paper,textToErase);//Erase chuck twice

            //Assert
            String expectedValue = "How much wood would a woodchuck chuck if a wood      could       wood?";
            Assert.Equal(expectedValue, paper);

        }

        [Theory]
        [InlineData(5,5,"paper value","value","paper      ")]//Many Erases
        [InlineData(3, 1, "Buffalo Bill", "Bill", "Buffalo B   ")]//One erase, not enough eraser left
        [InlineData(0,0,"","","")]//No Erases

        public void TestPencilEraserDurability(int EraserDurability,int Erasings,string PaperValue, string TextToErase, string ExpectedOutput)
        {
            //Arrange
            //TODO - fix Hardcoded durability and length, 
            //hardcoded because they are irrelavent for this test
            Pencil pencil = new Pencil(1000,100,EraserDurability);

            //Act
            //TODO - implement loop for erasing multiple times
            string paper = PaperValue;
            while (Erasings > 0)
            {
                Erasings--;
                paper = pencil.Erase(paper, TextToErase);
            }

            //Assert
            Assert.Equal(ExpectedOutput, paper);

        }


        [Theory]
        //durability, pencilLength, numberOfSharpenings, expectedDurability
        [InlineData(40000, 5, 10, 40000)]//Many sharpenings, no writes
        [InlineData(40000, 1, 2, 40000)]//One sharpening, no writes
        [InlineData(40000, 5, 0, 40000)]//Zero sharpenings, no writes
        public void TestPencilWriterSharpenDurabilityRestore(int durability, int pencilLength, int numberOfSharpenings, int expectedDurability)
        {
            //Arrange
            Pencil pencil = new Pencil(durability, pencilLength);

            //Act

            while (numberOfSharpenings > 0)
            {
                numberOfSharpenings--;
                pencil.Sharpen();
            }


            //Assert
            Assert.Equal(expectedDurability, pencil.Durability);
        }

        [Theory]
        //durability, pencilLength, numberOfSharpenings, textToWrite, expectedDurability
        [InlineData(40000, 5, 10, "a", 39999)]//Many sharpenings, one write
        [InlineData(40000, 1, 2, "abcdefg", 39993)]//One sharpening, many writes
        [InlineData(40000, 5, 0, "", 40000)]//Zero sharpenings, no writes
        public void TestPencilWriterSharpenDurabilityPreservation(int durability, int pencilLength, int numberOfSharpenings, string textToWrite, int expectedDurability)
        {
            //Arrange
            Pencil pencil = new Pencil(durability, pencilLength);

            //Act

            while (numberOfSharpenings > 0)
            {
                numberOfSharpenings--;
                pencil.Sharpen();
            }
            pencil.Write(textToWrite);

            //Assert
            Assert.Equal(expectedDurability, pencil.Durability);
        }

        [Theory]
        //durability, pencilLength, numberOfSharpenings, expectedLength
        [InlineData(40000, 5, 20, 0)]//Many sharpenings, no writes
        [InlineData(40000, 6, 1, 5)]//One sharpening, no writes
        [InlineData(40000, 5, 0, 5)]//Zero sharpenings
        public void TestPencilWriterSharpenLength(int durability, int pencilLength, int numberOfSharpenings, int expectedLength)
        {
            //Arrange
            Pencil pencil = new Pencil(durability, pencilLength);

            //Act
            while (numberOfSharpenings > 0)
            {
                numberOfSharpenings--;
                pencil.Sharpen();
            }

            //Assert

            Assert.Equal(expectedLength, pencil.Length);
        }

    }
}
