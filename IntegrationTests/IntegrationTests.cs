using System.Linq;
using Application.Stores;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Stores;
using NUnit.Framework;
using System.Threading.Tasks;
using Infrastructure.TypeConverters;

namespace IntegrationTests
{
    public class IntegrationTests
    {
        private ITextStore _store;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _store = new TextStore(new TextDbContext(), new TextEntityToTextDtoConverter());
        }

        [Test]
        public async Task AddTextIntoDb()
        {
            var textEntity = new TextEntity("This is simple text.");

            var result = await _store.AddAsync(textEntity);
            Assert.IsTrue(result == 1);
        }

        [Test]
        public async Task GetTextsFromDb()
        {
            await _store.AddAsync(new TextEntity("Simple text."));
            var result = await _store.GetAllAsync();
            Assert.IsTrue(result.Any());
        }

        // [TearDown]
        // public async Task AfterExecute()
        // {
        //     await _store.DeleteAllAsync();
        // }
    }
}