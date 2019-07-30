import { Component, OnInit } from '@angular/core';
import { GameService } from '../core/services/game.service';
import { BehaviorSubject } from 'rxjs';
import { Game } from '../core/models/game.model';
import { Question } from '../core/models/question.model';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  game$: BehaviorSubject<Game>;
  currentQuestionIndex: number;

  constructor(
    private gameService: GameService
  ) {
    this.game$ = new BehaviorSubject<Game>(undefined);
    this.currentQuestionIndex = 0;
  }

  ngOnInit() {
    this.gameService.startNewGame$().subscribe(
      (game) => {
        this.game$.next(game);
        console.log(game);
      });
  }

  async nextQuestion() {
    this.game$
  }

}
