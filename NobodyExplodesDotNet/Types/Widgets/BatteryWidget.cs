namespace NobodyExplodesDotNet.Types.Widgets
{
    using System;
    using NobodyExplodesDotNet.Enums;

    /// <summary>
    /// Represents a battery widget.
    /// </summary>
    public class BatteryWidget : Widget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatteryWidget"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public BatteryWidget(Bomb bomb)
        {
            Owner = bomb;
            Battery = CommonFuncs.RandomEnumValue<BatteryType>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatteryWidget"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public BatteryWidget(Random rng, Bomb bomb)
        {
            Owner = bomb;
            Battery = CommonFuncs.RandomEnumValue<BatteryType>(rng);
        }

        /// <summary>
        /// Gets the type of battery this is.
        /// </summary>
        public BatteryType Battery { get; internal set; }
    }
}
