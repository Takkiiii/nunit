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
using System.Globalization;

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// SubstringConstraint can test whether a string contains
    /// the expected substring.
    /// </summary>
    public class SubstringConstraint : StringConstraint
    {
        private StringComparison? comparisonType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstringConstraint"/> class.
        /// </summary>
        /// <param name="expected">The expected.</param>
        public SubstringConstraint(string expected) : base(expected) 
        {
            descriptionText = "String containing";
        }

        /// <summary>
        /// Modify the constraint to ignore case in matching.
        /// </summary>
        public override StringConstraint IgnoreCase
        {
            get { caseInsensitive = true; comparisonType = null; return this; }
        }

        /// <summary>
        /// Test whether the constraint is satisfied by a given value
        /// </summary>
        /// <param name="actual">The value to be tested</param>
        /// <returns>True for success, false for failure</returns>
        protected override bool Matches(string actual)
        {
            if (actual == null) return false;

            var actualComparison = comparisonType ?? (caseInsensitive ?
                StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);

            return actual.IndexOf(expected, actualComparison) >= 0;
        }

        /// <summary>
        /// Modify the constraint to the specified comparison.
        /// </summary>
        public SubstringConstraint Using(StringComparison comparisonType)
        {
            this.comparisonType = comparisonType;
            return this;
        }
    }
}