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
        [TestCase("Hello", "Hello")]
        public void ShouldReflectTextThatWasWritten(string text, string ExpectedResult)
        {
            Writer _writer = new Writer(); 
            Assert.AreEqual(ExpectedResult, _writer.Write(text));

        }

    }
}
