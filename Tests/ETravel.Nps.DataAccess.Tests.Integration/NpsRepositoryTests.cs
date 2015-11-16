using System;
using ETravel.Nps.DataAccess.Repositories;
using ETravel.Nps.DataAccess.Repositories.Interfaces;
using NUnit.Framework;

namespace ETravel.Nps.DataAccess.Tests.Integration
{
    [TestFixture]
    public class NpsRepositoryTests
    {
        [Test, Ignore]
        public void TestGetByRatableType()
        {
            var repo = new NpsRepository();
            var results = repo.RetrieveByRatableType("CustomerSupportCase");
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length > 1);
        }

        [Test, Ignore]
        public void TestGetByRatableId()
        {
            var repo = new NpsRepository();
            var results = repo.RetrieveByRatableId("bb0a9381f2334b5da4034d78792189ed");
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length == 2);
        }

        [Test, Ignore]
        public void TestGetByRatableTypeAndId()
        {
            var repo = new NpsRepository();
            var results = repo.RetrieveByRatableTypeAndId("CustomerSupportCase", "bb0a9381f2334b5da4034d78792189ed");
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Length == 1);
        }

        [Test, Ignore]
        public void TestSaveAndRetrieve()
        {
            TestSaveAndRetrieve(new NpsRepository(), Guid.NewGuid().ToString("N"), "some comment");
        }

        [Test, Ignore]
        public void TestUpdateAndRetrieve()
        {
            var repo = new NpsRepository();
            var id = Guid.NewGuid().ToString("N");
            var nps = TestSaveAndRetrieve(repo, id, string.Empty);
            nps.Comment = "some comment";
            repo.Update(nps);

            var result = repo.Get(id);
            Assert.IsNotNull(result);
            Assert.AreEqual("some comment", nps.Comment);
        }

        private Entities.Nps TestSaveAndRetrieve(INpsRepository repo, string id, string comment)
        {
            var nps = new Entities.Nps
            {
                Brand = "somebrand",
                Comment = comment,
                Country = "Greece",
                CreatedAt = DateTime.Now,
                Id = id,
                Language = "lang",
                RatableId = "rid",
                RatableType = "rtype",
                Score = 5,
                UpdatedAt = DateTime.Now
            };

            repo.Save(nps);

            var result = repo.Get(id);
            Assert.IsNotNull(result);

            return nps;
        }
    }
}
