import { Card } from "./Card";

export type Deck = {
    id: number;
    name: string;
    cards: Card[];
    cardCnt: number
}

const AddCardToDeck = (newCard: Card, deck: Deck) : Deck =>
{
    if (deck.cards.some(c => c.id == newCard.id || c.word == newCard.word))
    {
        return deck;
    }

    return {
        ...deck,
        cards: [...deck.cards, newCard],
    };
};

const RemoveCardToDeck = (id: number, deck: Deck) : Deck =>
{
    const index = deck.cards.findIndex(c => c.id === id);

    if (index === -1) {
        return deck;
    }

    const newCards = [...deck.cards];
    newCards.splice(index, 1);
    return {
        ...deck,
        cards: [...newCards],
    };
};

export const Deck = {
    AddCardToDeck, RemoveCardToDeck
};