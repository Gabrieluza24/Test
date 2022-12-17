import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HomeService } from '../../service/home.service';
import { Subject } from 'rxjs';
import Swal from 'sweetalert2';
import { formatDate } from '@angular/common';

declare var $: any;
@Component({
  selector: 'app-add-customer-dialog',
  templateUrl: './add-customer-dialog.component.html',
  styleUrls: ['./add-customer-dialog.component.scss']
})
export class AddCustomerDialogComponent implements OnInit {
  @Input() subject$!: Subject<boolean>;

  public form!: FormGroup;
  public today: string = formatDate(new Date(), 'yyyy-MM-dd', 'en-us');

  constructor(private fb: FormBuilder, private _customer: HomeService) {
  }

  ngOnInit(): void {
    this.createForm();
  }

  private createForm(): void {
    this.form = this.fb.group({
      fullname: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.pattern(/^(\+[1-9])?\d{6,15}$/)]],
      address: ['', [Validators.required, Validators.minLength(5)]],
      birthDate: ['', Validators.required]
    })
  }

  public onSubmit(): void {
    if (this.form.invalid) return;

    const body = { ...this.form.value, birthDate: new Date(this.form.value.birthDate).toJSON() }
    this._customer.CreateCustomer(body).subscribe({
      next: () => {
        this.closeModal();
        this.form.reset();
        this.subject$.next(true);
        Swal.fire({
          icon: 'success',
          title: 'Success',
          text: 'The customer was created successfully!',
          customClass: {
            confirmButton: 'btn btn-primary'
          },
        })
      },
      error: () => {
        Swal.fire({
          icon: 'error',
          title: '¡Error!',
          text: 'an error has occurred, please check!',
          customClass: {
            confirmButton: 'btn btn-primary'
          },
        });
      }
    });

  }

  public closeModal() {
    $('#add_customer').modal('hide');
  }
}
