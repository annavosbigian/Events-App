//<reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { InvitationComponent } from './invitation.component';

let component: InvitationComponent;
let fixture: ComponentFixture<InvitationComponent>;

describe('invitation component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ InvitationComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(InvitationComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
