import { Choice } from './choice.model';

export interface Question {
    questionId: number;
    quote: string;
    choices: Choice[];
}