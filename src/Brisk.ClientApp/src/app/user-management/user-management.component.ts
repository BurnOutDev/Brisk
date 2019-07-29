import { Component, OnInit } from '@angular/core';
import { User } from '../core/models/User.model';
import { Observable, BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';
import { UsersService } from '../core/services/users.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {

  users$: BehaviorSubject<User[]>;

  collapsed: boolean[] = new Array(2000);

  constructor(
    private usersService: UsersService,
    private toastrService: ToastrService) {
      this.users$ = new BehaviorSubject<User[]>(undefined);
  }

  ngOnInit() {
    this.usersService.get$().subscribe(user => this.users$.next(user));
  }

  success() {
    this.toastrService.success("Success");
  }

  error() {
    this.toastrService.error("Error");
  }

  createUser(user: User) {


    this.users$.pipe(
      map(data =>
        data.push({
          id: 0,
          username: '',
          firstName: '',
          lastName: '',
          role: '',
          disabled: false
        })));
  }

  updateUser(user: User) {
    console.log("update pressed");
    this.usersService.put$(user.id, user).subscribe((u) => {
      this.toastrService.success(`${u.username} updated`);
    }, (error) => {
      this.toastrService.error(error.message);
    });
  }

  deleteUser(user: User) {
    this.usersService.delete$(user.id).subscribe(this.success, this.error);
  }

  disableUser(user: User) {
    user.disabled = !user.disabled;
    this.usersService.put$(user.id, user).subscribe(() => {
      this.toastrService.success('User disabled successfully.');
    });
  }
}