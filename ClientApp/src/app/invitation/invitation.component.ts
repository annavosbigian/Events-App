import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Validators, FormGroup, FormControl } from '@angular/forms';
import { EventService } from '../../event.service';
import { Event } from '../../event.model';
import { GuestService } from '../../guest.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-invitation',
    templateUrl: './invitation.component.html',
    styleUrls: ['./invitation.component.css']
})
/** invitation component*/
export class InvitationComponent {
  event: Event;
  published: boolean;
  eventId: number;
  maxFriends: number;
  friendArray: number[];
  response: boolean;
  form: FormGroup;
  submit: boolean;

 
    /** invitation ctor */
  constructor(private route: ActivatedRoute,
    private eventService: EventService, private guestService: GuestService,
    //service for interacting with the browser
    private location: Location, private toastr: ToastrService) {
    this.response = true;
    /*this.form = new FormGroup({
      name: new FormControl('', Validators.minLength(5))
    })*/
  }

  ngOnInit(): void {
    this.resetForm();
    this.getEvent();
  }

  //Retreives event info from the database
  getEvent(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.eventId = id;
    this.eventService.getEvent(id)
      .subscribe((event: Event) => {
        this.event = event;
        this.makeFriendArray(event.friends);
        this.published = event.publish;
      });
      }
        

  /*openImgPath = (serverPath: string) => {
    return `/${serverPath}`;
  }*/


  //resets RSVP form
  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.guestService.guestData = {
      GuestId: 0,
      name: '',
      email: '',
      friends: 0,
      rsvp: '',
      message: '',
      eventId: this.eventId
    }
  }

  //validates input and submits the RSVP to the database
  onSubmit(form: NgForm) {
    this.submit = true;
    this.response = false;
    this.guestService.guestData.eventId = this.eventId;
    this.guestService.postGuest().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Thank you for your RSVP!', 'RSVP Registered');
        this.guestService.refreshList();
      },
      err => {
        console.log(err);
      })
  }

  //Creates array of numbers for the dropdown for confirmed guests to add extra friends, based on how many are allotted for specific event
  makeFriendArray(maxFriends: number) {
    this.friendArray = [0];
    for (let i = 1; i <= maxFriends; i++) {
      this.friendArray[i] = i;
    }
  }
}
