import {Component, OnInit} from '@angular/core';
import IProduct from "../shared/models/IProduct";
import {ShopService} from "./shop.service";
import IProductBrand from "../shared/models/IProductBrand";
import IProductType from "../shared/models/IProductType";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[] = [];
  productsBrands: IProductBrand[] = [];
  productsTypes: IProductType[] = [];
  brandId = 0
  typeId = 0

  constructor(public shopService: ShopService) {

  }

  ngOnInit(): void {
    this.getProducts();
    this.getProductsBrands();
    this.getProductsTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandId, this.typeId).subscribe({
      next: (response) => {
        this.products = response?.data ?? [] ;
      },
      error: err => {
        console.log(err);
      }
    })
  }

  getProductsBrands() {
    this.shopService.getProductsBrands().subscribe({
      next: (response) => {
        this.productsBrands = [{id: 0, name: 'All'}, ...response];
      },
      error: err => {
        console.log(err);
      }
    })
  }

  getProductsTypes() {
    this.shopService.getProductsTypes().subscribe({
      next: (response) => {
        this.productsTypes = [{id: 0, name: 'All'}, ...response];
      },
      error: err => {
        console.log(err);
      }
    })
  }

  setBrandId(brandId: number) {
    this.brandId = brandId;
    this.getProducts()
  }

  setTypeId(typeId: number) {
    this.typeId = typeId;
    this.getProducts()
  }
}
