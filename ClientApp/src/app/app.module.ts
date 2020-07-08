import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
//import { HttpClient } from "@angular/common/http"
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { EventsComponent } from './events/events.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { InvitationComponent } from './invitation/invitation.component';
import { CreateComponent } from './create/create.component';
import { GuestsComponent } from './guests/guests.component';
import { DataComponent } from './data/data.component';
import { UploadComponent } from './upload/upload.component';
import { LoaderComponent } from './loader/loader.component';
import { GuestPageComponent } from './guest-page/guest-page.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EventService } from '../event.service';
import { GuestService } from '../guest.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
import { DataTablesModule } from 'angular-datatables';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoaderService } from '../loader.service';
import { LoaderInterceptor } from './Interceptors/loader.interceptor';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EventsComponent,
    GuestsComponent,
    EventDetailsComponent,
    DataComponent,
    InvitationComponent,
    UploadComponent,
    CreateComponent,
    GuestPageComponent,
    LoaderComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    //HttpClient,
    BrowserModule,
    MatProgressSpinnerModule,
    FormsModule,
    NgbModule,
    DlDateTimeDateModule,  // <--- Determines the data type of the model
    DlDateTimePickerModule,
    FontAwesomeModule,
    DataTablesModule,
    MatIconModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'events', pathMatch: 'full' },
      { path: 'events', component: EventsComponent},
      { path: 'create', component: CreateComponent },
      { path: 'edit', component: CreateComponent },
      { path: 'events/:id', component: InvitationComponent },
      { path: 'guests', component: GuestPageComponent },
      { path: '**', component: PageNotFoundComponent }
    ])
  ],
  providers: [EventService, GuestService, LoaderService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
