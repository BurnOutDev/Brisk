import { Component, OnInit } from '@angular/core';
import { User } from '../core/models/User.model';
import { Observable, BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';
import { UsersService } from '../core/services/users.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {

  users$: BehaviorSubject<User[]>;

  filter: string;
  usersCount: number;
  
  collapsed: boolean[] = new Array(2000);

  constructor(
    private usersService: UsersService,
    private toastrService: ToastrService) {
      this.users$ = new BehaviorSubject<User[]>(undefined);
      this.usersCount = 0;
  }

  ngOnInit() {
    this.usersService.getPaginatedAndFiltered$(0).subscribe(
      (user) => {
        this.users$.next(user);
      }
    );
  }

  success() {
    this.toastrService.success("Success");
  }

  error() {
    this.toastrService.error("Error");
  }

  createUser() {
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

  onFilterChange() {
    this.usersService.getPaginatedAndFiltered$(0, this.filter).subscribe(
      (quote) => {
        this.users$.next(quote);
      }
    );
  }

  loadMore() {
    this.usersService.getPaginatedAndFiltered$(this.usersCount, this.filter).subscribe(
      (quote) => {
        this.users$.next(quote);
        this.usersCount *= environment.defaultTake;
      });
  }
}