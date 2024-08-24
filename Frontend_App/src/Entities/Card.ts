export type Card ={
    id: number;
    word: string;
    translation: string;
}

const EditCard = (word: string, translation: string, card: Card) => 
{
    return {
        ...card,
        word: word,
        translation: translation,
    };
};

export const Card = {EditCard};