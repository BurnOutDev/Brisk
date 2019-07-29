import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserManagementComponent } from './user-management/user-management.component';
import { AuthenticateComponent } from './authenticate/authenticate.component';
import { AuthenticationGuard } from './core/guards/authentication.guard';
import { QuoteManagementComponent } from './quote-management/quote-management.component';


const routes: Routes = [
  { path: 'authenticate', component: AuthenticateComponent },
  { path: 'quote-management', component: QuoteManagementComponent, canActivate: [AuthenticationGuard] },
  { path: 'user-management', component: UserManagementComponent, canActivate: [AuthenticationGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
