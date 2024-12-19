import { Component, EventEmitter, Output } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-salary-input',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './salary-input.component.html',
  styleUrls: ['./salary-input.component.scss']
})
export class SalaryInputComponent {
  @Output() calculateTax = new EventEmitter<number>();
  form: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      grossSalary: [null, [Validators.required, Validators.min(0)]],
    });
  }

  onSubmit() {
    if (this.form.valid) {
      this.calculateTax.emit(this.form.value.grossSalary);
    }
  }
}
