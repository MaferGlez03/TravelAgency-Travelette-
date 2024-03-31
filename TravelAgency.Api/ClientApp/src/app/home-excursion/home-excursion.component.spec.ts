import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeExcursionComponent } from './home-excursion.component';

describe('HomeExcursionComponent', () => {
  let component: HomeExcursionComponent;
  let fixture: ComponentFixture<HomeExcursionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeExcursionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeExcursionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
