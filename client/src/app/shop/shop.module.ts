import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ShopComponent} from './shop.component';
import {ShopRoutingModule} from "./shop-routing.module";
import {ProductItemComponent} from './product-item/product-item.component';
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {SharedModule} from "../shared/shared.module";


@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent
  ],
  exports: [
    ShopComponent
  ],
    imports: [
        CommonModule,
        ShopRoutingModule,
        FontAwesomeModule,
        SharedModule,

    ]
})
export class ShopModule {
}
