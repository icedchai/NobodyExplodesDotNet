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
        public static Random rng = new Random();

        /// <summary>
        /// Gets a random member of an enum.
        /// </summary>
        /// <typeparam name="T">The enum to use.</typeparam>
        /// <returns>Returns a random enum.</returns>
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(rng.Next(v.Length));
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
        /// Gets a random element from the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="values">This.</param>
        /// <returns>A random element from the <see cref="IEnumerable{T}"/>.</returns>
        public static T GetRandomElement<T>(this IEnumerable<T> values)
        {
            return values.ElementAt(rng.Next(values.Count()));
        }

        /// <summary>
        /// Gets a random element from the <see cref="IEnumerable{T}"/> using a specific rng.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        /// <param name="values">This.</param>
        /// <returns>A random element from the <see cref="IEnumerable{T}"/>.</returns>
        public static T GetRandomElement<T>(this IEnumerable<T> values, Random rng)
        {
            return values.ElementAt(rng.Next(values.Count()));
        }

        public static void Init()
        {
            RegisterModules();
            RegisterWidgets();
        }

        /// <summary>
        /// Registers all classes that derive from <see cref="Module"/> in the current assembly.
        /// </summary>
        public static void RegisterModules()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes().Where(T => T.IsSubclassOf(typeof(Module))))
            {
                if (!moduleTypes.Contains(type))
                {
                    moduleTypes.Append(type);
                }
            }
        }

        /// <summary>
        /// Registers all classes that derive from <see cref="Widget"/> in the current assembly.
        /// </summary>
        public static void RegisterWidgets()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes().Where(T => T.IsSubclassOf(typeof(Widget))))
            {
                if (!widgetTypes.Contains(type))
                {
                    widgetTypes.Append(type);
                }
            }
        }

        private static Type[] moduleTypes = new Type[] { typeof(WiresModule), typeof(ButtonModule), typeof(KeypadModule) };

        private static Type[] widgetTypes = new Type[] { typeof(BatteryWidget), typeof(IndicatorWidget) };

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

        /// <summary>
        /// Gets a new random module.
        /// </summary>
        /// <returns>A new module of a random type.</returns>
        public static Module GetNewModule(Bomb bomb)
        {
            return (Module)Activator.CreateInstance(GetRandomElement(moduleTypes), new object[] { bomb });
        }

        /// <summary>
        /// Gets a new random module.
        /// </summary>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        /// <returns>A new module of a random type.</returns>
        public static Module GetNewModule(Random rng, Bomb bomb)
        {
            if (rng is null)
            {
                throw new ArgumentNullException(nameof(rng));
            }

            if (bomb is null)
            {
                throw new ArgumentNullException(nameof(bomb));
            }

            return (Module)Activator.CreateInstance(GetRandomElement(moduleTypes, rng), new object[] { rng, bomb });
        }

        /// <summary>
        /// Gets a new widget.
        /// </summary>
        /// <returns>A new widget of a random type.</returns>
        public static Widget GetNewWidget(Bomb bomb)
        {
            return (Widget)Activator.CreateInstance(widgetTypes.GetRandomElement(), new object[] { bomb });
        }

        /// <summary>
        /// Gets a new widget.
        /// </summary>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        /// <returns>A new widget of a random type.</returns>
        public static Widget GetNewWidget(Random rng, Bomb bomb)
        {
            if (rng is null)
            {
                throw new ArgumentNullException(nameof(rng));
            }

            if (bomb is null)
            {
                throw new ArgumentNullException(nameof(bomb));
            }

            return (Widget)Activator.CreateInstance(widgetTypes.GetRandomElement(rng));
        }
    }
}
