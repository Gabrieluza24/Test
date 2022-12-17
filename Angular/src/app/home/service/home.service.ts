import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { customer } from '../interfaces/customer.dto';
import { environment } from 'src/environments/environment';
import { customerRequest } from '../interfaces/customer-request.dto';


@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  public GetCustomers(): Observable<customer[]> {
    return this.http.get<customer[]>(`${environment.apiServer}/api/Customer`);
  }

  public CreateCustomer(body: customerRequest): Observable<customer> {
    return this.http.post<customer>(`${environment.apiServer}/api/Customer`, body);
  }

  public UpdateCustomer(id: number, body: customerRequest): Observable<customer> {
    return this.http.put<customer>(`${environment.apiServer}/api/Customer/${id}`, body);
  }

  public DeleteCustomer(id: number): Observable<customer> {
    return this.http.delete<customer>(`${environment.apiServer}/api/Customer/${id}`);
  }

}
