import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

import { User } from '../models/user.model';
import { delay } from 'q';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    private url: string;
    private registerUrl: string;
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
        this.url = `${environment.apiUrl}/api/users/authenticate`;
        this.registerUrl = `${environment.apiUrl}/api/users/register`;
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<User>(this.url, { username, password })
            .pipe(map(user => {
                localStorage.setItem('currentUser', JSON.stringify(user))
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    register(username: string, password: string, firstname: string, lastname: string) {
        return this.http.post<User>(this.registerUrl, { username, password, firstname, lastname })
            .pipe(map(user => {
                localStorage.setItem('currentUser', JSON.stringify(user))
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}