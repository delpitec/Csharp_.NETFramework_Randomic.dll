using System;
using System.Collections.Generic;

namespace Randomic
{
    /// <summary>
    /// It contains randomic deck cards operations 
    /// </summary>
    public class RandomDeckCard
    {
        /// <summary>
        /// Choose a random deck card 
        /// </summary>
        /// <returns>An object containing deck card informations</returns>
        public static DeckCard Get()
        {
            DeckCard NewCard = new DeckCard();
            Random rnd = new Random();

            // sort and set suit
            int RndReturn = rnd.Next(4);
            NewCard.SetSuitUTF16(RndReturn);
            NewCard.SetSuitColor(RndReturn);

            // sort and set value and figure value
            RndReturn = rnd.Next(1, 14);
            NewCard.SetValue(RndReturn);

            return NewCard;
        }

        /// <summary>
        /// Choose a random deck card excluding the specified at cardExcepting param
        /// </summary>
        /// <param name="cardExcepting">Deck card that will be filtered during random choose.</param>
        /// <returns>An object containing deck card informations</returns>
        public static DeckCard GetExceptingOne(DeckCard cardExcepting)
        {
            DeckCard NewCard = new DeckCard();
            Random rnd = new Random();
            bool RetCardEqualsCardExcepting = true;

            while (RetCardEqualsCardExcepting)
            {
                int RndReturn = rnd.Next(4);
                NewCard.SetSuitUTF16(RndReturn);
                NewCard.SetSuitColor(RndReturn);

                RndReturn = rnd.Next(1, 14);
                NewCard.SetValue(RndReturn);

                RetCardEqualsCardExcepting = NewCard.Equals(cardExcepting);
            }

            return NewCard;
        }

        /// <summary>
        /// Choose a random deck card excluding the specified at list cardExcepting param
        /// </summary>
        /// <param name="cardExcepting">List of deck card that will be filtered during random choose.</param>
        /// <returns>An object containing deck card informations</returns>
        public static DeckCard GetExceptingList(List<DeckCard> cardExcepting)
        {
            DeckCard NewCard = new DeckCard();
            Random rnd = new Random();
            bool RetCardEqualsCardExcepting = true;

            while (RetCardEqualsCardExcepting)
            {
                int RndReturn = rnd.Next(4);
                NewCard.SetSuitUTF16(RndReturn);
                NewCard.SetSuitColor(RndReturn);

                RndReturn = rnd.Next(1, 14);
                NewCard.SetValue(RndReturn);

                if (cardExcepting.Contains(NewCard))
                    continue;
                else
                    RetCardEqualsCardExcepting = false;
            }
            return NewCard;
        }

    }
}
