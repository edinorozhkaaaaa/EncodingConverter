using System;
using System.Text;
using EncodingConverter;

namespace EncodingConverterTest
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void ConvertEncoding_UTF8ToASCII_Success()
        {
            string utf8String = "Привет, мир!";
            string asciiString = DllConverter.ConvertUTF8ToASCII(utf8String);
            Assert.AreNotEqual(utf8String, asciiString); // ASCII не поддерживает кириллицу, поэтому строки будут отличаться.
            Assert.NotNull(asciiString);
        }

        [Test]
        public void ConvertEncoding_UTF8ToASCII_Symbols()
        {
            string expected = "??????????????????";
            string asciiString = DllConverter.ConvertUTF8ToASCII(expected);
            Assert.AreEqual(expected, asciiString);
        }


        [Test]
        public void ConvertEncoding_ASCIIToUTF8_Success()
        {
            string asciiString = "Hello, world!";
            string utf8String = DllConverter.ConvertASCIIToUTF8(asciiString);
            Assert.AreEqual(asciiString, utf8String);
            Assert.NotNull(utf8String);
        }
        [Test]
        public void ConvertEncoding_NullString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => DllConverter.ConvertEncoding(null, Encoding.UTF8, Encoding.ASCII));
        }

        [Test]
        public void ConvertEncoding_NullSourceEncoding_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => DllConverter.ConvertEncoding("test", null, Encoding.ASCII));
        }

        [Test]
        public void ConvertEncoding_NullDestinationEncoding_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => DllConverter.ConvertEncoding("test", Encoding.UTF8, null));
        }
    }
}