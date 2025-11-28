// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubServiceTests
    {
        [TestCase]
        public void TestValidationOptionsParser()
        {
            var testconnection = "Endpoint=http://abc;Port=888;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A;Version=1.0;";
            var configs = new WebPubSubValidationOptions(testconnection);

            Assert.IsTrue(configs.TryGetKey("abc", out var key));
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A", key);
        }

        [TestCase]
        public void TestValidationOptionsWithoutAccessKey()
        {
            var testconnection = "Endpoint=http://abc;Version=1.0;";
            var configs = new WebPubSubValidationOptions(testconnection);

            Assert.IsTrue(configs.TryGetKey("abc", out var key));
            Assert.Null(key);
        }
    }
}
