import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestTicketComponent } from './test-ticket.component';

describe('TestTicketComponent', () => {
  let component: TestTicketComponent;
  let fixture: ComponentFixture<TestTicketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestTicketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
