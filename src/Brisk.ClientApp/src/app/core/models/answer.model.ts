import { BinaryChoice } from './binary-choice.enum';

export interface Answer {
    gameId: number;
    choiceId: number;
    binaryChoice: BinaryChoice;
}