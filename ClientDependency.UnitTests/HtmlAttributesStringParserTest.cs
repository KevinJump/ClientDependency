﻿using System.Linq;
using ClientDependency.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClientDependency.UnitTests
{
    
    
    [TestFixture]
    public class HtmlAttributesStringParserTest
    {
        [Test]
        public void Ensure_No_Duplicates()
        {
            const string attributes = "defer:true,async:true";
            var destination = new Dictionary<string, string>();

            HtmlAttributesStringParser.ParseIntoDictionary(attributes, destination);

            Assert.AreEqual(2, destination.Count);
            Assert.AreEqual("defer", destination.First().Key);
            Assert.AreEqual("true", destination.First().Value);
            Assert.AreEqual("async", destination.Last().Key);
            Assert.AreEqual("true", destination.Last().Value);

        }

        [Test]
        public void Parse_Media_Query()
        {
            const string attributes = "media:(max-width:560px)";
            var destination = new Dictionary<string, string>();

            HtmlAttributesStringParser.ParseIntoDictionary(attributes, destination);

            Assert.AreEqual(1, destination.Count);
            Assert.AreEqual("(max-width:560px)", destination.Last().Value);
            Assert.AreEqual("media", destination.Last().Key);

        }

        [Test]
        public void Parse_Delimited_String_With_Comma()
        {
            const string attributes = "media:'print, projection'";
            var destination = new Dictionary<string, string>();
            
            HtmlAttributesStringParser.ParseIntoDictionary(attributes, destination);
            
            Assert.AreEqual(1, destination.Count);
            Assert.AreEqual("print, projection", destination.Last().Value);
            Assert.AreEqual("media", destination.Last().Key);

        }

        [Test]
        public void Parse_Normal_String()
        {
            const string attributes = "media:print";
            var destination = new Dictionary<string, string>();

            HtmlAttributesStringParser.ParseIntoDictionary(attributes, destination);

            Assert.AreEqual(1, destination.Count);
            Assert.AreEqual("print", destination.Last().Value);
            Assert.AreEqual("media", destination.Last().Key);

        }
    }
}
