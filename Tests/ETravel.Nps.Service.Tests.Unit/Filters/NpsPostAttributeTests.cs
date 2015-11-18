using System.Collections.Generic;
using System.Net;
using ETravel.Nps.Service.Filters;
using NUnit.Framework;

namespace ETravel.Nps.Service.Tests.Unit.Filters
{
    [TestFixture]
    public class NpsPostAttributeTests
    {
        [Test]
        public void TestNullArguments()
        {
            Test(null, true, false, HttpStatusCode.BadRequest, ValidationMessages.NoNpsArguments);
        }

        [Test]
        public void TestNoArguments()
        {
            Test(null, false, true, HttpStatusCode.BadRequest, ValidationMessages.NoNpsArguments);
        }

        [Test]
        public void TestNullNps()
        {
            Test(null, false, false, HttpStatusCode.BadRequest, ValidationMessages.InvalidOrEmptyNps);
        }

        [Test]
        public void TestNoBrand()
        {
            Test(new Models.Nps(), false, false, (HttpStatusCode)422, ValidationMessages.BrandMustHaveAValue);
        }

        [Test]
        public void TestNoCountry()
        {
            Test(new Models.Nps { brand = "brand" }, false, false, (HttpStatusCode)422, ValidationMessages.CountryMustHaveAValue);
        }

        [Test]
        public void TestNoLanguage()
        {
            Test(new Models.Nps { brand = "brand", country = "country" }, false, false, (HttpStatusCode)422, ValidationMessages.LanguageMustHaveAValue);
        }

        [Test]
        public void TestNoRatableId()
        {
            Test(new Models.Nps {brand = "brand", country = "country", language = "language" }, false, false,
                (HttpStatusCode) 422, ValidationMessages.RatableIdMustHaveAValue);
        }

        [Test]
        public void TestNoRatableType()
        {
            Test(new Models.Nps {brand = "brand", country = "country", language = "language", ratable_id = "id" }, false,
                false,
                (HttpStatusCode) 422, ValidationMessages.RatableTypeMustHaveAValue);
        }

        [TestCase(0)]
        [TestCase(11)]
        public void TestInvalidScore(int score)
        {
            Test(
                new Models.Nps
                {
                    brand = "brand",
                    country = "country",
                    language = "language",
                    ratable_id = "id",
                    ratable_type = "type",
                    score = score
                }, false,
                false,
                (HttpStatusCode) 422, ValidationMessages.ScoreMustBeBetweenOneAndTen);
        }

        [Test]
        public void TestValid()
        {
            Test(
                new Models.Nps
                {
                    brand = "brand",
                    country = "country",
                    language = "language",
                    ratable_id = "id",
                    ratable_type = "type",
                    score = 5
                }, false,
                false,
                HttpStatusCode.OK, null);
        }

        public void Test(Models.Nps nps, bool nullDictionary, bool nullNps, HttpStatusCode expectedCode, string expectedMessage)
        {
            var v = new NpsPostAttribute();
            Dictionary<string, object> dic = null;
            if (!nullDictionary)
            {
                dic = new Dictionary<string, object>();
                if (!nullNps)
                {
                    dic.Add("nps", nps);
                }
            }

            var result = v.Validate(dic);

            if (string.IsNullOrEmpty(expectedMessage))
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(expectedCode, result.StatusCode);
                Assert.AreEqual(expectedMessage, result.Message);
            }
        }
    }
}
