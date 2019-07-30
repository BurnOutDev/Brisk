import { Component, OnInit } from '@angular/core';
import { GameService } from '../core/services/game.service';
import { BehaviorSubject } from 'rxjs';
import { Game } from '../core/models/game.model';
import { Question } from '../core/models/question.model';
import { AnswerMode } from '../core/models/answer-mode.enum';
import { Choice } from '../core/models/choice.model';
import { BinaryChoice } from '../core/models/binary-choice.enum';
import { ToastrService, Toast } from 'ngx-toastr';
import { AnswerReposnse } from '../core/models/answer-response.model';
import { delay } from 'q';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  gameId: number;
  answerMode: AnswerMode;
  questionCount: number;
  questions: Question[];
  question$: BehaviorSubject<Question>;

  showMultipleChoices: boolean;
  showBinaryChoices: boolean;
  isInputDisabled: boolean;

  constructor(
    private gameService: GameService,
    private toastrService: ToastrService
  ) {
    this.question$ = new BehaviorSubject<Question>(undefined);
    this.isInputDisabled = false;
  }

  ngOnInit() {
    this.gameService.startNewGame$().subscribe(
      (game) => {
        console.log(game);

        this.gameId = game.gameId;
        this.questionCount = game.questionCount;
        this.answerMode = game.answerMode;

        this.questions = game.questions;

        this.loadNextQuestion();
      });
  }

  async loadNextQuestion() {
    const question = this.questions.pop();
    this.question$.next(question);
    console.log(question);
  }

  answer(choice: Choice) {
    this.gameService.answer$({
      gameId: this.gameId,
      binaryChoice: BinaryChoice.Yes,
      choiceId: choice.choiceId
    }).subscribe(answerResponse => {
      this.notifyAnswerResponse(answerResponse).then(() => this.loadNextQuestion());
    });

    console.log(choice);
    console.log(`game: ${this.gameId}`);
  }

  async notifyAnswerResponse(answerResponse: AnswerReposnse) {
    this.toastrService.toasts.map(toast => this.toastrService.remove(toast.toastId));

    if (answerResponse.isCorrect) {
      this.toastrService.success('Answer is correct.');
    } else {
      this.toastrService.error('Answer is incorrect.');
    }

    this.isInputDisabled = true;

    await delay(1000);

    this.isInputDisabled = false;
  }
}
