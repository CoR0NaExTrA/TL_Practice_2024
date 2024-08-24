import { Deck } from "./Deck";

export type Application = {
    decks: Deck[];
    deckCnt: number; 
};


const CreateDeck = (newDeck: Deck, app: Application): Application => 
{
    if (app.decks.some(d => d.id === newDeck. id || d.name === newDeck.name))
    {
        return app;
    }

    return {
        ...app,
        decks: [...app.decks, newDeck],
    };
};

const RemoveDeck = (id: number, app: Application ): Application =>
{
    const index = app.decks.findIndex(d => d.id === id);

    if (index === -1)
    {
        return app;
    }

    const newDecks = [...app.decks];
    newDecks.splice(index, 1);

    return {
        ...app,
        decks: newDecks,
    };
};

export const Application = 
{
    CreateDeck, RemoveDeck
};