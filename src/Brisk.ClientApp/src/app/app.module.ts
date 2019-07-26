import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
// import { faList, faQuoteRight, faBorderAll, faSave, faTrash, faPlus, faUser, faTimes, faUserLock, faGamepad } from '@fortawesome/free-solid-svg-icons';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { library } from '@fortawesome/fontawesome-svg-core';
import { UserManagementComponent } from './user-management/user-management.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    UserManagementComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    NgbModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
    // library.add(faList, faGamepad, faQuoteRight, faBorderAll, faSave, faTrash, faPlus, faUser, faTimes, faUserLock);
    library.add(fas);
  }
}
