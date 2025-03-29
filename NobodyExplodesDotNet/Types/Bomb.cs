namespace NobodyExplodesDotNet.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NobodyExplodesDotNet.Types.Modules;
    using NobodyExplodesDotNet.Types.Widgets;

    /// <summary>
    /// Represents a bomb and all its components.
    /// </summary>
    public class Bomb
    {
        private static List<char> serialLetters = new List<char>
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Z',
        };

        private static List<char> serialNumbers = new List<char>
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
        };

        private static List<char> vowels = new List<char>
        {
            'A',
            'E',
            'I',
            'U',
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Bomb"/> class.
        /// </summary>
        public Bomb()
        {
            Serial = GetSerial();
            Modules.Add(new TimerModule(this));
            int modules = 4;
            for (int i = 0; i < modules; i++)
            {
                Modules.Add(CommonFuncs.GetNewModule(this));
            }

            int widgets = 5;
            for (int i = 0; i < widgets; i++)
            {
                Widgets.Add(CommonFuncs.GetNewWidget(this));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bomb"/> class.
        /// </summary>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public Bomb(Random rng)
        {
            Serial = GetSerial(rng);
            Modules.Add(new TimerModule(this));
            int modules = 5;
            for (int i = 0; i < modules; i++)
            {
                Modules.Add(CommonFuncs.GetNewModule(this));
            }

            int widgets = 5;
            for (int i = 0; i < widgets; i++)
            {
                Widgets.Add(CommonFuncs.GetNewWidget(rng, this));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bomb"/> class.
        /// </summary>
        /// <param name="seed">The seed of the <see cref="Random"/> to use.</param>
        public Bomb(int seed) => new Bomb(new Random(seed));

        /// <summary>
        /// Gets a randomly generated serial number.
        /// </summary>
        /// <returns>A six character long string with at least one letter, one number, and a number at the end.</returns>
        public static string GetSerial()
        {
            List<char> chars = serialLetters.Concat(serialNumbers).ToList();
            string serial = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                serial += chars.GetRandomElement();
            }

            if (!serial.Any(c => serialLetters.Contains(c)))
            {
                serial.Insert(CommonFuncs.rng.Next(5), serialLetters.GetRandomElement().ToString());
            }
            else
            {
                serial += chars.GetRandomElement();
            }

            serial += serialNumbers.GetRandomElement();
            return serial;
        }

        /// <summary>
        /// Gets a randomly generated serial number using a specific rng.
        /// </summary>
        /// <returns>A six character long string with at least one letter, one number, and a number at the end.</returns>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public static string GetSerial(Random rng)
        {
            List<char> chars = serialLetters.Concat(serialNumbers).ToList();
            string serial = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                serial += chars.GetRandomElement(rng);
            }

            if (!serial.Any(c => serialLetters.Contains(c)))
            {
                serial.Insert(rng.Next(5), serialLetters.GetRandomElement(rng).ToString());
            }
            else
            {
                serial += chars.GetRandomElement(rng);
            }

            serial += serialNumbers.GetRandomElement(rng);
            return serial;
        }

        /// <summary>
        /// Gets a value indicating whether the conditions for the bomb to explode have been met.
        /// </summary>
        public bool IsExploded => Time < 0 || Strikes >= StrikeLimit;

        public bool IsSolved => !Modules.Any(m => !m.IsSolved);

        /// <summary>
        /// Gets the widgets on the bomb.
        /// </summary>
        public List<Widget> Widgets { get; } = new ();

        /// <summary>
        /// Gets the number of batteries currently on the bomb.
        /// </summary>
        public int Batteries
        {
            get
            {
                int ret = 0;
                foreach (Widget widget in Widgets)
                {
                    if (widget is BatteryWidget batteryWidget)
                    {
                        ret += (int)batteryWidget.Battery;
                    }
                }

                return ret;
            }
        }

        /// <summary>
        /// Gets all indicator widgets on the bomb.
        /// </summary>
        public List<IndicatorWidget> IndicatorWidgets => Widgets.OfType<IndicatorWidget>().ToList();

        /// <summary>
        /// Gets all lit indicator widgets on the bomb.
        /// </summary>
        public List<IndicatorWidget> LitIndicatorWidgets => IndicatorWidgets.Where(w => w.IsLit).ToList();

        /// <summary>
        /// Gets the modules on the bomb.
        /// </summary>
        public List<Module> Modules { get; } = new ();

        /// <summary>
        /// Gets the serial code on the bomb.
        /// </summary>
        public string Serial { get; }

        /// <summary>
        /// Gets or sets the amount of time remaining before the bomb explodes, in seconds.
        /// </summary>
        public float Time { get; set; } = 300;

        /// <summary>
        /// Gets or sets the number of strikes on the bomb.
        /// </summary>
        public int Strikes { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum number of strikes the bomb can withstand before exploding.
        /// </summary>
        public int StrikeLimit { get; set; } = 3;

        /// <summary>
        /// Gets the last digit of the serial number as an int.
        /// </summary>
        public int SerialLast => int.Parse(Serial.Last().ToString());

        /// <summary>
        /// Gets a value indicating whether the Serial number has a vowel.
        /// </summary>
        public bool SerialHasVowel => vowels.Any(c => Serial.Contains(c));

        /// <summary>
        /// Adds a strike.
        /// </summary>
        public void Strike()
        {
            Strikes++;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string modules = string.Empty;
            for (int i = 0; i < Modules.Count; i++)
            {
                Module module = Modules[i];
                modules += $"ID {i} : {module}, ";
            }

            return $"Serial : {Serial}, Time : {Time}, Strikes : {Strikes}, Modules : {modules}";
        }
    }
}