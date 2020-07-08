import { Injectable } from '@angular/core';
import { Event } from './event.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class EventService {
  eventData: Event;
  list: Event[];
  bool: boolean;
  currentImg: string;
  showEvent: boolean;
  URL: string;

  readonly rootURL = '/Events/api';
  //readonly rootURL = '/api';

  constructor(private http: HttpClient) {
  }

  getName(eventId: number) {
    for (let event of this.list) {
      if (event.eventId == eventId) {
        return event.title;
      }
    }
  }

  postEvent() {
    return this.http.post(this.rootURL + '/Events', this.eventData);
  }

  putEvent() {
    return this.http.put(this.rootURL + '/Events/' + this.eventData.eventId, this.eventData);
  }

  getEvent(id: number) {
    return this.http.get(this.rootURL + '/Events/' + id);
  }

  deleteEvent(id: number) {
    this.http.delete(this.rootURL + "/" + this.eventData.imgPath);
    return this.http.delete(this.rootURL + '/Events/' + id);
  }


  refreshList() {
    this.http.get(this.rootURL + '/Events')
      .subscribe(
        result => {
          this.list = result as Event[];
        });
  }

  //returns folder path to specified image
  openImgPath(path: string) {
    this.currentImg = "assets/img/" + path;
    //This path also works
    //this.currentImg = "/Events/assets/img/" + path;
    console.log("img 1 " + this.currentImg);
    return this.currentImg;
  }

}
