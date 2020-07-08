import { Component, OnInit } from '@angular/core';
import { GuestService } from '../../guest.service';
import { Guest } from '../../guest';
import { EventService } from '../../event.service';
import { Event } from '../../event.model';


@Component({
    selector: 'app-guest-page',
    templateUrl: './guest-page.component.html',
    styleUrls: ['./guest-page.component.css']
})
/** GuestPage component*/
export class GuestPageComponent implements OnInit {
  guests: Guest[];
  csv: string;
  emailList: string;
  csv2: string;
  headerElements = ["Name", "RSVP", "Email", "Event", "Friends", "Message"];
  showAll: boolean;
  selectedEventId: number;
  eventTitle: string;


    /** GuestPage ctor */
  constructor(public guestService: GuestService, public eventService: EventService) {
    this.eventService.refreshList();
    this.showAll = true;
    this.eventTitle = null;
    this.guestService.showEmails = false;
  }

  ngOnInit() {
    this.guestService.getGuests();
    this.guestService.getGuestEmails() 
    } 

  //shows distinct names & emails of all guests who have rsvped to any event
  showEmails() {
    var emailList = '';
      var emailList = '';
      var emails = this.guestService.emails;
      for (let email of emails) {
        emailList += '"' + email.name + '"' + " ";
        emailList += email.email + '; ';
      }
    this.emailList = emailList;
    this.guestService.showEmails = true;

    }

  onSelect(event: Event): void {
    this.guestService.getGuestByEvent(event.eventId);
    this.selectedEventId = event.eventId;
    this.eventTitle = event.title;
    this.guestService.showGuest = true;
    this.guestService.showEmails = false;

  }
}

