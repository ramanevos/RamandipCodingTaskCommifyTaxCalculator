import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common'; // Import CommonModule for *ngIf

@Component({
  selector: 'app-tax-result',
  standalone: true,
  imports: [CommonModule], // Add CommonModule to imports
  templateUrl: './tax-result.component.html',
  styleUrls: ['./tax-result.component.scss']
})
export class TaxResultComponent {
  @Input() grossAnnualSalary?: number;
  @Input() grossMonthlySalary?: number;
  @Input() netAnnualSalary?: number;
  @Input() netMonthlySalary?: number;
  @Input() annualTaxPaid?: number;
  @Input() monthlyTaxPaid?: number;
}
