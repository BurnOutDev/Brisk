import { AnswerMode } from './answer-mode.enum';
import { Question } from './question.model';

export interface Game {
    gameId: number;
    answerMode: AnswerMode;
    questionCount: number;
    questions: Question[];
}
