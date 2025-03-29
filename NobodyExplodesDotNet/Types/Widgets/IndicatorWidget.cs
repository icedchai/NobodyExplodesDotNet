using NobodyExplodesDotNet.Enums;
using System;
using System.Linq;

namespace NobodyExplodesDotNet.Types.Widgets
{
    /// <summary>
    /// Represents a lit indicator.
    /// </summary>
    public class IndicatorWidget : Widget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndicatorWidget"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        public IndicatorWidget(Bomb bomb)
        {
            Owner = bomb;
            Label = CommonFuncs.RandomEnumValue<IndicatorLabel>();
            IsLit = CommonFuncs.rng.Next(2) == 0;
            while (Owner.IndicatorWidgets.Any(i => i.Label == Label))
            {
                Label = CommonFuncs.RandomEnumValue<IndicatorLabel>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndicatorWidget"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public IndicatorWidget(Random rng, Bomb bomb)
        {
            Owner = bomb;
            Label = CommonFuncs.RandomEnumValue<IndicatorLabel>(rng);
            IsLit = rng.Next(2) == 0;
            while (Owner.IndicatorWidgets.Any(i => i.Label == Label))
            {
                Label = CommonFuncs.RandomEnumValue<IndicatorLabel>(rng);
            }
        }

        /// <summary>
        /// Gets the <see cref="IndicatorLabel"/> on this widget.
        /// </summary>
        public IndicatorLabel Label { get; }

        /// <summary>
        /// Gets a value indicating whether the widget is lit.
        /// </summary>
        public bool IsLit { get; }
    }
}
