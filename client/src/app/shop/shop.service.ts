import { Injectable } from '@angular/core';
import IPagination from "../shared/models/pagination";
import IProduct from "../shared/models/IProduct";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'
  constructor(private http: HttpClient) { }

  getProducts(): Observable<IPagination<IProduct>> {
    return this.http.get<IPagination<IProduct>>('https://localhost:5001/api/products?pageSize=10')
  }
}
