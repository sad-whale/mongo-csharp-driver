/* Copyright 2010-2015 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using Xunit;

namespace MongoDB.Driver.Tests.Jira.CSharp532
{
    public class CSharp532Tests
    {
        [BsonKnownTypes(typeof(B))]
        public abstract class A
        {

        }

        public class B : A
        {

        }

        public class C
        {
            [BsonElement("a")]
            public A A { get; set; }
        }

        [Fact]
        public void TestTypedBuildersWithSubclasses()
        {
            var b = new B();

            Update<C>.Set(c => c.A, b);
        }
    }
}