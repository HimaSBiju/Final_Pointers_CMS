import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ALoginRoutingModule } from './a-login-routing.module';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    ALoginRoutingModule
  ]
})
export class ALoginModule { }
