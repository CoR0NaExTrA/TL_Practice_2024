import { Card } from "./Card";

describe("EditCard", () => 
{
    const card: Card = { id: 1, word: "car", translation: "машина"};

    it("edit with right words", () => 
    {
        const expected = 
        {
            id: 1,
            word: "car",
            translation: "машина",
        };

        expect(Card.EditCard("car", "машина", card)).toEqual(expected);
    });

    it("return new card in success editing", () => 
    {
        expect(Card.EditCard(card.word, card.translation, card)).not.toBe(card);
    });

    it("editing with empty word return object with empty word", () => 
    {
        expect(Card.EditCard("", "машина", card).word).toEqual("");
    });

    it("editing with translation word return object with empty translate", () => 
    {
        expect(Card.EditCard("car", "", card).translation).toEqual("");
    });
})