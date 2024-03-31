import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeOfertaComponent } from './home-oferta.component';

describe('HomeOfertaComponent', () => {
  let component: HomeOfertaComponent;
  let fixture: ComponentFixture<HomeOfertaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeOfertaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeOfertaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
