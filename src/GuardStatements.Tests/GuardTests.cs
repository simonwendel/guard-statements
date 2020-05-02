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
    using FluentAssertions;
    using Xunit;

    public class GuardTests
    {
        [Fact]
        public void EnsureNotNull_GivenNonNullObject_DoesNothing()
        {
            var nonNullObject = new object();
            Guard.EnsureNotNull(nonNullObject);
        }

        [Fact]
        public void EnsureNotNull_GivenNonNullObjectAndParameterName_DoesNothing()
        {
            var nonNullObject = new object();
            Guard.EnsureNotNull(nonNullObject, nameof(nonNullObject));
        }

        [Fact]
        public void EnsureNotNull_GivenNullObject_ThrowsExeption()
        {
            Action guarding = () => Guard.EnsureNotNull(null);
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void EnsureNotNull_GivenNullObjectAndParameterName_ThrowsExeption()
        {
            Action guarding = () => Guard.EnsureNotNull(null, "nullObject");
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void EnsureNonempty_GivenNullString_ThrowsException()
        {
            Action guarding = () => Guard.EnsureNonempty((string)null, "nullString");
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void EnsureNonempty_GivenEmptyString_ThrowsException()
        {
            Action guarding = () => Guard.EnsureNonempty(string.Empty, "emptyString");
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void EnsureNonempty_GivenNonemptyString_DoesNothing()
        {
            Guard.EnsureNonempty("not empty", "nonEmptyString");
        }

        [Fact]
        public void EnsureNonempty_GivenNullGuid_ThrowsException()
        {
            Action guarding = () => Guard.EnsureNonempty((Guid?)null, "nullGuid");
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void EnsureNonempty_GivenEmptyGuid_ThrowsException()
        {
            Action guarding = () => Guard.EnsureNonempty(Guid.Empty, "emptyGuid");
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void EnsureNonempty_GivenNonemptyGuid_DoesNothing()
        {
            Guard.EnsureNonempty(Guid.NewGuid(), "nonEmptyGuid");
        }

        [Fact]
        public void EnsureThat_GivenNullPredicate_ThrowsException()
        {
            Action guarding = () => Guard.EnsureThat(null);
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void EnsureThat_GivenFalsePredicate_ThrowsException()
        {
            Action guarding = () => Guard.EnsureThat(() => false);
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void EnsureThat_GivenTruePredicate_DoesNothing()
        {
            Guard.EnsureThat(() => true);
        }

        [Fact]
        public void EnsureThat_GivenFalse_ThrowsException()
        {
            Action guarding = () => Guard.EnsureThat(false);
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void EnsureThat_GivenTrue_DoesNothing()
        {
            Guard.EnsureThat(true);
        }
    }
}
