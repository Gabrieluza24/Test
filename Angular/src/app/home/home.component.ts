import { Component, OnInit } from '@angular/core';
import { filter, Observable, Subject } from 'rxjs';
import Swal from 'sweetalert2';
import { customer } from './interfaces/customer.dto';
import { HomeService } from './service/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public customer: customer | null = null;
  public customers$: Observable<customer[]>;
  public subject$: Subject<boolean> = new Subject<boolean>();

  constructor(private _customer: HomeService) {
    this.customers$ = this._customer.GetCustomers();
  }

  ngOnInit(): void {
    this.subject$.pipe(filter(s => s)).subscribe({ next: () => this.customers$ = this._customer.GetCustomers() });
  }

  public remove(id: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'Do you want to delete this record?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'yes, Delete!',
      cancelButtonText: 'No'
    }).then((result: any) => {
      if (result.value) {
        this._customer.DeleteCustomer(id).subscribe({
          next: () => {
            this.subject$.next(true);
            Swal.fire({
              title: 'Success',
              text: 'The customer was deleted successfully!',
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
        })
      }
    });
  }

  public openModal(name: string, content: customer | null) {
    this.customer = content;
    setTimeout(() => {
      const modal = new (window as any).bootstrap.Modal(document.getElementById(name));
      modal.show();
    });
  }

}
