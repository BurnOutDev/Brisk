import { Observable } from 'rxjs';
import { Quote } from '../models/quote.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Author } from '../models/author.model';

@Injectable({
  providedIn: 'root'
})
export class QuotesService {

  private url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = `${environment.apiUrl}/api/quotes`;
  }

  get$ = (): Observable<Quote[]> => this.http.get<Quote[]>(this.url);

  getById$ = (id: number): Observable<Quote> => this.http.get<Quote>(`${this.url}/${id}`);

  getAuthors$ = (): Observable<Author[]> => this.http.get<Author[]>(this.url + '/authors');

  getPaginatedAndFiltered$ = (skip: number = 1, filter?: string): Observable<Quote[]> => this.http.get<Quote[]>(this.url + this.withPageAndFilter(skip, filter));

  post$ = (quote: Quote): Observable<Quote> => this.http.post<Quote>(this.url, quote);

  put$ = (id: number, quote: Quote): Observable<Quote> => this.http.put<Quote>(`${this.url}/${id}`, quote);

  delete$ = (id: number): Observable<Quote> => this.http.delete<Quote>(`${this.url}/${id}`);

  withPageAndFilter(skip: number, filter?: string): string {
    var url = `/?skip=${skip}&take=${environment.defaultTake}`;
    if (filter)
      url += `&filter=${filter}`;
    return url;
  }
}
