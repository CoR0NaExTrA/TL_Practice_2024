import { Card } from "./Card";

export type LearningProcess = {
    cards: Card[];
    completed: Card[];
};

const CreateLearningProcess = (cards: Card[]): LearningProcess => 
{
    return {
        cards: [...cards],
        completed: [],
    }
};

const TakeCardFromDeckAndPut = (learnProc: LearningProcess, eraseAfterDrafting: boolean | undefined = undefined) =>
{
    if (learnProc.cards.length == 0) {
        return learnProc;
    }

    const newCards = [...learnProc.cards];
    const card = newCards[0];
    newCards.splice(0, 1);

    if (eraseAfterDrafting) {
        return {
            cards: [...newCards],
            completed: [...learnProc.completed, card],
        };
    }
    return {
        ...learnProc,
        cards: [...newCards, card],
    };
};

const PutCardInCompleted = (learnProc: LearningProcess): LearningProcess => 
{
    return TakeCardFromDeckAndPut(learnProc, true);
};

const PutCardDownDeck = (learnProc: LearningProcess): LearningProcess => 
{
    return TakeCardFromDeckAndPut(learnProc);
};

export const LearningProcess = 
{
    CreateLearningProcess, PutCardInCompleted, PutCardDownDeck
};