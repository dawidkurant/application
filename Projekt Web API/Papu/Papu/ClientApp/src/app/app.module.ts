import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ProductsModule } from './products/products.module';
import { DishesModule } from './dishes/dishes.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ListComponent } from "./products/list/list.component";
import { ListDishesComponent } from "./dishes/list/listDishes.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { AuthService } from "./services/auth.service";
import { NationalitiesService } from './register/nationalities.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { AuthGuardService } from './services/auth-guard.service';
import { ProductsService } from './products/products.service';
import { DishesService } from './dishes/dishes.service';

import { NgxPaginationModule } from 'ngx-pagination';
import { ErrorInterceptorService } from './services/error-interceptor.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    ProductsModule,
    DishesModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'product', component: ListComponent },
      { path: 'dish', component: ListDishesComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ]),
  ],
  providers: [
    AuthService,
    ProductsService,
    DishesService,
    NationalitiesService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
