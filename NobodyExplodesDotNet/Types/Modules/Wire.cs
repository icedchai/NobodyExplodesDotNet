using NobodyExplodesDotNet.Enums;
using System;

namespace NobodyExplodesDotNet.Types.Modules
{
    /// <summary>
    /// Represents a wire.
    /// </summary>
    public class Wire
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wire"/> class.
        /// </summary>
        public Wire()
        {
            IsCut = false;
            Color = CommonFuncs.RandomEnumValue<ModuleColor>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Wire"/> class.
        /// </summary>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public Wire(Random rng)
        {
            IsCut = false;
            Color = CommonFuncs.RandomEnumValue<ModuleColor>(rng);
        }

        /// <summary>
        /// Gets the color of the wire.
        /// </summary>
        public ModuleColor Color { get; }

        /// <summary>
        /// Gets a value indicating whether the wire is cut.
        /// </summary>
        public bool IsCut { get; internal set; } = false;

        public override string ToString()
        {
            return $"Color : {Color}, IsCut : {IsCut}";
        }
    }
}
