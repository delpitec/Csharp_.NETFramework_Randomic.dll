using System;

namespace Randomic
{
    class SuitAttribute : Attribute
    {
        public string Utf16Code { get; set; }
        public ConsoleColor SuitColor { get; set; }

        public SuitAttribute(string utf16Code, ConsoleColor suitColor)
        {
            Utf16Code = utf16Code;
            SuitColor = suitColor;
        }
    }
    /// <summary>
    /// Group of possibles deck card suits with their attributes 
    /// </summary>
    public enum DeckCardSuit
    {
        /// <summary>
        /// Heart deck card suit (♥) parameters 
        /// </summary>
        [SuitAttribute("\u2665", ConsoleColor.Red)]
        Heart,

        /// <summary>
        /// Diamond deck card suit (♦) parameters 
        /// </summary>
        [SuitAttribute("\u2666", ConsoleColor.Red)]
        Diamond,

        /// <summary>
        /// Spades deck card suit (♠) parameters 
        /// </summary>
        [SuitAttribute("\u2660", ConsoleColor.Black)]
        Spades,

        /// <summary>
        /// Spades deck card suit (♣) parameters 
        /// </summary>
        [SuitAttribute("\u2663", ConsoleColor.Black)]
        Club
    }
}
