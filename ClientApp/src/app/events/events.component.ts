import { Component, OnInit } from '@angular/core';
import { Event } from '../../event.model';
import { EventService } from '../../event.service';
import { Guest } from '../../guest';
import { GuestService } from '../../guest.service';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  events: Event[];
  selectedEvent: Event;
  selectedEventId: number;
  guests: Guest[];
  emailList: string;


  constructor(public eventService: EventService, public guestService: GuestService, public dataService: DataService) {
    this.guestService.showGuest = false;
    
  }

  ngOnInit() {
    this.eventService.refreshList();
  }

  //when specific event is clicked, the event details appear and the guests and data are loaded
  onSelect(event: Event): void {
    this.guestService.getGuestByEvent(event.eventId);
    this.guests = this.guestService.shortList;
    this.selectedEvent = event;
    this.selectedEventId = event.eventId;
    this.guestService.showGuest = true;
    this.dataService.refreshData(this.selectedEventId);
    this.dataService.showData = false;
    this.eventService.URL = "events/" + event.eventId;

  }

}
