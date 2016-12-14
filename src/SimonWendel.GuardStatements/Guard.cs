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

namespace SimonWendel.GuardStatements
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
        public static void EnsureNotNull([ValidatedNotNull] object parameter)
        {
            EnsureNotNull(parameter, parameterName: null);
        }

        /// <summary>
        /// Will check for a <c>null</c> parameter and throwing <see cref="ArgumentNullException"/> if so.
        /// </summary>
        /// <param name="parameter">The object to check for null condition.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="parameter"/> is <c>null</c>.</exception>
        [DebuggerHidden]
        public static void EnsureNotNull([ValidatedNotNull] object parameter, string parameterName)
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
        public static void EnsureNonempty([ValidatedNotNull] string parameter)
        {
            EnsureNonempty(parameter, parameterName: null);
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
        public static void EnsureNonempty([ValidatedNotNull] string parameter, string parameterName)
        {
            EnsureNotNull(parameter, parameterName);

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
        public static void EnsureNonempty([ValidatedNotNull] Guid? parameter)
        {
            EnsureNonempty(parameter, parameterName: null);
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
        public static void EnsureNonempty([ValidatedNotNull] Guid? parameter, string parameterName)
        {
            EnsureNotNull(parameter, parameterName);

            if (parameter.Equals(Guid.Empty))
            {
                throw new ArgumentException(message: null, paramName: parameterName);
            }
        }

        /// <summary>
        /// Will check a condition to make sure it is <c>true</c>, throwing an exception if not.
        /// </summary>
        /// <param name="condition">Condition value to check.</param>
        /// <exception cref="ArgumentException">When <paramref name="condition"/> is <c>false</c>.</exception>
        [DebuggerHidden]
        public static void EnsureThat(bool condition)
        {
            EnsureThat(condition, parameterName: null);
        }

        /// <summary>
        /// Will check a condition to make sure it is <c>true</c>, throwing an exception if not.
        /// </summary>
        /// <param name="condition">Condition value to check.</param>
        /// <param name="parameterName">Name of the parameter to include in an exception, if thrown.</param>
        /// <exception cref="ArgumentException">When <paramref name="condition"/> is <c>false</c>.</exception>
        [DebuggerHidden]
        public static void EnsureThat(bool condition, string parameterName)
        {
            if (condition == false)
            {
                throw new ArgumentException(message: null, paramName: parameterName);
            }
        }
    }
}
