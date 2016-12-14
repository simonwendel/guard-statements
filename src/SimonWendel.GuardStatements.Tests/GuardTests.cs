/*
 * Guard Statements - Guarding invariants in .NET
 * Copyright (C) 2016  Simon Wendel
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace SimonWendel.GuardStatements.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    internal class GuardTests
    {
        [Test]
        public void EnsureNotNull_GivenNonNullObject_DoesNothing()
        {
            var nonNullObject = new object();

            Guard.EnsureNotNull(nonNullObject);
        }

        [Test]
        public void EnsureNotNull_GivenNonNullObjectAndParameterName_DoesNothing()
        {
            var nonNullObject = new object();

            Guard.EnsureNotNull(nonNullObject, nameof(nonNullObject));
        }

        [Test]
        public void EnsureNotNull_GivenNullObject_ThrowsExeption()
        {
            object nullObject = null;
            TestDelegate guardStatement =
                () => Guard.EnsureNotNull(nullObject);

            Assert.That(guardStatement, Throws.ArgumentNullException);
        }

        [Test]
        public void EnsureNotNull_GivenNullObjectAndParameterName_ThrowsExeption()
        {
            object nullObject = null;
            TestDelegate guardStatement =
                () => Guard.EnsureNotNull(nullObject, nameof(nullObject));

            Assert.That(guardStatement, Throws.ArgumentNullException);
        }

        [Test]
        public void EnsureNonempty_GivenNullString_ThrowsException()
        {
            string nullString = null;
            TestDelegate guardStatement =
                () => Guard.EnsureNonempty(nullString, nameof(nullString));

            Assert.That(guardStatement, Throws.ArgumentNullException);
        }

        [Test]
        public void EnsureNonempty_GivenEmptyString_ThrowsException()
        {
            string emptyString = string.Empty;
            TestDelegate guardStatement =
                () => Guard.EnsureNonempty(emptyString, nameof(emptyString));

            Assert.That(guardStatement, Throws.ArgumentException);
        }

        [Test]
        public void EnsureNonempty_GivenNonemptyString_DoesNothing()
        {
            string nonEmptyString = "not empty";

            Guard.EnsureNonempty(nonEmptyString, nameof(nonEmptyString));
        }

        [Test]
        public void EnsureNonempty_GivenNullGuid_ThrowsException()
        {
            Guid? nullGuid = null;
            TestDelegate guardStatement =
                () => Guard.EnsureNonempty(nullGuid, nameof(nullGuid));

            Assert.That(guardStatement, Throws.ArgumentNullException);
        }

        [Test]
        public void EnsureNonempty_GivenEmptyGuid_ThrowsException()
        {
            Guid emptyGuid = Guid.Empty;
            TestDelegate guardStatement =
                () => Guard.EnsureNonempty(emptyGuid, nameof(emptyGuid));

            Assert.That(guardStatement, Throws.ArgumentException);
        }

        [Test]
        public void EnsureNonempty_GivenNonemptyGuid_DoesNothing()
        {
            Guid nonEmptyGuid = Guid.NewGuid();

            Guard.EnsureNonempty(nonEmptyGuid, nameof(nonEmptyGuid));
        }

        [Test]
        public void EnsureThat_GivenNullPredicate_ThrowsException()
        {
            TestDelegate guardStatement =
                () => Guard.EnsureThat(null);

            Assert.That(guardStatement, Throws.ArgumentNullException);
        }

        [Test]
        public void EnsureThat_GivenFalsePredicate_ThrowsException()
        {
            TestDelegate guardStatement =
                () => Guard.EnsureThat(() => false);

            Assert.That(guardStatement, Throws.ArgumentException);
        }

        [Test]
        public void EnsureThat_GivenTruePredicate_DoesNothing()
        {
            Guard.EnsureThat(() => true);
        }

        [Test]
        public void EnsureThat_GivenFalse_ThrowsException()
        {
            TestDelegate guardStatement =
                () => Guard.EnsureThat(false);

            Assert.That(guardStatement, Throws.ArgumentException);
        }

        [Test]
        public void EnsureThat_GivenTrue_DoesNothing()
        {
            Guard.EnsureThat(true);
        }
    }
}
