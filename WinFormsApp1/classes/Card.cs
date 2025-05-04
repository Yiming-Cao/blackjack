using System;
using System.Drawing;
using System.IO;

namespace WinFormsApp1.classes
{
    public enum Suits
    {
        HEARTS,
        DIAMONDS,
        CLUBS,
        SPADES
    }

    public enum FaceValues
    {
        ACE = 1,
        TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN,
        JACK, QUEEN, KING
    }

    public class Card
    {
        public Suits Suit { get; private set; }
        public FaceValues FaceValue { get; private set; }
        public int Value { get; private set; }
        public Image Img { get; private set; }

        public Card(Suits suit, FaceValues faceValue)
        {
            Suit = suit;
            FaceValue = faceValue;
            Value = GetCardValue(faceValue);
            Img = LoadCardImage(suit, faceValue);
        }

        private int GetCardValue(FaceValues faceValue)
        {
            return faceValue switch
            {
                FaceValues.ACE => 11,
                FaceValues.TEN or FaceValues.JACK or FaceValues.QUEEN or FaceValues.KING => 10,
                _ => (int)faceValue
            };
        }

        private Image LoadCardImage(Suits suit, FaceValues faceValue)
        {
            string resourceName = $"{faceValue.ToString().ToLower()}_of_{suit.ToString().ToLower()}";
            object imgObj = Properties.Resources.ResourceManager.GetObject(resourceName);

            if (imgObj is byte[] imgBytes)
            {
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            else if (imgObj is Image img)
            {
                return img;  
            }
            else
            {
                return LoadFallbackImage(); 
            }
        }

        private Image LoadFallbackImage()
        {
            object fallbackObj = Properties.Resources.ResourceManager.GetObject("red_joker");

            if (fallbackObj is byte[] imgBytes)
            {
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            else if (fallbackObj is Image img)
            {
                return img;
            }
            return null; 
        }

        public void SetAceValueToOne()
        {
            if (FaceValue == FaceValues.ACE && Value == 11)
            {
                Value = 1;
            }
        }

        public override string ToString()
        {
            return $"{FaceValue} of {Suit} ({Value} point)";
        }

        internal static int Sum(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
