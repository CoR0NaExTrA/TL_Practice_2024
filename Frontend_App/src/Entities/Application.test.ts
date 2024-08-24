import { Application } from "./Application";
import { Deck } from "./Deck";

describe("CreateDeck", () => 
{
    const app: Application = 
    {
        decks: [],
        deckCnt: 0,
    };
    const deck: Deck = { id: 1, name: "Something", cards: [], cardCnt: 0 };

    it("return new application in success adding", () => 
    {
        expect(Application.CreateDeck(deck, app)).not.toBe(app);
    });

    it("success add new deck to empty deck collection", () => 
    {
        const expected: Application = {
            decks: [
                {
                    id: 1,
                    name: "Something",
                    cards: [],
                    cardCnt: 0,
                },
            ],
            deckCnt: 0,
        };

        expect(Application.CreateDeck(deck, app)).toEqual(expected);
    });

    it("success add new deck to down the collection", () => 
    {
        const newApp = Application.CreateDeck(deck, app);
        const newDeck: Deck = { id: 2, name: "Everything", cards: [], cardCnt: 0 };
        const expected: Application = {
            decks: [
                {
                    id: 1,
                    name: "Something",
                    cards: [],
                    cardCnt: 0,
                },
                {
                    id: 2,
                    name: "Everything",
                    cards: [],
                    cardCnt: 0,
                },
            ],
            deckCnt: 0,
        };

        expect(Application.CreateDeck(newDeck, newApp)).toEqual(expected);
    });

    it("adding new deck with existing id return same object", () => 
    {
        const newApp = Application.CreateDeck(deck, app);
        const deckWithExistingId: Deck = { id: 1, name: "Oops", cards: [], cardCnt: 0 };

        expect(Application.CreateDeck(deckWithExistingId, newApp)).toBe(newApp);
    });

    it("adding new deck with existing name return same object", () => 
    {
        const newApp = Application.CreateDeck(deck, app);
        const deckWithExistingName: Deck = { id: 2, name: "Something", cards: [], cardCnt: 0 };

        expect(Application.CreateDeck(deckWithExistingName, newApp)).toEqual(newApp);
    });
});

describe("RemoveDeck", () => 
{
    const app: Application = 
    {
        decks: [
            {
                id: 1,
                name: "Something",
                cards: [],
                cardCnt: 0,
            },
            {
                id: 2,
                name: "Everything",
                cards: [],
                cardCnt: 0,
            },
        ],
        deckCnt: 2,
    };

    it("return new Application in success deleting", () => 
    {
        expect(Application.RemoveDeck(1, app)).not.toBe(app);
    });

    it("deleting with unknown id return same object", () => 
    {
        expect(Application.RemoveDeck(3, app)).toBe(app);
    });

    it("success deleting", () => 
    {
        const expected: Application = 
        {
            decks: [
              {
                  id: 2,
                  name: "Everything",
                  cards: [],
                  cardCnt: 0,
              },
            ],
            deckCnt: 2,
        };

        expect(Application.RemoveDeck(1, app)).toEqual(expected);
    });
});