using NobodyExplodesDotNet.Extensions;
using NobodyExplodesDotNet.Types.Widgets;
using System.Linq;
using System.Reflection;
using System;

namespace NobodyExplodesDotNet.Types
{
    public abstract class Widget
    {
        /// <summary>
        /// Gets the bomb this module is on, or null.
        /// </summary>
        public Bomb Owner { get; private set; } = null;

        public Widget(Bomb bomb)
        {
            Owner = bomb;
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

        private static Type[] widgetTypes = new Type[] { typeof(BatteryWidget), typeof(IndicatorWidget) };

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
