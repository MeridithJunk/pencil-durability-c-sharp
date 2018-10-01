using CO.PencilDurability;
using NUnit.Framework;
using System;

namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilDurabilityTest
    {
        private Writer _writer;
        private string Text = "She sells sea shells ";

        [SetUp]
        public void SetUp()
        {

            _writer = new Writer(Text); 
        }

        //When the pencil is instructed to write a string of text on a sheet of paper,
        //the paper should reflect the text that was written.
        // Refactored: Text written by the pencil should always be appended to existing text on the paper. 
        //Thus, given a piece of paper with the text "She sells sea shells", when a pencil is instructed to write 
        //" down by the sea shore" on the paper, the paper will then contain the entire string (i.e. "She sells sea shells down by the sea shore").
        [TestCase("down by the sea shore", "She sells sea shells down by the sea shore")]
        public void ShouldReflectTextThatWasWritten(string text, string ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, _writer.Write(text));

        }

        //When a pencil is created, it can be provided with a value for point durability. 
        //The pencil will be able to write only a limited number of characters before it goes dull. 
        //After it goes dull, every character it is directed to write will appear as a space. 
        //A pencil created with a high point durability will still go dull, but not as fast as one with a 
        //lower durability rating.
        [Test]
        public void PencilShouldAppendTextbasedOnPencilDurability()
        {
            Pencil pencil = new Pencil()
            {
                Durability = 3
            };
            pencil = _writer.AppendWritingBasedOnPencilDurability("Hello", pencil);

            Assert.AreEqual(pencil.textWritten, pencil.textWritten);

        }

        //lowercase letters should degrade the pencil point by a value of one, and capital letters should degrade the point by two.hence when a pencil with a point durability 
        //of four is instructed to write the string "text", the paper will contain the entire string. but if a pencil with point durability of four is instructed to write the 
        //string "text", the paper will only show "tex ".
        [Test]
        public void PencilShouldReduceDurabilityWhenWriting()
        {
            Pencil pencil = new Pencil()
            {
                Durability = 3
            };

            pencil = _writer.AppendWritingBasedOnPencilDurability("Hello", pencil); 
            Assert.AreEqual(0, pencil.Durability);

        }

        //Writing spaces and newlines expends no graphite, therefore "writing" these characters should not affect the pencil point.
        [Test]
        public void WrittenTextShouldMaintainTheSameCharacterCount()
        {
            Pencil pencil = new Pencil()
            {
                Durability = 3
            };

            pencil = _writer.AppendWritingBasedOnPencilDurability("Hello There", pencil);
            Assert.AreEqual("He         ", pencil.textWritten);
        }



    }
}
