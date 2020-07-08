import { Injectable } from '@angular/core';
import { Data } from './data.model';
import { GuestService } from './guest.service';
import { Guest } from './guest';
import { HttpClient } from "@angular/common/http"
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { EventService } from './event.service';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  data: Data[];
  shortData: Data[];
  guests: Guest[];
  responses: number;
  grandTotal: number;
  yeses: number;
  showData: boolean;
  formData: Data;
  data$: Observable<Data[]>;

  readonly rootURL = '/Events/api';
  //readonly rootURL = '/api';

  constructor(private guestService: GuestService, private http: HttpClient, private eventService: EventService) {
    this.guestService.getGuests();
  }

  ngOnInit() {
  }

  postData() {
    return this.http.post(this.rootURL + '/Data', this.formData);      
  }

  putData() {
    return this.http.put(this.rootURL + '/Data/' + this.formData.id, this.formData);      

  }

  deleteData(id: number) {
    return this.http.delete(this.rootURL + '/Data/' + id);
  }

  openData() {
    this.getGuestNumbers();
    this.showData = true;
  }

  returnEvent() {
    this.showData = false;
  }
  
  getData(eventId: number): Observable<Data[]> {
    return this.http.get<Data[]>(this.rootURL + '/Data/DatabyEventId/' + eventId)
      .pipe(
        catchError(this.handleError<Data[]>('getData'))
      );
  }

  refreshData(eventId: number) {
    this.getData(eventId).subscribe(
      result => {
        this.shortData= result as Data[];
      });
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getTotal() {
    var count = 0;
    for (let sender of this.shortData) {
      count += sender.guests;
    }
    return count;
  }

    //Calculates data on guests who have responded: total responses, total yeses and total yeses plus their additional guests (when applicable)
  getGuestNumbers() {
    var responses = 0;
    var yeses = 0;
    var grandTotal = 0;
    var guests = this.guestService.shortList;
    for (let guest of guests) {
      responses++;
      if (guest.rsvp == 'Yes') {
        yeses++;
        grandTotal += guest.friends + 1;
      }
    }
    this.responses = responses;
    this.yeses = yeses;
    this.grandTotal = grandTotal;
  }
}
