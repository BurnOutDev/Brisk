import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserManagementComponent } from './user-management/user-management.component';
import { AuthenticateComponent } from './authenticate/authenticate.component';
import { AuthenticationGuard } from './core/guards/authentication.guard';


const routes: Routes = [
  { path: 'user-management', component: UserManagementComponent, canActivate: [AuthenticationGuard] },
  { path: 'authenticate', component: AuthenticateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
