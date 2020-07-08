//<reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { GuestsComponent } from './guests.component';

let component: GuestsComponent;
let fixture: ComponentFixture<GuestsComponent>;

describe('guests component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ GuestsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(GuestsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
