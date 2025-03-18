using System;
using System.Drawing;  // 添加命名空间以使用 Image

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
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
    }

    public class Card
    {
        private Suits suit;
        private FaceValues faceValue;
        private int value;
        private Image img;

        public Suits Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public FaceValues FaceValue
        {
            get { return faceValue; }
        }

        public int Value
        {
            get { return value; }
        }

        public Image Img
        {
            get { return img; }
            set { img = value; }
        }

        public Card(Suits suit, FaceValues faceValue, Image img = null)
        {
            this.suit = suit;
            this.faceValue = faceValue;
            this.img = img;

            switch (faceValue)
            {
                case FaceValues.ACE:
                    this.value = 11;
                    break;
                case FaceValues.TEN:
                case FaceValues.JACK:
                case FaceValues.QUEEN:
                case FaceValues.KING:
                    this.value = 10;
                    break;
                default:
                    this.value = (int)faceValue;
                    break;
            }
        }
    }
}
