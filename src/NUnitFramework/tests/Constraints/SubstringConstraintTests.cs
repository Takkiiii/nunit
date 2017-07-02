// ***********************************************************************
// Copyright (c) 2007 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using NUnit.Framework.Internal;

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class SubstringConstraintTests : StringConstraintTests
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new SubstringConstraint("hello");
            expectedDescription = "String containing \"hello\"";
            stringRepresentation = "<substring \"hello\">";
        }

        static object[] SuccessData = new object[] { "hello", "hello there", "I said hello", "say hello to fred" };
        
        static object[] FailureData = new object[] { 
            new TestCaseData( "goodbye", "\"goodbye\"" ), 
            new TestCaseData( "HELLO", "\"HELLO\"" ),
            new TestCaseData( "What the hell?", "\"What the hell?\"" ),
            new TestCaseData( string.Empty, "<string.Empty>" ),
            new TestCaseData( null, "null" ) };

        [TestCase]
        public void Using_CurrentCulture()
        {
            Assert.That(" ss ", Contains.Substring("ß").Using(StringComparison.CurrentCulture));
            Assert.That(" SS ", new NotConstraint(Contains.Substring("ß").Using(StringComparison.CurrentCulture)));
        }

        [TestCase]
        public void Using_Ordinal()
        {
            Assert.That(" ss ", Contains.Substring("s").Using(StringComparison.Ordinal));
            Assert.That(" SS ", new NotConstraint(Contains.Substring("s").Using(StringComparison.Ordinal)));
        }
    }

    [TestFixture]
    public class SubstringConstraintTestsIgnoringCase : StringConstraintTests
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new SubstringConstraint("hello").IgnoreCase;
            expectedDescription = "String containing \"hello\", ignoring case";
            stringRepresentation = "<substring \"hello\">";
        }

        static object[] SuccessData = new object[] { "Hello", "HellO there", "I said HELLO", "say hello to fred" };
        
        static object[] FailureData = new object[] {
            new TestCaseData( "goodbye", "\"goodbye\"" ), 
            new TestCaseData( "What the hell?", "\"What the hell?\"" ),
            new TestCaseData( string.Empty, "<string.Empty>" ),
            new TestCaseData( null, "null" ) };

        [TestCase]
        public void Using_CurrentCultureIgnoreCase()
        {
            Assert.That(" ss ", Contains.Substring("ß").Using(StringComparison.CurrentCultureIgnoreCase));
            Assert.That(" SS ", Contains.Substring("ß").Using(StringComparison.CurrentCultureIgnoreCase));
        }

        [TestCase]
        public void Using_OrdinalIgnoreCase()
        {
            Assert.That(" ss ", Contains.Substring("s").Using(StringComparison.OrdinalIgnoreCase));
            Assert.That(" SS ", Contains.Substring("s").Using(StringComparison.OrdinalIgnoreCase));
        }
    }

    //[TestFixture]
    //public class EqualIgnoringCaseTest : ConstraintTest
    //{
    //    [SetUp]
    //    public void SetUp()
    //    {
    //        Matcher = new EqualConstraint("Hello World!").IgnoreCase;
    //        Description = "\"Hello World!\", ignoring case";
    //    }

    //    static object[] SuccessData = new object[] { "hello world!", "Hello World!", "HELLO world!" };
            
    //    static object[] FailureData = new object[] { "goodbye", "Hello Friends!", string.Empty, null };


    //    string[] ActualValues = new string[] { "\"goodbye\"", "\"Hello Friends!\"", "<string.Empty>", "null" };
    //}
}
