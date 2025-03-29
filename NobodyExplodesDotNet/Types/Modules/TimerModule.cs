using System;
using System.Runtime.CompilerServices;

namespace NobodyExplodesDotNet.Types.Modules
{
    /// <summary>
    /// Represents the timer on the bomb.
    /// </summary>
    public class TimerModule : Module
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerModule"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        public TimerModule(Bomb bomb)
        {
            IsSolved = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerModule"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public TimerModule(Random rng, Bomb bomb)
        {
            Owner = bomb;
            IsSolved = true;
        }
    }
}
