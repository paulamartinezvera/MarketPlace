
import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { CartComponent } from './cart/cart.component';
import { NavModule } from '../nav/nav.module';
import { ReduceTextPipe } from './reduce-text/reduce-text.pipe';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { MarketComponent } from './market/market.component';



@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    NavModule,
    PagesRoutingModule,
    FormsModule,
    RouterModule
  ],
  declarations: [
    PagesComponent,
    HomeComponent,
    CartComponent,
    LoginComponent,
    ReduceTextPipe,
    MarketComponent,
  ],
  exports: [
    PagesComponent,
    LoginComponent,
    HomeComponent
  ]
})
export class PagesModule { }

