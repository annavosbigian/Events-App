import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Guest } from '../../guest';
import { GuestService } from '../../guest.service';


@Component({
  selector: 'app-guests',
  templateUrl: './guests.component.html',
  styleUrls: ['./guests.component.css']
})
/** guests component*/
export class GuestsComponent implements OnInit {
  @Input() eventId: number;
  //guests: Guest[];
  @Input() guests: Guest[];
  headerElements = ["Name", "RSVP", "Email", "Friends", "Message"];
  types = ["name", "rsvp", "email", "friends", "message"];
  emailList: string;

  /** guests ctor */
  constructor(private guestService: GuestService) {
  }

  ngOnInit() {
    this.guestService.getGuestEmails();
  }

  //shows names & emails of all confirmed guests for specific event
  showYesEmails() {
    var emailList = '';
    if (this.eventId > 0) {
      var allGuests = this.guestService.shortList;
      for (let guest of allGuests) {
        if (guest.rsvp === 'Yes') {
          emailList += '"' + guest.name + '"' + " ";
          emailList += guest.email + '; ';
        }
      }
      this.emailList = emailList;
    }
    this.guestService.showEmails = true;
    return emailList;
  }

}
