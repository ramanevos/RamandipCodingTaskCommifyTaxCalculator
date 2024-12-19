import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface TaxCalculationResult {
  grossAnnualSalary: number;
  grossMonthlySalary: number;
  netAnnualSalary: number;
  netMonthlySalary: number;
  annualTaxPaid: number;
  monthlyTaxPaid: number;
}

@Injectable({
  providedIn: 'root',
})
export class TaxCalculatorService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  calculateTax(salary: number): Observable<TaxCalculationResult> {
    return this.http.post<TaxCalculationResult>(`${this.apiUrl}TaxCalculator/calculate`, {
      grossSalary: salary,
    });
  }
}
