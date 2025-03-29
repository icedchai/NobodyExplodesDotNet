namespace NobodyExplodesDotNet.Types.Modules
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using NobodyExplodesDotNet.Enums;

    /// <summary>
    /// Represents a button module.
    /// </summary>
    public class ButtonModule : Module
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonModule"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        public ButtonModule(Bomb bomb)
        {
            Owner = bomb;
            Color = CommonFuncs.RandomEnumValue<ModuleColor>();
            StripColor = CommonFuncs.RandomEnumValue<ModuleColor>();
            Label = CommonFuncs.RandomEnumValue<ButtonLabel>();
            if (StripColor == ModuleColor.Black)
            {
                StripColor = ModuleColor.White;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonModule"/> class.
        /// Uses a specific RNG.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public ButtonModule(Random rng, Bomb bomb)
        {
            Owner = bomb;
            Color = CommonFuncs.RandomEnumValue<ModuleColor>(rng);
            StripColor = CommonFuncs.RandomEnumValue<ModuleColor>(rng);
            Label = CommonFuncs.RandomEnumValue<ButtonLabel>(rng);
            if (StripColor == ModuleColor.Black)
            {
                StripColor = ModuleColor.White;
            }
        }

        /// <summary>
        /// Gets the color of the button.
        /// </summary>
        public ModuleColor Color { get; }

        /// <summary>
        /// Gets the label on the button.
        /// </summary>
        public ButtonLabel Label { get; }

        /// <summary>
        /// Gets the color this module's strip flashes when being held down.
        /// </summary>
        public ModuleColor StripColor { get; }

        /// <summary>
        /// Gets a value indicating whether or not the button is pressed.
        /// </summary>
        public bool IsPressed { get; internal set; }

        /// <summary>
        /// Gets the time the button was pressed down.
        /// </summary>
        public DateTime PressedDown { get; internal set; }

        public bool ShouldLightStrip
        {
            get
            {
                return DateTime.Now.Subtract(PressedDown).TotalSeconds > 1 && IsPressed;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this module is solved by holding the button.
        /// </summary>
        public bool ShouldHold => GetShouldHold();

        /// <summary>
        /// Gets a value indicating whether this module is solved by tapping the button.
        /// </summary>
        public bool ShouldTap => !GetShouldHold();

        /// <summary>
        /// Presses the button.
        /// </summary>
        public void PressDown()
        {
            if (IsPressed)
            {
                return;
            }

            PressedDown = DateTime.Now;
            IsPressed = true;
        }

        /// <summary>
        /// Releases the held button.
        /// </summary>
        public void Release()
        {
            if (!IsPressed)
            {
                return;
            }

            IsPressed = false;
            if (DateTime.Now.Subtract(PressedDown).TotalSeconds < 1)
            {
                if (ShouldTap)
                {
                    IsSolved = true;
                    return;
                }
                else
                {
                    Owner.Strike();
                    return;
                }
            }

            string timer = CommonFuncs.GetTimerDisplay(Owner);
            switch (StripColor)
            {
                case ModuleColor.Blue:
                    if (timer.Contains('4'))
                    {
                        IsSolved = true;
                    }
                    else
                    {
                        Owner.Strike();
                    }

                    break;
                case ModuleColor.Yellow:
                    if (timer.Contains('5'))
                    {
                        IsSolved = true;
                    }
                    else
                    {
                        Owner.Strike();
                    }

                    break;
                default:
                    if (timer.Contains('1'))
                    {
                        IsSolved = true;
                    }
                    else
                    {
                        Owner.Strike();
                    }

                    break;

            }
        }

        /// <summary>
        /// Get whether or not this button module is solved by holding the button.
        /// </summary>
        /// <returns>Whether this button module is solved by pressing or holding the button.</returns>
        private bool GetShouldHold()
        {
            // Button is red and label says HOLD
            // Press it and immediately release.
            if (Color == ModuleColor.Red && Label == ButtonLabel.HOLD)
            {
                return false;
            }

            // Bomb has 2+ bombs and label says DETONATE
            // Press it and immediately release
            if (Owner.Batteries > 1 && Label == ButtonLabel.DETONATE)
            {
                return false;
            }

            // Button is blue and says ABORT
            // Hold it and refer to releasing a held button
            if (Color == ModuleColor.Blue && Label == ButtonLabel.ABORT)
            {
                return true;
            }

            // Button is white and bomb has lit indicator reading CAR
            // Hold it and refer to releasing a held button
            if (Color == ModuleColor.White && Owner.LitIndicatorWidgets.Any(w => w.Label == IndicatorLabel.CAR))
            {
                return true;
            }

            // Bomb has 3+ batteries and a lit indicator reading FRK
            // Press it and immediately release
            if (Owner.Batteries > 2 && Owner.LitIndicatorWidgets.Any(w => w.Label == IndicatorLabel.FRK))
            {
                return false;
            }

            return true;
        }
    }
}
