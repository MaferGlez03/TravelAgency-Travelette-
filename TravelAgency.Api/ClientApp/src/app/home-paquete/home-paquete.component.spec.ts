import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomePaqueteComponent } from './home-paquete.component';

describe('HomePaqueteComponent', () => {
  let component: HomePaqueteComponent;
  let fixture: ComponentFixture<HomePaqueteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomePaqueteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomePaqueteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
