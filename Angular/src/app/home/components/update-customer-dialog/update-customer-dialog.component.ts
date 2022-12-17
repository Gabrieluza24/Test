import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { customer } from '../../interfaces/customer.dto';
import { HomeService } from '../../service/home.service';
import { Subject } from 'rxjs';
import Swal from 'sweetalert2';
import { formatDate } from '@angular/common';

declare var $: any;

@Component({
  selector: 'app-update-customer-dialog',
  templateUrl: './update-customer-dialog.component.html',
  styleUrls: ['./update-customer-dialog.component.scss']
})
export class UpdateCustomerDialogComponent implements OnInit, OnChanges {
  @Input() subject$!: Subject<boolean>;
  @Input() customer!: customer | null;

  public form!: FormGroup;
  public today: string = formatDate(new Date(), 'yyyy-MM-dd', 'en-us');

  constructor(private fb: FormBuilder, private _customer: HomeService) {
  }

  ngOnInit(): void {
    this.createForm();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.createForm();
  }

  private createForm(): void {
    this.form = this.fb.group({
      fullname: [this.customer?.fullname, [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      email: [this.customer?.email, [Validators.required, Validators.email]],
      phone: [this.customer?.phone, [Validators.required, Validators.pattern(/^(\+[1-9])?\d{6,15}$/)]],
      address: [this.customer?.address, [Validators.required, Validators.minLength(5)]],
      birthDate: [formatDate(this.customer?.birthDate ?? new Date(), 'yyyy-MM-dd', 'en-us'), Validators.required]
    })
  }

  public onSubmit(): void {
    if (this.form.invalid) return;

    const body = { ...this.form.value, birthDate: new Date(this.form.value.birthDate).toJSON() }
    this._customer.UpdateCustomer(this.customer!.id, body).subscribe({
      next: () => {
        this.closeModal();
        this.subject$.next(true);
        Swal.fire({
          title: 'Success',
          text: 'The customer was updated successfully!',
          icon: 'success'
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
    $('#update_customer').modal('hide');
  }
}
