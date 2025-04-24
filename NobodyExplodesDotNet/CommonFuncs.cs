namespace NobodyExplodesDotNet
{
    using NobodyExplodesDotNet.Types;
    using NobodyExplodesDotNet.Types.Modules;
    using NobodyExplodesDotNet.Types.Widgets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Module = Types.Module;

    /// <summary>
    /// Common functions and extensions used in this app.
    /// </summary>
    public static class CommonFuncs
    {
        public static Random SharedRng = new Random();

        /// <summary>
        /// Gets a random member of an enum.
        /// </summary>
        /// <typeparam name="T">The enum to use.</typeparam>
        /// <returns>Returns a random enum.</returns>
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(SharedRng.Next(v.Length));
        }

        /// <summary>
        /// Gets a random member of an enum using a specific rng.
        /// </summary>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        /// <typeparam name="T">The enum to use.</typeparam>
        /// <returns>Returns a random enum.</returns>
        public static T RandomEnumValue<T>(Random rng)
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(rng.Next(v.Length));
        }

        /// <summary>
        /// Gets a timer display from the <paramref name="bomb"/>.
        /// </summary>
        /// <param name="bomb">The bomb to use as reference.</param>
        /// <returns>A string representing the time left on the bomb with either the hours:minutes, minutes:seconds format, or the seconds:centiseconds format depending on time left.</returns>
        public static string GetTimerDisplay(this Bomb bomb)
        {
            return GetTimerDisplay(bomb.Time);
        }

        /// <summary>
        /// Gets a timer display from the Float.
        /// </summary>
        /// <param name="seconds">Float representing the number of seconds.</param>
        /// <returns>A string representing the given time with either the hours:minutes, minutes:seconds format, or the seconds:centiseconds format depending on time left.</returns>
        public static string GetTimerDisplay(float seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return $"{(timeSpan.Hours == 0 ? (timeSpan.Minutes == 0 ? timeSpan.Seconds : timeSpan.Minutes) : timeSpan.Hours):D2}:" +
                $"{(timeSpan.Hours == 0 ? (timeSpan.Minutes == 0 ? timeSpan.Milliseconds / 10 : timeSpan.Seconds) : timeSpan.Minutes):D2}";
        }
    }
}
