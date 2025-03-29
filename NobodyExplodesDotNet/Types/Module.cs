using System;

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
        public Bomb Owner { get; internal set; } = null;
    }
}
