using Domain.Entities;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class TextEntityTests
    {
        [Test]
        public void SimpleTextEntityTest()
        {
            var text = "This is simple text with 7 words.";
            
            var textEntity = new TextEntity(text);
            
            Assert.IsTrue(textEntity.GetCountOfWordsFromText() == 7);
        }
        
        [Test]
        public void EmptyTextTest()
        {
            var text = "";
            
            var textEntity = new TextEntity(text);
            
            Assert.IsTrue(textEntity.GetCountOfWordsFromText() == 0);
        }
    }
}