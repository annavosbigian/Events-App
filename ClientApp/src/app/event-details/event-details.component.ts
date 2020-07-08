import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NavigationExtras, ActivatedRoute, Router } from '@angular/router';
import { Event } from '../../event.model';
import { EventService } from '../../event.service';
import { ToastrService, ComponentPortal, Overlay } from 'ngx-toastr';
import { DataService } from '../../data.service';
import { GuestService } from '../../guest.service';
import { OverlayModule } from '@angular/cdk/overlay';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';


@Component({
    selector: 'app-event-details',
    templateUrl: './event-details.component.html',
    styleUrls: ['./event-details.component.css']
})
/** event-details component*/
export class EventDetailsComponent {
  @Input() event: Event;
  thumbnail: String;

    /** event-details ctor */
  constructor(private eventService: EventService, private toastr: ToastrService,
    private dataService: DataService, private guestService: GuestService,
    private router: Router, private route: ActivatedRoute, private modalService: NgbModal) {
    this.dataService.showData = false;
  }


  //photo popup
  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    }

    openInvite(){
      window.open(this.eventService.URL, '_blank');

    }

  //popuplates Create Event form with all the data and navigates to the page
  populateForm(realEvent: Event) {
    if (this.guestService.shortList.length > 0) {
      if (!confirm('Continue? This event already has confirmed guests.')) {
        return;
      }
    }
    this.eventService.eventData = Object.assign({}, realEvent);
    this.eventService.eventData.date = new Date(this.eventService.eventData.date);
    this.eventService.bool = true;
    this.router.navigate(['/edit'], { relativeTo: this.route });
  }

  //removes the event from database
  onDelete(eventId: number) {
    if (confirm('Are you sure you want to delete this event?')) {
      this.dataService.showData = false;
      this.eventService.deleteEvent(eventId)
        .subscribe(res => {
          this.eventService.refreshList();
          this.toastr.warning('Event deleted successfully', 'Event Registry');
        },
          err => {
            console.log(err);
          })
      this.event = null;
      this.guestService.showGuest = false;
    }
  }

}
