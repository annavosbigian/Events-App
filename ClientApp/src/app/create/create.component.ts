import { Component} from '@angular/core';
import { EventService } from '../../event.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import * as moment from 'moment';
import { Router, ActivatedRoute } from '@angular/router';

/* Page for creating events: takes in all details and is linked with upload component for photo*/

@Component({
    selector: 'app-create',
    templateUrl: './create.component.html',
    styleUrls: ['./create.component.css']
})
/** create component*/
export class CreateComponent {
/** create ctor */
  showCal: boolean;
  response: { dbPath: '' };

  constructor(public eventService: EventService, private toastr: ToastrService,
    private router: Router, private route: ActivatedRoute) {
    this.showCal = false;

  }

  ngOnInit() {
    if (this.eventService.bool == true) {
      this.eventService.bool = false;
    }
    else {
      this.resetForm();
    }
  }

  //Toggle between whether the Invitation page will be visitble or not
  onPublish() {
    this.eventService.eventData.publish = !this.eventService.eventData.publish;
  }

  //takes in the image name from the Upload component output and saves it in eventData
  public uploadFinished = (event) => {
    this.eventService.eventData.imgPath = event;
  }

  //refreshes form
  resetForm(form?: NgForm) {
   if (form != null)
      form.resetForm();
      this.eventService.eventData = {
        eventId: 0,
        title: '',
        date: null,
        dateFormatted: null,
        locationName: '',
        address1: '',
        address2: '',
        details: '',
        publish: false,
        friends: 0,
        imgPath: '',
        id: ''
      }
  }

  //toggle between showing and hiding the calendar
  viewCal() {
    this.showCal = !this.showCal;;
  }

  /**
    Validates that a data has been selected
    Converts the time to a format readable by C#
    Checks whether it's a new form (eventId = 0) to create or an existing form to update
    Reroutes to the Events Management page
   */
  onSubmit(form: NgForm) {
    if (this.eventService.eventData.date == null) {
      alert("Please choose a time")
      return;
    }
    this.eventService.eventData.dateFormatted = moment(this.eventService.eventData.date).format('YYYY-MM-DDTHH:mm:SS');
    if (this.eventService.eventData.eventId == 0) {
      this.insertRecord(form);
    }
    else {
      this.updateRecord(form);
    }
    this.router.navigate(['/events'], { relativeTo: this.route });
  }

  //Sends the info to the Controler to create event in database
  insertRecord(form: NgForm) {
    this.eventService.postEvent().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Event created successfully', 'Event Detail Register');
        this.eventService.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

  //Sends the info to the Controller to update event in database
  updateRecord(form: NgForm) {
    this.eventService.putEvent().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Event updated successfully', 'Event Detail Register');
        this.eventService.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

}
