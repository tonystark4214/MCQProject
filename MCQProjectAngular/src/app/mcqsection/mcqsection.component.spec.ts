import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MCQSectionComponent } from './mcqsection.component';

describe('MCQSectionComponent', () => {
  let component: MCQSectionComponent;
  let fixture: ComponentFixture<MCQSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MCQSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MCQSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
