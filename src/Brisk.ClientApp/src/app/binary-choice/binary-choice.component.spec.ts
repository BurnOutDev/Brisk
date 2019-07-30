import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BinaryChoiceComponent } from './binary-choice.component';

describe('BinaryChoiceComponent', () => {
  let component: BinaryChoiceComponent;
  let fixture: ComponentFixture<BinaryChoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BinaryChoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BinaryChoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
