using System.Collections.Generic;
using System.Net;
using ETravel.Nps.Service.Filters;
using NUnit.Framework;

namespace ETravel.Nps.Service.Tests.Unit.Filters
{
    [TestFixture]
    public class NpsGetAtributeTests
    {
        [Test]
        public void TestNullArguments()
        {
            Test(null, null, true, false, HttpStatusCode.BadRequest, ValidationMessages.NoArguments);
        }

        [Test]
        public void TestNoArguments()
        {
            Test(null, null, false, true, HttpStatusCode.BadRequest, ValidationMessages.NoArguments);
        }

        [TestCase(null, null, (HttpStatusCode)422, ValidationMessages.RatableIdAndTypeMustNotBothBeEmpty)]
        [TestCase("some", null, HttpStatusCode.OK, null)]
        [TestCase("some", "some", HttpStatusCode.OK, null)]
        [TestCase(null, "some", HttpStatusCode.OK, null)]
        public void TestWithArguments(string ratableId, string ratableType, HttpStatusCode expectedCode,
            string expectedMessage)
        {
            Test(ratableId, ratableType, false, false, expectedCode, expectedMessage);
        }

        public void Test(string ratableId, string ratableType, bool nullDictionary, bool nullItems, HttpStatusCode expectedCode, string expectedMessage)
        {
            var v = new NpsGetAttribute();
            Dictionary<string, object> dic = null;
            if (!nullDictionary)
            {
                dic = new Dictionary<string, object>();
                if (!nullItems)
                {
                    dic.Add("ratable_type", ratableType);
                    dic.Add("ratable_id", ratableId);
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