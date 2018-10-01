using CO.PencilDurability;
using NUnit.Framework;
using System;

namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilDurabilityTest
    {


        //When the pencil is instructed to write a string of text on a sheet of paper,
        //the paper should reflect the text that was written.
        // Refactored: Text written by the pencil should always be appended to existing text on the paper. 
        //Thus, given a piece of paper with the text "She sells sea shells", when a pencil is instructed to write 
        //" down by the sea shore" on the paper, the paper will then contain the entire string (i.e. "She sells sea shells down by the sea shore").
        [TestCase("Hello", "Hello Hello")]
        public void ShouldReflectTextThatWasWritten(string text, string ExpectedResult)
        {
            Writer _writer = new Writer("Hello "); 
            Assert.AreEqual(ExpectedResult, _writer.Write(text));

        }


    }
}
