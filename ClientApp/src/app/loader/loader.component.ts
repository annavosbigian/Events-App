import { Component } from '@angular/core';
import { LoaderService } from '../../loader.service';
import { Subject } from 'rxjs';

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.css']
})
/** loader component*/
export class LoaderComponent {
/** loader ctor */
  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  isLoading: Subject<boolean> = this.loaderService.isLoading;

  constructor(private loaderService: LoaderService) {

    }
}
