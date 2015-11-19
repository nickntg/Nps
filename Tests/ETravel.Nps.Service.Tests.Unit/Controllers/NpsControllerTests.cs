using ETravel.Nps.DataAccess.Repositories.Interfaces;
using ETravel.Nps.Service.Controllers;
using Moq;
using NUnit.Framework;

namespace ETravel.Nps.Service.Tests.Unit.Controllers
{
    [TestFixture]
    public class NpsControllerTests
    {
        [Test]
        public void TestGetRatablesWithoutResults()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Loose);
            var c = new NpsController {NpsRepository = repo.Object};

            var result = c.GetRatings("id", "type");
            Assert.IsNotNull(result);
            var returned = result as System.Web.Http.Results.OkNegotiatedContentResult<Models.Nps[]>;
            Assert.IsNotNull(returned);

            Assert.IsNotNull(returned.Content);
            Assert.AreEqual(0, returned.Content.Length);
        }

        [Test]
        public void TestGetRatablesWithEmptyRatableId()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.RetrieveByRatableType(It.IsAny<string>()))
                .Returns(new[] {new DataAccess.Entities.Nps(), new DataAccess.Entities.Nps()})
                .Verifiable();           

            var c = new NpsController { NpsRepository = repo.Object };

            var result = c.GetRatings(null, "type");
            Assert.IsNotNull(result);
            var returned = result as System.Web.Http.Results.OkNegotiatedContentResult<Models.Nps[]>;
            Assert.IsNotNull(returned);

            Assert.IsNotNull(returned.Content);
            Assert.AreEqual(2, returned.Content.Length);

            repo.Verify(x => x.RetrieveByRatableType("type"), Times.Exactly(1));
        }

        [Test]
        public void TestGetRatablesWithEmptyRatableType()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.RetrieveByRatableId(It.IsAny<string>()))
                .Returns(new[] { new DataAccess.Entities.Nps(), new DataAccess.Entities.Nps() })
                .Verifiable();

            var c = new NpsController { NpsRepository = repo.Object };

            var result = c.GetRatings("id", null);
            Assert.IsNotNull(result);
            var returned = result as System.Web.Http.Results.OkNegotiatedContentResult<Models.Nps[]>;
            Assert.IsNotNull(returned);

            Assert.IsNotNull(returned.Content);
            Assert.AreEqual(2, returned.Content.Length);

            repo.Verify(x => x.RetrieveByRatableId("id"), Times.Exactly(1));
        }

        [Test]
        public void TestGetRatablesWithBothParameters()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.RetrieveByRatableTypeAndId(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new[] {new DataAccess.Entities.Nps(), new DataAccess.Entities.Nps()})
                .Verifiable();

            var c = new NpsController { NpsRepository = repo.Object };

            var result = c.GetRatings("id", "type");
            Assert.IsNotNull(result);
            var returned = result as System.Web.Http.Results.OkNegotiatedContentResult<Models.Nps[]>;
            Assert.IsNotNull(returned);

            Assert.IsNotNull(returned.Content);
            Assert.AreEqual(2, returned.Content.Length);

            repo.Verify(x => x.RetrieveByRatableTypeAndId("type", "id"), Times.Exactly(1));
        }
    }
}
