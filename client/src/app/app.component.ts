import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import IProduct from "./models/IProduct";
import IPagination from "./models/pagination";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Wo Commerce';

  products: IProduct[] = []

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http.get<IPagination<IProduct>>('https://localhost:5001/api/products?pageSize=10').subscribe({
      next: response => {
        this.products = response.data;
      },
      error: err => {
        console.log(err)
      }
    })
  }
}
