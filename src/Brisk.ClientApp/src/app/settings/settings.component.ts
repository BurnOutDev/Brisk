import { Component, OnInit } from '@angular/core';
import { GameService } from '../core/services/game.service';
import { AnswerMode } from '../core/models/answer-mode.enum';
import { BehaviorSubject } from 'rxjs';
import { Settings } from '../core/models/settings.model';
import { Router } from '@angular/router';
import { ITEMS } from '../core/models/items.data';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

  settings$: BehaviorSubject<Settings>;

  answerMode: AnswerMode;
  questionCount: number;

  answerModeBinary: AnswerMode = AnswerMode.Binary;
  answerModeMultiple: AnswerMode = AnswerMode.Multiple;

  constructor(
    private gameService: GameService,
    private router: Router) { 
      this.settings$ = new BehaviorSubject<Settings>(undefined);
  }

  ngOnInit() {
    this.gameService.getSettings$().subscribe(
      (settings) => {
        this.settings$.next(settings);
      }
    );
  }

  updateSettings(settings: Settings) {
    console.log(settings);
    this.gameService.updateSettings$(settings).subscribe(() => console.log(settings));
    console.log('updated');
  }

  goToQuoteManagement() {
    this.router.navigateByUrl('quote-management');
  }

  goToUserManagement() {
    this.router.navigateByUrl('user-management');
  }

  goToUserAchievements() {
    this.router.navigateByUrl('user-achievements');
  }
}
