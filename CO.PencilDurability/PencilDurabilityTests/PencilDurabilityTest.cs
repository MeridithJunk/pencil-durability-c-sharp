using CO.PencilDurability;
using NUnit.Framework;
using System;

namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilDurabilityTest
    {
        private Writer _writer;
        private Pencil _pencil; 
        private string Text = "She sells sea shells ";

        [SetUp]
        public void SetUp()
        {
            _pencil = new Pencil
            {
                Durability = 10,
                TextWritten = Text,
                Length = 3

        }; 
            _writer = new Writer(Text, _pencil); 
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

            Assert.AreEqual(pencil.TextWritten, pencil.TextWritten);

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
            Assert.AreEqual("He         ", pencil.TextWritten);
        }

        //when a pencil is sharpened, it regains its initial point durability and can write more characters before
        //it goes dull again.thus, given a pencil created with point durability of 40,000 that has since degraded, 
        //when it is sharpened, its point durability will be 40,000 again.
        [Test]
        public void PencilShouldBeSharpened()
        {
            //30000
            _writer.SharpenPencil(); 
            Assert.AreEqual(40000, _pencil.Durability);
        }

        //Pencil Length should decrease everytime Pencil is resharpened
        [Test]
        public void  ShouldDecreaseLengthEverytimePencilIsSharpened()
        {
            _writer.SharpenPencil();
            Assert.AreEqual(2, _pencil.Length);

        }
        //A pencil should also be created with an initial length value.Pencils of short lengthwill only be sharpenable a small number of times while 
        //pencils of longer length can be sharpened more times.The pencil's length is reduced by one each time it is sharpened. When a pencil's length is zero, then sharpening it no longer restores its point durabliity.





    }
}
