import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { UsersService } from '../services/users.service';
import { Store } from './store';
import { User } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UsersStore extends Store<User[]> {

    constructor(private usersService: UsersService) {
        super();
    }

    init = (): void => {
        if (this.getAll()) { return; }

        this.usersService.get$().pipe(
            tap(this.store)
        ).subscribe();
    }

    create$ = (user: User): Observable<User> => this.usersService
        .post$(user)
    // .pipe(
    //     tap(resUser => {
    //         this.store([
    //             ...this.getAll(),
    //             {
    //                 id: resUser.id,
    //                 ...user
    //             }
    //         ]);
    //     })
    // )

    update$ = (userId: number, user: User) => this.usersService
        .put$(userId, user)
    // .pipe(
    //     tap(resUser => {
    //         const users = this.getAll();
    //         this.store(users);
    //     })
    // )

    delete$ = (userId: number) => this.usersService
        .delete$(userId)
        .pipe(
            tap(() => {
                const users = this.getAll();
                const userIndex = this.getAll().findIndex(item => item.id === userId);
                users.splice(userIndex, 1);

                this.store(users);
            })
        )

    disable$ = function (userId: number, user: User) {
        user.disabled = true;

        this.usersService
            .put$(userId, user)
            .pipe(
                tap(() => {
                    const users = this.getAll();
                    const userIndex = this.getAll().findIndex(item => item.id === userId);
                    users.splice(userIndex, 1);

                    this.store(users);
                })
            );
    }
}