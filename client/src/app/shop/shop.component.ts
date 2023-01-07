import {Component, OnInit} from '@angular/core';
import IProduct from "../shared/models/IProduct";
import {ShopService} from "./shop.service";
import IProductBrand from "../shared/models/IProductBrand";
import IProductType from "../shared/models/IProductType";
import ShopParams from "../shared/models/shop-params";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[] = [];
  productsBrands: IProductBrand[] = [];
  productsTypes: IProductType[] = [];
  pages: number[] = [];
  productsCount = 0;
  paginationHeaderMsg = '';

  shopParams = new ShopParams();

  sortSelectOptions = [
    {name: 'Alphabetical', value: 'nameAsc'},
    {name: 'Alphabetical - Descending', value: 'nameDesc'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
  ]

  constructor(public shopService: ShopService) {

  }

  ngOnInit(): void {
    this.getProducts();
    this.getProductsBrands();
    this.getProductsTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (response) => {
        this.products = response.data;
        this.pages = [...Array(Math.ceil(response.count / response.pageSize) + 1).keys()].slice(1);
        this.shopParams.pageIndex = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.productsCount = response.count;
        // this.foo()
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
    this.shopParams.brandId = brandId;
    this.shopParams.pageIndex = 1;
    this.getProducts()
  }

  setTypeId(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageIndex = 1;
    this.getProducts()
  }

  sort(event: Event) {
    this.shopParams.sortSelected = (event.target as HTMLSelectElement).value
    this.getProducts();
  }

  onPageIndexSelected(index: number) {
    this.shopParams.pageIndex = index;
    this.getProducts();
    return false;
  }

  foo() {

    const pageIndex = this.shopParams.pageIndex
    const productsCount = this.productsCount;
    const pageSize = this.shopParams.pageSize >= productsCount ? productsCount : this.shopParams.pageSize;
    if (this.pages.length === 0) {
      this.paginationHeaderMsg = 'There are 0 results'
      return;
    }

    if (pageIndex === 1) {
      this.paginationHeaderMsg = `Showing 1-${pageSize} of ${productsCount}`
      return;
    }

    this.paginationHeaderMsg = `Showing ${(pageIndex - 1)*pageSize + 1} - ${pageIndex*pageSize} of ${productsCount}`
    return;
  }
}
