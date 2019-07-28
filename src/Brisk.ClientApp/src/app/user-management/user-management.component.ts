import { Component, OnInit } from '@angular/core';
import { User } from '../core/models/User.model';
import { Observable } from 'rxjs';
import { UsersStore } from '../core/stores/users.store';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {

  users$: Observable<User[]>;

  constructor(
    private usersStore: UsersStore,
    private toastrService: ToastrService) {
    this.usersStore.init();
  }

  ngOnInit() {
    this.users$ = this.usersStore.getAll$();
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
    this.usersStore.update$(user.id, user).subscribe((u) => {
      this.toastrService.success(`${u.username} updated`);
    }, (error) => {
      this.toastrService.error(error.message);
    });
  }

  deleteUser(user: User) {
    this.usersStore.delete$(1).subscribe(this.success, this.error);
  }

  disableUser(user: User) {
    user.disabled = !user.disabled;
    this.usersStore.update$(user.id, user).subscribe(() => {
      this.toastrService.success('User disabled successfully.');
    });
  }
}