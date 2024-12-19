import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TaxResultComponent } from './tax-result.component';
import { CommonModule } from '@angular/common';

describe('TaxResultComponent', () => {
  let component: TaxResultComponent;
  let fixture: ComponentFixture<TaxResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommonModule, TaxResultComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(TaxResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should display tax results when inputs are provided', () => {
    // Set input properties
    component.grossAnnualSalary = 60000;
    component.grossMonthlySalary = 5000;
    component.netAnnualSalary = 48000;
    component.netMonthlySalary = 4000;
    component.annualTaxPaid = 12000;
    component.monthlyTaxPaid = 1000;

    // Trigger change detection
    fixture.detectChanges();

    // Get the rendered DOM element
    const compiled = fixture.nativeElement as HTMLElement;

    // Query all rendered <p> elements
    const paragraphs = compiled.querySelectorAll('p');

    // Assert that the correct text is rendered in each <p> element
    expect(paragraphs[0].textContent).toContain('Gross Annual Salary: 60000');
    expect(paragraphs[1].textContent).toContain('Gross Monthly Salary: 5000');
    expect(paragraphs[2].textContent).toContain('Net Annual Salary: 48000');
    expect(paragraphs[3].textContent).toContain('Net Monthly Salary: 4000');
    expect(paragraphs[4].textContent).toContain('Annual Tax Paid: 12000');
    expect(paragraphs[5].textContent).toContain('Monthly Tax Paid: 1000');
  });

  it('should not display results when grossAnnualSalary is undefined', () => {
    // Set input property to undefined
    component.grossAnnualSalary = undefined;

    // Trigger change detection
    fixture.detectChanges();

    // Check that the header and results are not rendered
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h2')).toBeNull();
  });
});
