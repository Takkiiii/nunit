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
    }

    [TestFixture]
    public class UsingTests : StringConstraintTests
    {
        [TestCase(" ss ", "�", false, StringComparison.CurrentCulture, true)]
        [TestCase(" SS ", "�", false, StringComparison.CurrentCulture, false)]
        [TestCase(" ss ", "s", false, StringComparison.CurrentCulture, true)]
        [TestCase(" SS ", "s", false, StringComparison.CurrentCulture, false)]
        [TestCase(" ss ", "�", false, StringComparison.CurrentCultureIgnoreCase, true)]
        [TestCase(" SS ", "�", false, StringComparison.CurrentCultureIgnoreCase, true)]
        [TestCase(" ss ", "s", false, StringComparison.CurrentCultureIgnoreCase, true)]
        [TestCase(" SS ", "s", false, StringComparison.CurrentCultureIgnoreCase, true)]
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
        [TestCase(" ss ", "�", false, StringComparison.InvariantCulture, true)]
        [TestCase(" SS ", "�", false, StringComparison.InvariantCulture, false)]
        [TestCase(" ss ", "s", false, StringComparison.InvariantCulture, true)]
        [TestCase(" SS ", "s", false, StringComparison.InvariantCulture, false)]
        [TestCase(" ss ", "�", false, StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase(" SS ", "�", false, StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase(" ss ", "s", false, StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase(" SS ", "s", false, StringComparison.InvariantCultureIgnoreCase, true)]
#endif
        [TestCase(" ss ", "�", false, StringComparison.Ordinal, false)]
        [TestCase(" SS ", "�", false, StringComparison.Ordinal, false)]
        [TestCase(" ss ", "s", false, StringComparison.Ordinal, true)]
        [TestCase(" SS ", "s", false, StringComparison.Ordinal, false)]
        [TestCase(" ss ", "�", false, StringComparison.OrdinalIgnoreCase, false)]
        [TestCase(" SS ", "�", false, StringComparison.OrdinalIgnoreCase, false)]
        [TestCase(" ss ", "s", false, StringComparison.OrdinalIgnoreCase, true)]
        [TestCase(" SS ", "s", false, StringComparison.OrdinalIgnoreCase, true)]

        [TestCase(" ss ", "�", false, null, true)]
        [TestCase(" SS ", "�", false, null, false)]
        [TestCase(" ss ", "s", false, null, true)]
        [TestCase(" SS ", "s", false, null, false)]

        [TestCase(" ss ", "�", true, StringComparison.CurrentCulture, true)]
        [TestCase(" SS ", "�", true, StringComparison.CurrentCulture, false)]
        [TestCase(" ss ", "s", true, StringComparison.CurrentCulture, true)]
        [TestCase(" SS ", "s", true, StringComparison.CurrentCulture, false)]
        [TestCase(" ss ", "�", true, StringComparison.CurrentCultureIgnoreCase, true)]
        [TestCase(" SS ", "�", true, StringComparison.CurrentCultureIgnoreCase, true)]
        [TestCase(" ss ", "s", true, StringComparison.CurrentCultureIgnoreCase, true)]
        [TestCase(" SS ", "s", true, StringComparison.CurrentCultureIgnoreCase, true)]
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)           
        [TestCase(" ss ", "�", true, StringComparison.InvariantCulture, true)]
        [TestCase(" SS ", "�", true, StringComparison.InvariantCulture, false)]
        [TestCase(" ss ", "s", true, StringComparison.InvariantCulture, true)]
        [TestCase(" SS ", "s", true, StringComparison.InvariantCulture, false)]
        [TestCase(" ss ", "�", true, StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase(" SS ", "�", true, StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase(" ss ", "s", true, StringComparison.InvariantCultureIgnoreCase, true)]
        [TestCase(" SS ", "s", true, StringComparison.InvariantCultureIgnoreCase, true)]
#endif                         
        [TestCase(" ss ", "�", true, StringComparison.Ordinal, false)]
        [TestCase(" SS ", "�", true, StringComparison.Ordinal, false)]
        [TestCase(" ss ", "s", true, StringComparison.Ordinal, true)]
        [TestCase(" SS ", "s", true, StringComparison.Ordinal, false)]
        [TestCase(" ss ", "�", true, StringComparison.OrdinalIgnoreCase, false)]
        [TestCase(" SS ", "�", true, StringComparison.OrdinalIgnoreCase, false)]
        [TestCase(" ss ", "s", true, StringComparison.OrdinalIgnoreCase, true)]
        [TestCase(" SS ", "s", true, StringComparison.OrdinalIgnoreCase, true)]
                               
        [TestCase(" ss ", "�", true, null, true)]
        [TestCase(" SS ", "�", true, null, true)]
        [TestCase(" ss ", "s", true, null, true)]
        [TestCase(" SS ", "s", true, null, true)]

        public void Using(string actual, string expected, bool ignoreCase, StringComparison? comparison, bool succeeds)
        {
            SubstringConstraint substringConstraint = Contains.Substring(expected);
            // In case StringConstraint.IgnoreCase was set to true 
            if (ignoreCase)
                substringConstraint = substringConstraint.IgnoreCase as SubstringConstraint;

            Constraint constraint = substringConstraint.Using(comparison);
            if (!succeeds)
                constraint = new NotConstraint(constraint);

            Assert.That(actual, constraint);
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
