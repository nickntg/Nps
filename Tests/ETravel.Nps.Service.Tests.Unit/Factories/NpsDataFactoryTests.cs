using ETravel.Nps.Service.Factories;
using NUnit.Framework;

namespace ETravel.Nps.Service.Tests.Unit.Factories
{
    [TestFixture]
    public class NpsDataFactoryTests
    {
        [Test]
        public void TestWithNull()
        {
            Models.Nps nps = null;
            Assert.IsNull(nps.FromModel());
        }

        [Test]
        public void TestConstructionFromModel()
        {
            var nps = new Models.Nps
            {
                brand = "brand",
                comment = "comment",
                country = "country",
                id = "id",
                language = "language",
                ratable_id = "rid",
                ratable_type = "rtype",
                score = 1
            };

            var data = nps.FromModel();

            Assert.IsNotNull(data);
            Assert.AreEqual(data.Brand, nps.brand);
            Assert.AreEqual(data.Comment, nps.comment);
            Assert.AreEqual(data.Country, nps.country);
            Assert.AreEqual(data.Id, nps.id);
            Assert.AreEqual(data.Language, nps.language);
            Assert.AreEqual(data.RatableId, nps.ratable_id);
            Assert.AreEqual(data.RatableType, nps.ratable_type);
            Assert.AreEqual(data.Score, nps.score);
            Assert.IsNull(data.UpdatedAt);
        }
    }
}
