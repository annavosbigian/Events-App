import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../data.service';
import { GuestService } from '../../guest.service';
import { Guest } from '../../guest';
import { Data } from '../../data.model';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-data',
    templateUrl: './data.component.html',
    styleUrls: ['./data.component.css']
})
/** data component*/
export class DataComponent implements OnInit {
  @Input() eventId: number;
  responses: number;
  grandTotal: number;
  yeses: number;
  data: Data[];

    /** data ctor */
  constructor(public dataService: DataService, private guestService: GuestService) {
  }

  ngOnInit() {
    this.resetForm();
  }

  //puts the data on # of invitees back in the form to edit
  populateForm(data: Data) {
    this.dataService.formData = Object.assign({}, data);
  }
  
  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.dataService.formData = {
      id: 0,
      name: '',
      guests: 0,
      eventId: this.eventId
    }
  }

  //If the inviter is new, the grid gets a new line, otherwise, the invitee data is updated
  onSubmit(form?: NgForm) {
    if (this.dataService.formData.id == 0) {
      this.insertRecord(form);
    }
    else {
      this.updateRecord(form);
    }
    this.resetForm();
  }


  //removes inviter/invitee line and deletes from database
  onDelete(id: number) {
    if (confirm('Delete data?')) {
      this.dataService.deleteData(id)
        .subscribe(res => {
          this.dataService.refreshData(this.eventId);
 },
          err => {
            console.log(err);
          })
    }
  }

  //adds new inviter info to the database
  insertRecord(form: NgForm) {
    this.dataService.postData().subscribe(
      res => {
        //TRIAL from getData
        this.dataService.refreshData(this.eventId);
        this.resetForm(form);
     },
      err => {
        console.log(err);
      }
    )
  }

  //updates inviter info in database
  updateRecord(form: NgForm) {
    this.dataService.putData().subscribe(
      res => {
        this.dataService.refreshData(this.eventId);
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    )
  }

   

  }

