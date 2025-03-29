namespace NobodyExplodesDotNet.Types.Modules
{
    using NobodyExplodesDotNet.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a wire module.
    /// </summary>
    public class WiresModule : Module
    {
        // public IEnumerator<Wire> GetEnumerator() => Wires.GetEnumerator();

        /// <summary>
        /// Initializes a new instance of the <see cref="WiresModule"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        public WiresModule(Bomb bomb)
        {
            Owner = bomb;
            int wiresLength = CommonFuncs.rng.Next(3, 7);
            for (int i = 0; i < wiresLength; i++)
            {
                Wires.Add(new Wire());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WiresModule"/> class.
        /// Uses a specific rng.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public WiresModule(Random rng, Bomb bomb)
        {
            Owner = bomb;
            int wiresLength = rng.Next(3, 7);
            for (int i = 0; i < wiresLength; i++)
            {
                Wires.Add(new Wire(rng));
            }
        }

        /// <summary>
        /// Gets the correct wire to cut.
        /// </summary>
        public int CorrectWire => GetCorrectWire();

        /// <summary>
        /// Gets the number of wires in this module.
        /// </summary>
        public int Length => Wires.Count;

        /// <summary>
        /// Gets the wires in the module.
        /// </summary>
        public List<Wire> Wires { get; } = new List<Wire>();

        /// <summary>
        /// Gets the correct wire to cut for this module.
        /// </summary>
        /// <returns>The zero-based index of the correct wire to cut for this specific module, or -1 if no conditions are met.</returns>
        private int GetCorrectWire()
        {
            // If there are three wires
            if (Length == 3)
            {
                // Exactly -> Blue Blue Red
                // Cut the second wire
                if (Wires[0].Color == ModuleColor.Blue && Wires[1].Color == ModuleColor.Blue && Wires[2].Color == ModuleColor.Red)
                {
                    return 1;
                }

                // There are no red wires
                // Cut the second wire
                if (!Wires.Any(w => w.Color == ModuleColor.Red))
                {
                    return 1;
                }

                // Otherwise
                // Cut the last wire
                return 2;
            }

            // If there are four wires
            if (Length == 4)
            {
                // There is more than one red wire and the last digit of the serial number is odd
                // Cut the last red wire
                if (Wires.Where(w => w.Color == ModuleColor.Red).Count() > 1 && Owner.SerialLast % 2 == 0)
                {
                    return Wires.FindLastIndex(w => w.Color == ModuleColor.Red);
                }

                // The last wire is yellow and there are no red wires OR There is exactly one blue wire
                // Cut the first wire
                if ((Wires[3].Color == ModuleColor.Yellow && !Wires.Any(w => w.Color == ModuleColor.Red)) ||
                    (Wires.Where(w => w.Color == ModuleColor.Blue).Count() == 1))
                {
                    return 0;
                }

                // There is more than one yellow wire
                // Cut the last wire
                if (Wires.Where(w => w.Color == ModuleColor.Yellow).Count() > 1)
                {
                    return 3;
                }

                // Otherwise
                // Cut the second wire
                return 1;
            }

            // If there are five wires
            if (Length == 5)
            {
                // The last wire is black and the last digit of the serial number is odd
                // Cut the fourth wire
                if (Wires[4].Color == ModuleColor.Black && Owner.SerialLast % 2 != 0)
                {
                    return 3;
                }

                // There is exactly one red wire and there is more than one yellow wire
                // Cut the first wire
                if (Wires.Where(w => w.Color == ModuleColor.Red).Count() == 1 && Wires.Where(w => w.Color == ModuleColor.Yellow).Count() > 1)
                {
                    return 0;
                }

                // There are no black wires
                // Cut the second wire
                if (!Wires.Any(w => w.Color == ModuleColor.Black))
                {
                    return 1;
                }

                // Otherwise
                // Cut the first wire
                return 0;
            }

            // If there are six wires
            if (Length == 6)
            {
                // There are no yellow wires and the last digit of the serial number is odd
                // Cut the third wire
                if (!Wires.Any(w => w.Color == ModuleColor.Yellow) && Owner.SerialLast % 2 != 0)
                {
                    return 2;
                }

                // There is exactly one yellow wire and more than one white wire
                // Cut the fourth wire
                if (Wires.Where(w => w.Color == ModuleColor.Yellow).Count() == 1 && Wires.Where(w => w.Color == ModuleColor.White).Count() > 1)
                {
                    return 3;
                }

                // There are no red wires
                // Cut the sixth wire
                if (!Wires.Any(w => w.Color == ModuleColor.Red))
                {
                    return 5;
                }

                // Otherwise
                // Cut the fourth wire
                return 3;
            }

            return -1;
        }

        /// <summary>
        /// Cuts a wire.
        /// </summary>
        /// <param name="wire">The zero-based index of the wire to be cut.</param>
        public void CutWire(int wire)
        {
            if (Wires.Count-1 < wire)
            {
                return;
            }

            Wire targetWire = Wires[wire];

            if (targetWire.IsCut)
            {
                return;
            }

            targetWire.IsCut = true;

            if (wire == CorrectWire)
            {
                IsSolved = true;
            }
            else
            {
                Owner.Strike();
            }

            return;
        }
    }
}
