import { LearningProcess } from "./LearningProcess";

describe("CreateLearningProcess", () => 
{
    it("create with empty", () => 
    {
        const emptyLearnProc = LearningProcess.CreateLearningProcess([]);
        const expected = {
            cards: [],
            completed: [],
        };

        expect(emptyLearnProc).toEqual(expected);
    });

    it("create with not empty", () => 
    {
        const notemptyLearnProc = LearningProcess.CreateLearningProcess([
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
        ]);
        
        const expected = 
        {
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
            completed: [],
        };

        expect(notemptyLearnProc).toEqual(expected);
    });
});

describe("PutCardInCompleted", () => 
{
    const learnProc = {
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
        completed: [],
    };

    it("return new Learning Process", () => 
    {
        expect(LearningProcess.PutCardInCompleted(learnProc)).not.toBe(learnProc);
    });

    it("getting from empty deck return same object", () => 
    {
        const learnProcWithEmptyDeck = 
        {
            cards: [],
            completed: [
                {
                    id: 1,
                    word: "car",
                    translation: "машина",
                },
            ],
        };

        expect(LearningProcess.PutCardInCompleted(learnProcWithEmptyDeck)).toBe(learnProcWithEmptyDeck);
    });

    it("success put card to complited", () => {
        const expected = 
        {
            cards: [
                {
                    id: 2,
                    word: "hi",
                    translation: "привет",
                },
            ],

            completed: [
                {
                    id: 1,
                    word: "car",
                    translation: "машина",
                },
            ],
        };

        expect(LearningProcess.PutCardInCompleted(learnProc)).toEqual(expected);
    });
});

describe("PutCardDownDeck", () => 
{
    const learnProc = {
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
            {
                    id: 5,
                    word: "hunter",
                    translation: "охотник",
            },
        ],
        completed: [
            {
                    id: 3,
                    word: "house",
                    translation: "дом",
            },
        ],
    };

    it("return new Learning Process in success putting", () => 
        {
        expect(LearningProcess.PutCardDownDeck(learnProc)).not.toBe(learnProc);
    });

    it("getting in empty deck not return same object", () => 
    {
        const learnProcWithEmptyDeck = 
        {
            cards: [],
            completed: [
                {
                    id: 1,
                    word: "car",
                    translation: "машина",
                },
            ],
        };

        expect(LearningProcess.PutCardDownDeck(learnProcWithEmptyDeck)).toBe(learnProcWithEmptyDeck);
    });

    it("success put card to down the deck", () => 
    {
        const expected = {
            cards: [
                {
                    id: 2,
                    word: "hi",
                    translation: "привет",
                },
                {
                    id: 5,
                    word: "hunter",
                    translation: "охотник",
                },
                {
                    id: 1,
                    word: "car",
                    translation: "машина",
                },
            ],
            completed: [
                {
                    id: 3,
                    word: "house",
                    translation: "дом",
                },
            ],
        };

        expect(LearningProcess.PutCardDownDeck(learnProc)).toEqual(expected);
    });
});