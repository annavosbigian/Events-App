//<reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { UploadComponent } from './upload.component';

let component: UploadComponent;
let fixture: ComponentFixture<UploadComponent>;

describe('upload component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ UploadComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(UploadComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
