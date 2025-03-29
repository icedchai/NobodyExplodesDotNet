namespace NobodyExplodesDotNet.Types.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a keypad module.
    /// </summary>
    public class KeypadModule : Module
    {
        private static List<char> characters = new List<char>
        {
            'Ѽ', 'æ', '©', 'Ӭ', 'Ҩ', 'Ҋ',
            'ϗ', 'ϰ', 'Ԇ', 'Ϙ', 'Ѯ', 'ƛ',
            'Ω', '¶', 'ψ', '¿', 'Ϭ',
            'Ͼ', 'Ͽ', '★', '☆', 'ټ', '҂',
            'Ѣ', 'Ѭ', 'Ѧ', 'Җ',
        };

        private static List<string> columns = new List<string>
        {
            "ϘѦƛϰѬϗϿ",
            "ӬϘϿҨ☆ϗ¿",
            "©ѼҨҖԆƛ☆",
            "Ϭ¶ѢѬҖ¿ټ",
            "ψټѢϾ¶Ѯ★",
            "ϬӬ҂æψҊΩ",
        };

        private int columnIndex;

        /// <summary>
        /// Gets or sets the buttons on the module.
        /// </summary>
        public string Buttons { get; set; } = string.Empty;

        /// <summary>
        /// Gets the column this module uses.
        /// </summary>
        public string Column
        {
            get
            {
                return columns[columnIndex];
            }
        }

        private List<int> Input = new List<int>();

        public bool ButtonIsPressed(int button)
        {
            return Input.Contains(button);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeypadModule"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        /// <param name="rng">The <see cref="Random"/> instance to use.</param>
        public KeypadModule(Random rng, Bomb bomb)
        {
            Owner = bomb;
            columnIndex = rng.Next(columns.Count);
            for (int i = 0; i < 4; i++)
            {
                Buttons += Column.Where(c => !Buttons.Contains(c)).GetRandomElement();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeypadModule"/> class.
        /// </summary>
        /// <param name="bomb">The bomb that owns this module.</param>
        public KeypadModule(Bomb bomb)
        {
            Owner = bomb;
            columnIndex = CommonFuncs.rng.Next(columns.Count);
            for (int i = 0; i < 4; i++)
            {
                Buttons += Column.Where(c => !Buttons.Contains(c)).GetRandomElement();
            }
        }

        private List<char> solvedSequence
        {
            get
            {
                return Column.Where(c => Buttons.Contains(c)).ToList();
            }
        }

        private bool CheckInput(List<int> input)
        {
            string characters = string.Empty;
            string columnsRef = string.Empty;
            for (int i = 0; i < input.Count; i++)
            {
                columnsRef += solvedSequence[i];
                characters += Buttons[input[i]];
            }

            return characters == columnsRef;
        }

        public void PressButton(int input)
        {
            if (IsSolved)
            {
                return;
            }

            Input.Add(input);

            if (!CheckInput(Input))
            {
                Owner.Strike();
                Input = new List<int>();
                return;
            }

            if (Input.Count == 4)
            {
                IsSolved = true;
                return;
            }
        }
    }
}
