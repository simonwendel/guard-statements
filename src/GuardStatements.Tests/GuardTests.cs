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

namespace GuardStatements.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class GuardTests
    {
        [Fact]
        public void AgainstNull_GivenNonNullObject_DoesNothing()
        {
            var nonNullObject = new object();
            Guard.AgainstNull(nonNullObject);
        }

        [Fact]
        public void AgainstNull_GivenNonNullObjectAndParameterName_DoesNothing()
        {
            var nonNullObject = new object();
            Guard.AgainstNull(nonNullObject, nameof(nonNullObject));
        }

        [Fact]
        public void AgainstNull_GivenNullObject_ThrowsExeption()
        {
            Action guarding = () => Guard.AgainstNull(null);
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void AgainstNull_GivenNullObjectAndParameterName_ThrowsExeption()
        {
            Action guarding = () => Guard.AgainstNull(null, "nullObject");
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void AgainstEmpty_GivenNullString_ThrowsException()
        {
            Action guarding = () => Guard.AgainstEmpty((string)null, "nullString");
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void AgainstEmpty_GivenEmptyString_ThrowsException()
        {
            Action guarding = () => Guard.AgainstEmpty(string.Empty, "emptyString");
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void AgainstEmpty_GivenNonemptyString_DoesNothing()
        {
            Guard.AgainstEmpty("not empty", "nonEmptyString");
        }

        [Fact]
        public void AgainstEmpty_GivenNullGuid_ThrowsException()
        {
            Action guarding = () => Guard.AgainstEmpty((Guid?)null, "nullGuid");
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void AgainstEmpty_GivenEmptyGuid_ThrowsException()
        {
            Action guarding = () => Guard.AgainstEmpty(Guid.Empty, "emptyGuid");
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void AgainstEmpty_GivenNonemptyGuid_DoesNothing()
        {
            Guard.AgainstEmpty(Guid.NewGuid(), "nonEmptyGuid");
        }

        [Fact]
        public void Against_GivenNullPredicate_ThrowsException()
        {
            Action guarding = () => Guard.Against(null);
            guarding.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Against_GivenTruePredicate_ThrowsException()
        {
            Action guarding = () => Guard.Against(() => true);
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Against_GivenFalsePredicate_DoesNothing()
        {
            Guard.Against(() => false);
        }

        [Fact]
        public void Against_GivenTrue_ThrowsException()
        {
            Action guarding = () => Guard.Against(true);
            guarding.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Against_GivenFalse_DoesNothing()
        {
            Guard.Against(false);
        }
    }
}
