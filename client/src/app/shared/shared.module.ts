import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FaIconLibrary, FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {
  faBagShopping as fasBagShopping,
  faShoppingCart as fasShoppingCart,
  faStar as fasStar
} from "@fortawesome/free-solid-svg-icons";
import {faStar as farStar} from "@fortawesome/free-regular-svg-icons";
import {faOpencart as fabOpencart, faReact as fabReact} from "@fortawesome/free-brands-svg-icons";
import {PaginationComponent} from "./components/pagination/pagination.component";
import { PaginationHeaderComponent } from './components/pagination-header/pagination-header.component';



@NgModule({
  declarations: [
    PaginationComponent,
    PaginationHeaderComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
  ],
  exports: [
    FontAwesomeModule,
    PaginationComponent,
    PaginationHeaderComponent
  ]
})
export class SharedModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(
      fasStar,
      farStar,
      fabReact,
      fabOpencart,
      fasBagShopping,
      fasShoppingCart);
  }
}
