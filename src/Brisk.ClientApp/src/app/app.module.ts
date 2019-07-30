import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { library } from '@fortawesome/fontawesome-svg-core';

import { UsersService } from './core/services/users.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';

import { UserManagementComponent } from './user-management/user-management.component';
import { AuthenticateComponent } from './authenticate/authenticate.component';
import { QuoteManagementComponent } from './quote-management/quote-management.component';
import { NgSelectModule } from '@ng-select/ng-select';

import { AuthenticationInterceptor } from './core/interceptors/authentication.interceptor'
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { QuoteEditComponent } from './quote-edit/quote-edit.component';
import { PlayComponent } from './play/play.component';
import { MultipleChoiceComponent } from './multiple-choice/multiple-choice.component';
import { BinaryChoiceComponent } from './binary-choice/binary-choice.component';
import { QuoteComponent } from './quote/quote.component';
import { GameComponent } from './game/game.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    UserManagementComponent,
    AuthenticateComponent,
    QuoteManagementComponent,
    QuoteEditComponent,
    PlayComponent,
    MultipleChoiceComponent,
    BinaryChoiceComponent,
    QuoteComponent,
    GameComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    FontAwesomeModule,
    NgbModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    InfiniteScrollModule,
    NgSelectModule,
    ToastrModule.forRoot(),
    AppRoutingModule
  ],
  providers: [
    UsersService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
    library.add(fas);
  }
}
