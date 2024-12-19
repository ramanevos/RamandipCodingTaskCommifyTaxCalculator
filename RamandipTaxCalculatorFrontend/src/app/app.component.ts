import { Component } from '@angular/core';
import { SalaryInputComponent } from './components/salary-input/salary-input.component';
import { TaxResultComponent } from './components/tax-result/tax-result.component';
import { TaxCalculatorService } from './services/tax-calculator.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, SalaryInputComponent, TaxResultComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [TaxCalculatorService]
})
export class AppComponent {
  result: any;

  constructor(private taxService: TaxCalculatorService) {}

  onCalculateTax(grossSalary: number) {
    this.taxService.calculateTax(grossSalary).subscribe((res) => {
      this.result = res;
    });
  }
}
