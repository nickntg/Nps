using System;
using System.Net.Http;
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

        [Test]
        public void TestGetIdWithoutResult()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.Get(It.IsAny<string>())).Returns((DataAccess.Entities.Nps) null).Verifiable();

            var c = new NpsController {NpsRepository = repo.Object};

            var result = c.GetRating("id");
            Assert.IsNotNull(result);

            var notfound = result as System.Web.Http.Results.NotFoundResult;
            Assert.IsNotNull(notfound);

            repo.Verify(x => x.Get("id"), Times.Exactly(1));
        }

        [Test]
        public void TestGet()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(new DataAccess.Entities.Nps
                {
                    Brand = "brand",
                    Comment = "comment",
                    Country = "country",
                    CreatedAt = DateTime.Now,
                    Id = "id",
                    Language = "language",
                    RatableId = "rid",
                    RatableType = "rtype",
                    Score = 1,
                    UpdatedAt = DateTime.Now
                })
                .Verifiable();

            var c = new NpsController { NpsRepository = repo.Object };

            var result = c.GetRating("id");
            Assert.IsNotNull(result);

            var returned = result as System.Web.Http.Results.OkNegotiatedContentResult<Models.Nps>;
            Assert.IsNotNull(returned);

            Assert.IsNotNull(returned.Content);
            Assert.AreEqual("id", returned.Content.id);

            repo.Verify(x => x.Get("id"), Times.Exactly(1));
        }

        [Test]
        public void TestPost()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.Save(It.IsAny<DataAccess.Entities.Nps>())).Verifiable();

            var c = new NpsController
            {
                NpsRepository = repo.Object,
                Request = new HttpRequestMessage {RequestUri = new Uri("http://localhost/ratings")}
            };

            var result = c.CreateRating(new Models.Nps());
            Assert.IsNotNull(result);

            var returned = result as System.Web.Http.Results.CreatedNegotiatedContentResult<Models.Nps>;
            Assert.IsNotNull(returned);
            Assert.IsNotNull(returned.Location);

            Assert.IsNotNull(returned.Content);

            repo.Verify(x => x.Save(It.IsAny<DataAccess.Entities.Nps>()), Times.Exactly(1));
        }

        [Test]
        public void TestPut()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.Update(It.IsAny<DataAccess.Entities.Nps>())).Verifiable();
            repo.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(new DataAccess.Entities.Nps
                {
                    Brand = "brand",
                    Comment = "comment",
                    Country = "country",
                    CreatedAt = DateTime.Now,
                    Id = "id",
                    Language = "language",
                    RatableId = "rid",
                    RatableType = "rtype",
                    Score = 1,
                    UpdatedAt = DateTime.Now
                })
                .Verifiable();

            var c = new NpsController { NpsRepository = repo.Object };

            var result = c.UpdateRating("id", new Models.Nps());
            Assert.IsNotNull(result);

            var returned = result as System.Web.Http.Results.OkNegotiatedContentResult<Models.Nps>;
            Assert.IsNotNull(returned);

            Assert.IsNotNull(returned.Content);
            Assert.IsNotNull(returned.Content.updated_at);

            repo.Verify(x => x.Get("id"), Times.Exactly(1));
            repo.Verify(x => x.Update(It.IsAny<DataAccess.Entities.Nps>()), Times.Exactly(1));
        }

        [Test]
        public void TestPutWithKeyThatIsNotInDatabase()
        {
            var repo = new Mock<INpsRepository>(MockBehavior.Strict);
            repo.Setup(x => x.Get(It.IsAny<string>())).Returns((DataAccess.Entities.Nps)null).Verifiable();

            var c = new NpsController {NpsRepository = repo.Object};

            var result = c.UpdateRating("id", new Models.Nps());
            Assert.IsNotNull(result);

            var notfound = result as System.Web.Http.Results.NotFoundResult;
            Assert.IsNotNull(notfound);

            repo.Verify(x => x.Get("id"), Times.Exactly(1));
        }
    }
}
