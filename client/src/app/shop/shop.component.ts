import {Component, OnInit} from '@angular/core';
import IProduct from "../shared/models/IProduct";
import {ShopService} from "./shop.service";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[] = [];


  constructor(private shopService: ShopService) {
  }

  ngOnInit(): void {
    this.shopService.getProducts().subscribe({
      next: (response) => {
        this.products = response.data;
      },
      error: err => {
        console.log(err);
      }
    })
  }
}
