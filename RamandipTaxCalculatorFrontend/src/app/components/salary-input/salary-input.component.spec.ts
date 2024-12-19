import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SalaryInputComponent } from './salary-input.component';
import { ReactiveFormsModule } from '@angular/forms';

describe('SalaryInputComponent', () => {
  let component: SalaryInputComponent;
  let fixture: ComponentFixture<SalaryInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, SalaryInputComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SalaryInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fire calculateTax when form is valid and submitted', () => {
    spyOn(component.calculateTax, 'emit');

    // Set a valid grossSalary value in the form
    component.form.setValue({ grossSalary: 50000 });
    component.onSubmit();

    expect(component.calculateTax.emit).toHaveBeenCalledWith(50000);
  });

  it('should not fire calculateTax when form is invalid', () => {
    spyOn(component.calculateTax, 'emit');

    // Set an invalid grossSalary value in the form
    component.form.setValue({ grossSalary: -5000 });
    component.onSubmit();

    expect(component.calculateTax.emit).not.toHaveBeenCalled();
  });
});
