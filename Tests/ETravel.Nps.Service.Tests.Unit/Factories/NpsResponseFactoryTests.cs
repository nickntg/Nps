using System;
using ETravel.Nps.Service.Extensions;
using ETravel.Nps.Service.Factories;
using NUnit.Framework;

namespace ETravel.Nps.Service.Tests.Unit.Factories
{
    [TestFixture]
    public class NpsResponseFactoryTests
    {
        [Test]
        public void TestDatabaseToModel()
        {
            var nps = new DataAccess.Entities.Nps
            {
                Brand = "brand",
                Comment = "comment",
                Country = "country",
                CreatedAt = DateTime.Now,
                Id = "1",
                Language = "en",
                RatableId = "ratableid",
                RatableType = "ratabletype",
                Score = 1,
                UpdatedAt = DateTime.Now
            };

            Compare(nps, nps.ToModel());
        }

        [Test]
        public void TestDatabaseToModelArray()
        {
            var nps = new []
            {
                new DataAccess.Entities.Nps
                {
                    Brand = "brand",
                    Comment = "comment",
                    Country = "country",
                    CreatedAt = DateTime.Now,
                    Id = "1",
                    Language = "en",
                    RatableId = "ratableid",
                    RatableType = "ratabletype",
                    Score = 1,
                    UpdatedAt = DateTime.Now
                },
                new DataAccess.Entities.Nps
                {
                    Brand = "brand2",
                    Comment = "comment2",
                    Country = "country2",
                    CreatedAt = DateTime.Now,
                    Id = "2",
                    Language = "en2",
                    RatableId = "ratableid2",
                    RatableType = "ratabletype2",
                    Score = 2,
                    UpdatedAt = DateTime.Now
                }
            };

            var modelNps = nps.ToModel();
            Assert.IsNotNull(modelNps);
            Assert.AreEqual(2, modelNps.Length);
            for (var i = 0; i < modelNps.Length; i++)
            {
                Compare(nps[i], modelNps[i]);
            }
        }

        [Test]
        public void TestDatabaseToModelWithNull()
        {
            DataAccess.Entities.Nps nps = null;
            Assert.IsNull(nps.ToModel());
        }

        [Test]
        public void TestDatabaseToModelArrayWithNull()
        {
            DataAccess.Entities.Nps[] nps = null;
            Assert.IsNull(nps.ToModel());
        }

        public void Compare(DataAccess.Entities.Nps nps, Models.Nps modelNps)
        {
            Assert.IsNotNull(modelNps);
            Assert.AreEqual(nps.Brand, modelNps.brand);
            Assert.AreEqual(nps.Comment, modelNps.comment);
            Assert.AreEqual(nps.Country, modelNps.country);
            Assert.AreEqual(nps.CreatedAt.ToIso8601(), modelNps.created_at);
            Assert.AreEqual(nps.Id, modelNps.id);
            Assert.AreEqual(nps.Language, modelNps.language);
            Assert.AreEqual(nps.RatableId, modelNps.ratable_id);
            Assert.AreEqual(nps.RatableType, modelNps.ratable_type);
            Assert.AreEqual(nps.Score, modelNps.score);
            Assert.AreEqual(nps.UpdatedAt.ToIso8601(), modelNps.updated_at);            
        }
    }
}
