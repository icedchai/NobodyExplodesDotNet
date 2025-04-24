using NobodyExplodesDotNet.Extensions;
using NobodyExplodesDotNet.Types.Modules;
using System;
using System.Linq;
using System.Reflection;

namespace NobodyExplodesDotNet.Types
{
    /// <summary>
    /// Base class for all modules that can be encountered on a bomb.
    /// </summary>
    public abstract class Module
    {
        /// <summary>
        /// Gets or sets a value indicating whether the module is solved.
        /// </summary>
        public bool IsSolved { get; set; } = false;

        /// <summary>
        /// Gets the bomb this module is on, or null.
        /// </summary>
        public Bomb Owner { get; private set; } = null;

        private static Type[] moduleTypes = new Type[] { typeof(WiresModule), typeof(ButtonModule), typeof(KeypadModule) };

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
        /// Gets a new random module.
        /// </summary>
        /// <returns>A new module of a random type.</returns>
        public static Module GetNewModule(Bomb bomb)
        {
            return (Module)Activator.CreateInstance(moduleTypes.GetRandomElement(), new object[] { bomb });
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

            return (Module)Activator.CreateInstance(moduleTypes.GetRandomElement(rng), new object[] { rng, bomb });
        }
    }
}
