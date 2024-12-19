import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TaxCalculatorService, TaxCalculationResult } from './tax-calculator.service';
import { environment } from '../../environments/environment';

describe('TaxCalculatorService', () => {
  let service: TaxCalculatorService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TaxCalculatorService],
    });

    service = TestBed.inject(TaxCalculatorService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should calculate tax by making a POST request', () => {
    const mockResult: TaxCalculationResult = {
      grossAnnualSalary: 60000,
      grossMonthlySalary: 5000,
      netAnnualSalary: 48000,
      netMonthlySalary: 4000,
      annualTaxPaid: 12000,
      monthlyTaxPaid: 1000,
    };

    service.calculateTax(60000).subscribe((result) => {
      expect(result).toEqual(mockResult);
    });

    const req = httpMock.expectOne(`${environment.apiUrl}TaxCalculator/calculate`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ grossSalary: 60000 });

    req.flush(mockResult);
  });
});
