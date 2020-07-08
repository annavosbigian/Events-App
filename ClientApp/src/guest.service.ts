import { Injectable } from '@angular/core';
import { Guest } from './guest';
import {HttpClient} from "@angular/common/http"
import { GuestEmail } from './guestemail.model';


@Injectable({
  providedIn: 'root'
})
export class GuestService {
  guestData: Guest;
  shortList: Guest[];
  guestList: Guest[];
  emails: GuestEmail[];
  eventId: number;
  responses: number;
  grandTotal: number;
  yeses: number;
  showGuest: boolean;
  showEmails: boolean;

  readonly rootURL = '/Events/api';
  //readonly rootURL = '/api';

    constructor(private http: HttpClient) {

  }


  //retrieves guests from specific event
  getGuestByEvent(eventId: number) {
    if (eventId == null) {
      return;
    }
    else {
      this.http.get(this.rootURL + '/Guests/eventId/' + eventId)
        .subscribe(
          result => {
            this.shortList = result as Guest[];
          });
    }
  }

  postGuest() {
    return this.http.post(this.rootURL + '/Guests', this.guestData);     
  }

  getGuests() {
    this.http.get(this.rootURL + '/Guests')
      .subscribe(
        result => {
          this.guestList = result as Guest[];
        });
  }

  //retrieves distinct guest emails
  getGuestEmails() {
    return this.http.get(this.rootURL + '/Guests/email')
      .subscribe(
        result => {
          this.emails = result as GuestEmail[];
        });
  }

  refreshList() {
    return this.http.get(this.rootURL + '/Guests')
      .subscribe(
        result => {
          this.guestList = result as Guest[];
        });
  }

 
  }

