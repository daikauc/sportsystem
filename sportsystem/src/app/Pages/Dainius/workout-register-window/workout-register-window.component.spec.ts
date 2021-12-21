import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkoutRegisterWindowComponent } from './workout-register-window.component';

describe('WorkoutRegisterWindowComponent', () => {
  let component: WorkoutRegisterWindowComponent;
  let fixture: ComponentFixture<WorkoutRegisterWindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkoutRegisterWindowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkoutRegisterWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
