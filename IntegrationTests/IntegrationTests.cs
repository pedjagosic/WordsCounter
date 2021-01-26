using Application.Stores;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Stores;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class IntegrationTests
    {
        private ITextStore _store;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _store = new TextStore(new TextDbContext());
        }

        [Test]
        public async Task AddTextIntoDb()
        {
            var textEntity = new TextEntity("");

            var result = await _store.AddAsync(textEntity);
            Assert.IsTrue(result == 1);
        }

        // [TearDown]
        // public async Task AfterExecute()
        // {
        //     await _store.DeleteAllAsync();
        // }
    }
}