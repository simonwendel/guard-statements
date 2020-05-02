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

namespace GuardStatements
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Convenience class for enforcing invariants and responding by throwing an adequate exception.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Will check for a <c>null</c> parameter and throwing <see cref="ArgumentNullException"/> if so.
        /// </summary>
        /// <param name="parameter">The object to check for null condition.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        [DebuggerHidden]
        public static void AgainstNull([ValidatedNotNull] object parameter)
        {
            AgainstNull(parameter, parameterName: null);
        }

        /// <summary>
        /// Will check for a <c>null</c> parameter and throwing <see cref="ArgumentNullException"/> if so.
        /// </summary>
        /// <param name="parameter">The object to check for null condition.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        [DebuggerHidden]
        public static void AgainstNull([ValidatedNotNull] object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Will check a string for <c>null</c> or <c>string.Empty</c> and responding by throwing an
        /// adequate exception.
        /// </summary>
        /// <param name="parameter">Parameter to check for <c>null</c> or <c>string.Empty</c>.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">When <paramref name="parameter"/> is <c>string.Empty</c>.</exception>
        [DebuggerHidden]
        public static void AgainstEmpty([ValidatedNotNull] string parameter)
        {
            AgainstEmpty(parameter, parameterName: null);
        }

        /// <summary>
        /// Will check a string for <c>null</c> or <c>string.Empty</c> and responding by throwing an
        /// adequate exception.
        /// </summary>
        /// <param name="parameter">Parameter to check for <c>null</c> or <c>string.Empty</c>.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">When <paramref name="parameter"/> is <c>string.Empty</c>.</exception>
        [DebuggerHidden]
        public static void AgainstEmpty([ValidatedNotNull] string parameter, string parameterName)
        {
            AgainstNull(parameter, parameterName);

            if (string.IsNullOrEmpty(parameter))
            {
                throw new ArgumentException(message: null, paramName: parameterName);
            }
        }

        /// <summary>
        /// Will check a *nullable* <see cref="System.Guid"/> for <c>null</c> or <see cref="Guid.Empty"/> and responding by throwing an
        /// adequate exception.
        /// </summary>
        /// <param name="parameter">Parameter to check for <c>null</c> or <see cref="Guid.Empty"/>.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">When <paramref name="parameter"/> is <see cref="Guid.Empty"/>.</exception>
        [DebuggerHidden]
        public static void AgainstEmpty([ValidatedNotNull] Guid? parameter)
        {
            AgainstEmpty(parameter, parameterName: null);
        }

        /// <summary>
        /// Will check a *nullable* <see cref="System.Guid"/> for <c>null</c> or <see cref="Guid.Empty"/> and responding by throwing an
        /// adequate exception.
        /// </summary>
        /// <param name="parameter">Parameter to check for <c>null</c> or <see cref="Guid.Empty"/>.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">When <paramref name="parameter"/> is <see cref="Guid.Empty"/>.</exception>
        [DebuggerHidden]
        public static void AgainstEmpty([ValidatedNotNull] Guid? parameter, string parameterName)
        {
            AgainstNull(parameter, parameterName);

            if (parameter.Equals(Guid.Empty))
            {
                throw new ArgumentException(message: null, paramName: parameterName);
            }
        }

        /// <summary>
        /// Will check a predicate return value to make sure it is <c>false</c>, throwing an exception if not.
        /// </summary>
        /// <param name="predicate">Predicate to invoke and examine return value.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="predicate"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">When <paramref name="predicate"/> returns <c>true</c>.</exception>
        [DebuggerHidden]
        public static void Against([ValidatedNotNull] Func<bool> predicate)
        {
            Against(predicate, parameterName: null);
        }

        /// <summary>
        /// Will check a predicate return value to make sure it is <c>false</c>, throwing an exception if not.
        /// </summary>
        /// <param name="predicate">Predicate to invoke and examine return value.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="predicate"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">When <paramref name="predicate"/> returns <c>true</c>.</exception>
        [DebuggerHidden]
        public static void Against([ValidatedNotNull] Func<bool> predicate, string parameterName)
        {
            AgainstNull(predicate, nameof(predicate));
            Against(predicate(), parameterName);
        }

        /// <summary>
        /// Will check a condition to make sure it is <c>false</c>, throwing an exception if not.
        /// </summary>
        /// <param name="condition">Condition value to check.</param>
        /// <exception cref="ArgumentException">When <paramref name="condition"/> is <c>true</c>.</exception>
        [DebuggerHidden]
        public static void Against(bool condition)
        {
            Against(condition, parameterName: null);
        }

        /// <summary>
        /// Will check a condition to make sure it is <c>false</c>, throwing an exception if not.
        /// </summary>
        /// <param name="condition">Condition value to check.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentException">When <paramref name="condition"/> is <c>true</c>.</exception>
        [DebuggerHidden]
        public static void Against(bool condition, string parameterName)
        {
            if (condition)
            {
                throw new ArgumentException(message: null, paramName: parameterName);
            }
        }
    }
}
