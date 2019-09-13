using Laboratorio_4_OOP_201902.Cards;
using Laboratorio_4_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Player
    {
        //Constantes
        private const int LIFE_POINTS = 2;
        private const int START_ATTACK_POINTS = 0;

        //Static
        private static int idCounter;

        //Atributos
        private int id;
        private int lifePoints;
        private int attackPoints;
        private Deck deck;
        private Hand hand;
        private Board board;
        private SpecialCard captain;
        private Type meele;
        private Type range;
        private Type longRange;
        private Type buff;
        private Type weather;

        //Constructor
        public Player()
        {
            LifePoints = LIFE_POINTS;
            AttackPoints = START_ATTACK_POINTS;
            Deck = new Deck();
            Hand = new Hand();
            Id = idCounter++;
        }

        //Propiedades
        public int Id { get => id; set => id = value; }
        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = value;
            }
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return this.hand;
            }
            set
            {
                this.hand = value;
            }
        }
        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }
        public SpecialCard Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                this.captain = value;
            }
        }

        //Metodos
        public void DrawCard(int cardId = 0)
        { 
            Card card = deck.Cards[cardId];
            hand.AddCard(card);
            deck.DestroyCard(cardId);
        }
        public void PlayCard(int cardId, EnumType buffRow = EnumType.None)
        {
            Card card = deck.Cards[cardId];
            
            //Combat Cards
            if ((card.GetType() == meele) || (card.GetType() == range) || (card.GetType() == longRange))
            {
                board.AddCard(card, -1, EnumType.None);

            } else if (card.GetType()== buff)
            
            //Special Cards
            {
                board.AddCard(card, -1, EnumType.None);
            } else if (card.GetType() == weather)
            {
                board.AddCard(card);
            }

            hand.DestroyCard(cardId);
        }
        public void ChangeCard(int cardId)
        {
            Card card = hand.Cards[cardId];
            hand.DestroyCard(cardId);
            Random random = new Random();
            int RN = random.Next(1, 20);
            Card randomCard = deck.Cards[RN];
            DrawCard(RN);
            deck.DestroyCard(RN);
            hand.AddCard(card);
        }

        public void FirstHand()
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int NR = random.Next(1, 20);
                Card RC = deck.Cards[NR];
                DrawCard(NR);
                deck.DestroyCard(NR);
                hand.AddCard(RC);
            }

        }

        public void ChooseCaptainCard(SpecialCard captainCard)
        {
            Captain = captainCard;
        }

    }
}
