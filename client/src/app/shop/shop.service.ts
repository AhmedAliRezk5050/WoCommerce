import { Injectable } from '@angular/core';
import IPagination from "../shared/models/IPagination";
import IProduct from "../shared/models/IProduct";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import IProductBrand from "../shared/models/IProductBrand";
import IProductType from "../shared/models/IProductType";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'
  constructor(private http: HttpClient) { }

  getProducts(): Observable<IPagination<IProduct>> {
    return this.http.get<IPagination<IProduct>>(`${this.baseUrl}products?pageSize=10`)
  }

  getProductsBrands(): Observable<IProductBrand[]> {
    return this.http.get<IProductBrand[]>(`${this.baseUrl}ProductTypes`)
  }

  getProductsTypes(): Observable<IProductType[]> {
    return this.http.get<IProductType[]>(`${this.baseUrl}ProductBrands`)
  }
}
