import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome'

import {FaIconLibrary} from '@fortawesome/angular-fontawesome';
import {faStar as farStar} from '@fortawesome/free-regular-svg-icons';
import {
  faStar as fasStar,
  faBagShopping as fasBagShopping,
  faShoppingCart as fasShoppingCart
} from '@fortawesome/free-solid-svg-icons';
import {faReact as fabReact, faOpencart as fabOpencart} from '@fortawesome/free-brands-svg-icons';
import {NavBarComponent} from './nav-bar/nav-bar.component'

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
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
