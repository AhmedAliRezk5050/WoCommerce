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



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FontAwesomeModule,
  ],
  exports: [FontAwesomeModule]
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
