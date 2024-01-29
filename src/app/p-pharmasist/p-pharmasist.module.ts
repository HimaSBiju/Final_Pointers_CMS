import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PPharmasistRoutingModule } from './p-pharmasist-routing.module';
import { PharmasistComponent } from './pharmasist/pharmasist.component';


@NgModule({
  declarations: [PharmasistComponent],
  imports: [
    CommonModule,
    PPharmasistRoutingModule
  ]
})
export class PPharmasistModule { }
