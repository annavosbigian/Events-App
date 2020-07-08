//<reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { GuestPageComponent } from './guest-page.component';

let component: GuestPageComponent;
let fixture: ComponentFixture<GuestPageComponent>;

describe('GuestPage component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ GuestPageComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(GuestPageComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
