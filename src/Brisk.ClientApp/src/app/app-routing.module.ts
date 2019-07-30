import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserManagementComponent } from './user-management/user-management.component';
import { AuthenticateComponent } from './authenticate/authenticate.component';
import { AuthenticationGuard } from './core/guards/authentication.guard';
import { QuoteManagementComponent } from './quote-management/quote-management.component';
import { QuoteEditComponent } from './quote-edit/quote-edit.component';
import { PlayComponent } from './play/play.component';
import { BinaryChoiceComponent } from './binary-choice/binary-choice.component';
import { MultipleChoiceComponent } from './multiple-choice/multiple-choice.component';
import { SettingsComponent } from './settings/settings.component';


const routes: Routes = [
  { path: 'authenticate', component: AuthenticateComponent },
  { path: 'quote-management', component: QuoteManagementComponent, canActivate: [AuthenticationGuard] },
  { path: 'quote-edit/:id', component: QuoteEditComponent, canActivate: [AuthenticationGuard] },
  { path: 'user-management', component: UserManagementComponent, canActivate: [AuthenticationGuard] },
  { path: 'play', component: PlayComponent, canActivate: [AuthenticationGuard] },
  { path: 'binary-choice', component: BinaryChoiceComponent, canActivate: [AuthenticationGuard] },
  { path: 'multiple-choice', component: MultipleChoiceComponent, canActivate: [AuthenticationGuard] },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthenticationGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
