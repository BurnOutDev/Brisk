import { Component, OnInit } from '@angular/core';
import { User } from '../core/models/User.model';
import { Observable } from 'rxjs';
import { UsersStore } from '../core/stores/users.store';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {

  users$: Observable<User[]>;

  constructor(private usersStore: UsersStore) {
    this.usersStore.init();
  }

  ngOnInit() {
    this.users$ = this.usersStore.getAll$();
  }

  createUser(user: User) {
    this.usersStore.create$(user).subscribe(user => {
      console.log(`User created successfully.`);
    });
  }

  updateUser(user: User) {
    this.usersStore.update$(user.id, user).subscribe(() => {
      console.log(`User updated successfully.`);
    });
  }

  deleteUser(user: User) {
    this.usersStore.delete$(1).subscribe(() => {
      console.log(`User deleted successfully.`);
    });
  }

  disableUser(user: User) {
    user.disabled = !user.disabled;
    this.usersStore.update$(user.id, user).subscribe(() => {
      console.log(`User disabled successfully.`);
    });
  }
}