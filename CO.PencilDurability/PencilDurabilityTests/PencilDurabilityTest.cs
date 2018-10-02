﻿using CO.PencilDurability;
using NUnit.Framework;
using System;

namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilDurabilityTest
    {
        private Writer _writer;
        private Pencil _pencil;
        private Edit _edit;
        private Pencils _pencils;
        private string text = "She sells sea shells ";

        [SetUp]
        public void SetUp()
        {
            _pencils = new Pencils();

            _pencil = _pencils.CreatePencil();
            _writer = new Writer( _pencil);
            _edit = new Edit(_pencil);
            _pencils = new Pencils();
        }

        //When the pencil is instructed to write a string of text on a sheet of paper,
        //the paper should reflect the text that was written.
        // Refactored: Text written by the pencil should always be appended to existing text on the paper. 
        //Thus, given a piece of paper with the text "She sells sea shells", when a pencil is instructed to write 
        //" down by the sea shore" on the paper, the paper will then contain the entire string (i.e. "She sells sea shells down by the sea shore").
        [TestCase("She sells sea shells", " down by the sea shore", "She sells sea shells down by the sea shore")]
        public void ShouldReflectTextThatWasWritten(string text1, string text2, string ExpectedResult)
        {
            _writer.Write(text1);
            Assert.AreEqual(ExpectedResult, _writer.Write(text2));

        }

        //When a pencil is created, it can be provided with a value for point durability. 
        //The pencil will be able to write only a limited number of characters before it goes dull. 
        //After it goes dull, every character it is directed to write will appear as a space. 
        //A pencil created with a high point durability will still go dull, but not as fast as one with a 
        //lower durability rating.
        [Test]
        [TestCase(100, "Hello There", "Hello There")]
        public void PencilShouldAppendTextbasedOnPencilDurability(int durability, string text, string expectedResult)
        {
            Pencil pencil = new Pencil()
            {
                Durability = durability,
                
            };
            _writer = new Writer(pencil);
            Assert.AreEqual(expectedResult, _writer.Write(text));

        }

        //lowercase letters should degrade the pencil point by a value of one, and capital letters should degrade the point by two.hence when a pencil with a point durability 
        //of four is instructed to write the string "text", the paper will contain the entire string. but if a pencil with point durability of four is instructed to write the 
        //string "text", the paper will only show "tex ".
        [Test]
        [TestCase(10, "Hello There", 0)]
        public void PencilShouldReduceDurabilityWhenWriting(int durability, string text, int expectedResult)
        {
            Pencil pencil = new Pencil()
            {
                Durability = durability
            };

            _writer = new Writer(pencil);
            _writer.Write(text); 
            Assert.AreEqual(expectedResult, pencil.Durability);

        }

        //Writing spaces and newlines expends no graphite, therefore "writing" these characters should not affect the pencil point.
        [Test]
        [TestCase(10, "Hello There", "Hello The  ")]
        public void WrittenTextShouldMaintainTheSameCharacterCount(int durability, string text, string expectedResult)
        {
            Pencil pencil = new Pencil()
            {
                Durability = durability
            };

            _writer = new Writer(pencil); 
            Assert.AreEqual(expectedResult, _writer.AppendWritingBasedOnPencilDurability(text));
        }

        //when a pencil is sharpened, it regains its initial point durability and can write more characters before
        //it goes dull again.thus, given a pencil created with point durability of 40,000 that has since degraded, 
        //when it is sharpened, its point durability will be 40,000 again.
        [Test]
        public void PencilShouldBeSharpened()
        {
            _pencil =new Pencil {
               Durability  = 10, 
               Length = 10
            };
            _pencils.SharpenPencil(_pencil);
            Assert.AreEqual(30000, _pencil.Durability);
        }

        //Pencil Length should decrease everytime Pencil is resharpened
        //A pencil should also be created with an initial length value.Pencils of short lengthwill only be sharpenable a small number of times while 
        //pencils of longer length can be sharpened more times.The pencil's length is reduced by one each time it is sharpened. When a pencil's length is zero, then sharpening it no longer restores its point durabliity.
        [Test]
        [TestCase(10, 10)]
        public void ShouldDecreaseLengthEverytimePencilIsSharpened(int durability, int length)
        {
            _pencil = new Pencil()
            {
                Durability = durability,
                Length = length
            };
            _pencils.SharpenPencil(_pencil);
            _pencils.SharpenPencil(_pencil);
            Assert.AreEqual(length - 2, _pencil.Length);
        }

        public void ShouldNotResetPencilDurabilityAfterPencilLengthIsZero()
        {
            _pencil = new Pencil()
            {
                Durability = 5
            };
            _pencils.SharpenPencil(_pencil);
            _pencils.SharpenPencil(_pencil);
            _pencils.SharpenPencil(_pencil);
            _pencils.SharpenPencil(_pencil);
            Assert.AreEqual(0, _pencil.Durability);
        }

        //When the pencil is instructed to erase text from the paper, the last occurrence of that text on the paper will be replaced with empty spaces.
        [Test]
        [TestCase("How Much wood would a woodchuck chuck if a woodchuck could chuck wood?", "chuck", 5, "How Much wood would a woodchuck chuck if a woodchuck could       wood?")]
        [TestCase("woodchuck chuck if a woodchuck could       wood?", "chuck", 4, "woodchuck chuck if a woodc     could       wood?")]
        [TestCase("She sells Sea shells", "sells", 2, "She sel   Sea shells")]
        public void ShouldEraseLastOccuranceOfWordFromString(string text, string erase, int EraserDurability, string expectedResult)
        {
            _pencil = new Pencil
            {
                Eraser = EraserDurability
            };
            _edit = new Edit(_pencil);

            Assert.AreEqual(expectedResult, _edit.EraseWordFromText(text, erase));
        }
        //TO DO HERE: 
        // When a pencil is created, it can be provided with a value for eraser durability.For simplicity, all characters except
        // for white space should degrade the eraser by a value of one.Text should be erased in the opposite order it was written. Once the eraser durability is zero, the eraser is worn out and can no longer erase.
        [Test]
        [TestCase("sells", "She sells ", 100, 4)]
        public void ShouldDegradeEraserAsItDegrades(string erase, string text, int EraserDurability, int index)
        {
             var pencil = new Pencil
            {
                Eraser = EraserDurability,
                IndexOfLastRemovedWord = index

             };
            
            _edit = new Edit(pencil);
            _edit.EraseWordFromText(text, erase);
            Assert.AreEqual(EraserDurability - erase.Length, pencil.Eraser);
        }

        [Test]
        public void EraserShouldOnlyEraseAsMuchAsItsCapableOfErasing()
        {
            _pencil = new Pencil
            {
                Eraser = 2
            };
            _edit = new Edit(_pencil);
            var erase = "sells";
            Assert.AreEqual("She sel   sea shells ", _edit.EraseWordFromText(text, erase));

        }

        //Once text has been erased from the paper, a pencil may be instructed to write new text over the resulting white 
        //space.For instance, if the paper contains the text "An       a day keeps the doctor away", a pencil can can be instructed to write the word "onion"
        //in the white space gap, so the text reads "An onion a day keeps the doctor away".
        [Test]
        [TestCase("onion", "An       a day keeps the doctor away", "An onion a day keeps the doctor away")]
        public void ShouldBeAbleToEdit(string addword, string text, string ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, _edit.EditTextRemoveWord(text, addword));
        }

        [Test]
        [TestCase("onion", "An       a day keeps the doctor away", 3)]
        public void ShouldUpdatePencilToBeCorrectLastEditedIndex(string addword, string text, int ExpectedResult)
        {
            _edit.EditTextRemoveWord(text, addword);
            Assert.AreEqual(ExpectedResult, _pencil.IndexOfLastRemovedWord);
        }


        //Existing text on the page cannot 'shift' to make room for new text.If the new text is longer than the allocated whitespace and thus would collide with other 
        //existing non-whitespace characters on the page, these character collisions should be represented by the "@" character.For example, writing "artichoke" in 
        //the middle of "An       a day keeps the doctor away" would result in "An artich@k@ay keeps the doctor away".
        [Test]
        [TestCase("An       a day keeps the doctor away", "artichoke", 3, "An artich@k@ay keeps the doctor away")]
        public void WhenTextOverlapsFromEditingLettersAreReplacedWithATsign(string text, string replacementWord, int IndexOfLastRemovedWord, string expectedResult)
        {
            _pencil = new Pencil
            {
                IndexOfLastRemovedWord = IndexOfLastRemovedWord
            };
            _edit = new Edit(_pencil);
            Assert.AreEqual(expectedResult, _edit.ReplaceinText(text, replacementWord));
        }


    }
}
