import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Game } from '../models/game.model';
import { Answer } from '../models/answer.model';
import { AnswerReposnse as AnswerResposnse } from '../models/answer-response.model';
import { Settings } from '../models/settings.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = `${environment.apiUrl}/api/games`;
  }

  startNewGame$ = (): Observable<Game> => this.http.get<Game>(this.url + '/start-new-game');
  answer$ = (answer: Answer): Observable<AnswerResposnse> => this.http.post<AnswerResposnse>(this.url + '/answer', answer);
  updateSettings$ = (settings: Settings): Observable<Settings> => this.http.post<Settings>(this.url + '/settings', settings);
  getSettings$ = (): Observable<Settings> => this.http.get<Settings>(this.url + '/settings');
}
