import { Component, OnInit } from '@angular/core';
import { GameService } from '../core/services/game.service';
import { BehaviorSubject } from 'rxjs';
import { Question } from '../core/models/question.model';
import { AnswerMode } from '../core/models/answer-mode.enum';
import { Choice } from '../core/models/choice.model';
import { BinaryChoice } from '../core/models/binary-choice.enum';
import { ToastrService, Toast } from 'ngx-toastr';
import { AnswerReposnse } from '../core/models/answer-response.model';
import { delay } from 'q';
import { Router } from '@angular/router';

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

  binaryAnswerYes: BinaryChoice = BinaryChoice.Yes;
  binaryAnswerNo: BinaryChoice = BinaryChoice.No;

  binaryAnswerSelected: BinaryChoice;

  singleChoiceForBinary: Choice;

  correctAnswersCount: number;

  finished: boolean;

  constructor(
    private gameService: GameService,
    private toastrService: ToastrService,
    private router: Router
  ) {
    this.question$ = new BehaviorSubject<Question>(undefined);
    this.isInputDisabled = false;
    this.finished = false;
    this.correctAnswersCount = 0;
  }

  ngOnInit() {
    this.gameService.startNewGame$().subscribe(
      (game) => {
        console.log(game);

        this.gameId = game.gameId;
        this.questionCount = game.questionCount;
        this.answerMode = game.answerMode;

        this.questions = game.questions;

        this.showBinaryChoices = this.answerMode === AnswerMode.Binary;
        this.showMultipleChoices = this.answerMode === AnswerMode.Multiple;

        this.loadNextQuestion();
      });
  }

  async loadNextQuestion() {
    const question = this.questions.pop();

    if (this.answerMode === AnswerMode.Binary) {
      this.singleChoiceForBinary = question.choices[0];
      console.log(this.singleChoiceForBinary);
    }

    this.question$.next(question);
  }

  answer(choice: Choice) {
    this.gameService.answer$({
      gameId: this.gameId,
      binaryChoice: this.binaryAnswerSelected,
      choiceId: choice.choiceId
    }).subscribe(answerResponse => {
      this.notifyAnswerResponse(answerResponse).then(() => {
        if (this.questions.length <= 0) {
          this.finished = true;
          this.showMultipleChoices = this.showBinaryChoices = false;
        } else {
          this.loadNextQuestion();
        }
      });

      if (answerResponse.isCorrect) {
        this.correctAnswersCount++;
      }
    });
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

  binaryAnswer(answer: BinaryChoice) {
    this.binaryAnswerSelected = answer;

    this.answer(this.singleChoiceForBinary);
  }

  playAgain() {

    // this.router.onSameUrlNavigation = 'reload';
    // this.router.navigateByUrl('play');

    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() =>
    this.router.navigate(["play"])); 
  }
}
