import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = `${environment.apiUrl}/api/users`;
  }

  get$ = (): Observable<User[]> => this.http.get<User[]>(this.url);

  post$ = (user: User): Observable<User> => this.http.post<User>(this.url, user);

  getPaginatedAndFiltered$ = (skip: number = 0, filter?: string): Observable<User[]> => this.http.get<User[]>(this.url + this.withPageAndFilter(skip, filter));
  
  put$ = (id: number, user: User): Observable<User> => this.http.put<User>(`${this.url}/${id}`, user);

  delete$ = (id: number): Observable<User> => this.http.delete<User>(`${this.url}/${id}`);

  withPageAndFilter(skip: number, filter?: string): string {
    var url = `/?skip=${skip}&take=${environment.defaultTake}`;
    if (filter)
      url += `&filter=${filter}`;
    return url;
  }
}

