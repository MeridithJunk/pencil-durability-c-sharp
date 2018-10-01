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
           Assert.AreEqual("He", _writer.AppendWritingBasedOnPencilDurability("Hello", pencil));

        }


}
}
