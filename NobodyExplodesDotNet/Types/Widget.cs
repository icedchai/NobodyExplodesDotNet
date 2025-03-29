namespace NobodyExplodesDotNet.Types
{
    public abstract class Widget
    {
        /// <summary>
        /// Gets the bomb this module is on, or null.
        /// </summary>
        public Bomb Owner { get; internal set; } = null;
    }
}
