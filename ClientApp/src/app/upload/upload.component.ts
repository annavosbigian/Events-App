import { Component, Output, EventEmitter, OnInit, Input } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { EventService } from '../../event.service';

@Component({
    selector: 'app-upload',
    templateUrl: './upload.component.html',
    styleUrls: ['./upload.component.css']
})

/** Child component of Create events page - lets user upload a photo for the event to the img folder*/

export class UploadComponent {
  public progress: number;
  public message: string;
  public imgPath: string;
  @Input() image: string;
  @Output() public onUploadFinished = new EventEmitter();

  readonly rootURL = 'api/Upload';

/** upload ctor */

  constructor(private http: HttpClient, public eventService: EventService) {
    /*if (this.eventService.eventData) {
      if (this.eventService.eventData.imgPath) {
        this.image = this.eventService.openImgPath(this.eventService.eventData.imgPath);
      }
    }*/
    this.imgPath = this.image;
  }

  //Sends file to Controller to be added to the img folder & outputs the name of the image
  public uploadFile = (files) => {
    console.log("step 1" + this.eventService.eventData.imgPath);
    if (files.length === 0) {
      return;
    }
    console.log("step 2" + this.eventService.eventData.imgPath);

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post(this.rootURL, formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.message = 'Loading';
          //this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          //console.log('stringify ' + JSON.stringify(event.body));
          this.message = 'Upload complete';
          //PHOTO
         // console.log("upload: event body is: " + fileToUpload.name);
          //this.onUploadFinished.emit(JSON.stringify(event.body));
          this.onUploadFinished.emit(fileToUpload.name);
        }
      });
    console.log("step 3" + this.eventService.eventData.imgPath);

  }

  //Deletes image from the folder and removes name from eventData info
  deleteImg() {
    this.message = "Removing image";
    console.log("image path is" + this.eventService.eventData.imgPath);
    if (confirm('Are you sure you want to delete this photo?')) {
      this.http.delete(this.rootURL + "/" + this.eventService.eventData.imgPath)
        .subscribe
        (
          res => {
            console.log("here!")
            this.message = "Image removed";
          });
      this.eventService.eventData.imgPath = null;
    }
  }

  getImage() {
    return this.imgPath;
  }
}

