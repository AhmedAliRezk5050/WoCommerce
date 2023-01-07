import {Injectable} from '@angular/core';
import IPagination from "../shared/models/IPagination";
import IProduct from "../shared/models/IProduct";
import {HttpClient, HttpParams} from "@angular/common/http";
import {map, Observable} from "rxjs";
import IProductBrand from "../shared/models/IProductBrand";
import IProductType from "../shared/models/IProductType";
import ShopParams from "../shared/models/shop-params";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'
  constructor(private http: HttpClient) {
  }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if(shopParams.brandId) {
      params = params.append('brandId', shopParams.brandId);
    }

    if(shopParams.typeId) {
      params = params.append('typeId', shopParams.typeId);
    }

    params = params.append('sort', shopParams.sortSelected)

    params = params.append('pageIndex', shopParams.pageIndex)

    return this.http.get<IPagination<IProduct>>(`${this.baseUrl}products`, {
      params
    })
  }

  getProductsBrands(): Observable<IProductBrand[]> {
    return this.http.get<IProductBrand[]>(`${this.baseUrl}ProductTypes`)
  }

  getProductsTypes(): Observable<IProductType[]> {
    return this.http.get<IProductType[]>(`${this.baseUrl}ProductBrands`)
  }
}
