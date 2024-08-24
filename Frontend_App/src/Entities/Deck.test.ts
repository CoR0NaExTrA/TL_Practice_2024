import { Card } from "./Card";
import { Deck } from "./Deck";


describe("AddCardToDeck", () => 
{
    const deck: Deck = { id: 1, name: "Something", cards: [], cardCnt: 0 };
    const card: Card = { id: 1, word: "car", translation: "машина" };
  
    it("return new deck in success adding", () => 
    {
        expect(Deck.AddCardToDeck(card, deck)).not.toBe(deck);
    });
  
    it("add new card to empty deck", () => 
    {
      const expected: Deck = {
          id: 1,
          name: "Something",
          cards: [card],
          cardCnt: 0,
      };
  
      expect(Deck.AddCardToDeck(card, deck)).toEqual(expected);
    });
  
    it("add new card to down of deck", () => {
        const newDeck = Deck.AddCardToDeck(card, deck);
        const newCard: Card = { id: 2, word: "hi", translation: "привет" };
        const expected: Deck = {
            id: 1,
            name: "Something",
            cards: [
              {
                id: 1,
                word: "car",
                translation: "машина",
              },
              {
                id: 2,
                word: "hi",
                translation: "привет",
              },
            ],
            cardCnt: 0,
        };
  
        expect(Deck.AddCardToDeck(newCard, newDeck)).toEqual(expected);
    });
  
    it("return same object if add card with existing id", () => {
        const newDeck = Deck.AddCardToDeck(card, deck);
        const cardWithExistingId: Card = { id: 1, word: "hi", translation: "привет" };
  
        expect(Deck.AddCardToDeck(cardWithExistingId, newDeck)).toBe(newDeck);
    });
  
    it("return same object if add card with existing name", () => {
        const newDeck = Deck.AddCardToDeck(card, deck);
        const cardWithExistingName: Card = { id: 2, word: "car", translation: "другая маштна" };
      
        expect(Deck.AddCardToDeck(cardWithExistingName, newDeck)).toBe(newDeck);
    });
  });
  
describe("RemoveCardToDeck", () => 
{
    const deck: Deck = 
    {
        id: 1,
        name: "Some",
        cards: [
          {
            id: 1,
            word: "car",
            translation: "машина",
          },
          {
            id: 2,
            word: "house",
            translation: "дом",
          },
          {
            id: 5,
            word: "hunter",
            translation: "охотник",
          },
        ],
        cardCnt: 3,
    };
  
    it("return same object if nothing to delete", () => 
    {
        expect(Deck.RemoveCardToDeck(3, deck)).toBe(deck);
    });
  
    it("success deleting", () => 
    {
      const expected: Deck = 
      {
          id: 1,
          name: "Some",
          cards: [
            {
              id: 2,
              word: "house",
              translation: "дом",
            },
            {
              id: 5,
              word: "hunter",
              translation: "охотник",
            },
          ],
          cardCnt: 3,
      };
  
      expect(Deck.RemoveCardToDeck(1, deck)).toEqual(expected);
    });
  
    it("return new deck in success completed", () => 
    {
        expect(Deck.RemoveCardToDeck(1, deck)).not.toBe(deck);
    });
  });