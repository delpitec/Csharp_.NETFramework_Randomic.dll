using System;
using System.Reflection;


namespace Randomic
{
    /// <summary>
    /// Deck card object representation 
    /// </summary>
    public class DeckCard
    {
        /// <summary>
        /// Suit UTF-16 chacacter code 
        /// </summary>
        public string SuitUTF16 { get; private set; }

        /// <summary>
        /// Suit Color name (red or black)
        /// </summary>
        public ConsoleColor SuitColor { get; private set; }

        /// <summary>
        /// Card Symbol value (2 to 10, J, Q, K, A) 
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Numeric card value (1 to 14) 
        /// </summary>
        public int Value { get; private set; }


        /// <summary>
        /// Initializes a default Card [ A | Heart | Value = 1 ]  
        /// </summary>
        public DeckCard()
        {
            SetSuitUTF16(0);
            SetSuitColor(0);
            SetValue(1);
        }


        /// <summary>
        /// Initializes a Card according suit and numeric card value 
        /// </summary>
        /// <param name="suit">Selects the card suit (Enum.Heart,Enum.Diamond,Enum.Spades,Enum.Club).</param>
        /// <param name="value">Numeric card value (1 to 14).</param>
        public DeckCard(DeckCardSuit suit, int value)
        {
            SuitUTF16 = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), suit)).GetCustomAttribute<SuitAttribute>(false).Utf16Code;
            SuitColor = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), suit)).GetCustomAttribute<SuitAttribute>(false).SuitColor;
            SetValue(value);
        }

        /// <summary>
        /// Initializes a Card according suit and numeric card value 
        /// </summary>
        /// <param name="suit">Selects the card suit (Enum.Heart,Enum.Diamond,Enum.Spades,Enum.Club).</param>
        /// <param name="symbol">Symbol card value - case sensitive (2 to 10 , J , Q, K or A).</param>
        /// <param name="aceValue">Mandatory if Symbol == "A" (1 or 14) | Optional (discarded) if Symbol != "A".</param>
        public DeckCard(DeckCardSuit suit, string symbol, int aceValue = 0)
        {
            Symbol = symbol;
            SuitUTF16 = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), suit)).GetCustomAttribute<SuitAttribute>(false).Utf16Code;
            SuitColor = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), suit)).GetCustomAttribute<SuitAttribute>(false).SuitColor;

            if (symbol.Equals("A"))
            {
                if ((aceValue != 1) && (aceValue != 14))
                {
                    throw new ArgumentOutOfRangeException("Card.aceValue", "Must be: [1 or 14]");
                }
                else
                {
                    SetValue(symbol, aceValue);
                    return;
                }
            }
            SetValue(symbol);
        }



        internal void SetSuitUTF16(int val)
        {
            if (val > 3)
                throw new ArgumentOutOfRangeException("val", "Must be: [val > 0] and [val < 4]");
            else
                SuitUTF16 = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), val)).GetCustomAttribute<SuitAttribute>(false).Utf16Code;
        }

        internal void SetSuitColor(int val)
        {
            if (val > 3)
                throw new ArgumentOutOfRangeException("val", "Must be: [val > 0] and [val < 4]");
            else
                SuitColor = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), val)).GetCustomAttribute<SuitAttribute>(false).SuitColor;
        }

        internal void SetValue(int val)
        {
            if (val == 0 || val > 14)
            {
                throw new ArgumentOutOfRangeException("Card.SetValue.val", "Must be: [val > 0] and [val < 15]");
            }
            else
            {
                Value = val;
                SetSymbol();
            }
        }

        private void SetValue(string symbol, int aceValue = 0)
        {
            if (symbol.Equals("J"))
            {
                Value = 11;
                return;
            }
            else if (symbol.Equals("Q"))
            {
                Value = 12;
                return;
            }
            else if (symbol.Equals("K"))
            {
                Value = 13;
                return;
            }
            else if (symbol.Equals("A"))
            {
                if ((aceValue == 0) || (aceValue > 14))
                    throw new ArgumentOutOfRangeException("Card.SetValue.aceValue", "Must be: [ 1 or 14 ]");

                Value = aceValue;
                return;
            }
            else
            {
                int symbolValue = int.Parse(symbol);

                if ((symbolValue > 0) && symbolValue < 11)
                {
                    Value = symbolValue;
                    return;
                }
            }

            throw new ArgumentOutOfRangeException("Card.SetValue", "Error in symbol Value");

        }

        private void SetSymbol()
        {
            if (Value == 0 || Value > 14)
                throw new ArgumentOutOfRangeException("Card.SetSymbol.Value", "Must be: [Value > 0] and [val < 15]");
            else
            {
                if (Value == 1 || Value == 14)
                    Symbol = "A";
                else if (Value == 11)
                    Symbol = "J";
                else if (Value == 12)
                    Symbol = "Q";
                else if (Value == 13)
                    Symbol = "K";
                else
                    Symbol = Value.ToString();
            }
        }

        public override string ToString()
        {
            return Symbol + SuitUTF16;
        }

        public override int GetHashCode()
        {
            return SuitUTF16.GetHashCode() + Symbol.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DeckCard))
            {
                return false;
            }
            else
            {
                DeckCard InputObj = obj as DeckCard;
                return this.SuitUTF16.Equals(InputObj.SuitUTF16) && this.Symbol.Equals(InputObj.Symbol);
            }
        }
    }
}

