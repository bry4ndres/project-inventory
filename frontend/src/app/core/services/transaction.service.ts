import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Transaction } from "../models/transaction.model";
import { Observable } from "rxjs";
import { environment } from "../../enviroments/environment";

@Injectable({ providedIn: 'root' })
export class TransactionService {
  private readonly baseUrl = `${environment.apiTransactionsUrl}`

  constructor(private http: HttpClient) {}

  getAll(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(this.baseUrl);
  }

  getById(id: number): Observable<Transaction> {
    return this.http.get<Transaction>(`${this.baseUrl}/${id}`);
  }

  create(transaction: Transaction): Observable<any> {
    return this.http.post(this.baseUrl, transaction);
  }

  update(transaction: Transaction): Observable<any> {
    return this.http.put(`${this.baseUrl}`, transaction);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
