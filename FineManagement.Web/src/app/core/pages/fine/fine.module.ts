import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

import { FineEntryComponent } from './fine-entry/fine-entry.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { FineListComponent } from './fine-list/fine-list.component';
import { ReportComponent } from './report/report.component';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [
    FineEntryComponent,
    FineListComponent,
    ReportComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    NgxDatatableModule,
    NgSelectModule
  ]
})
export class FineModule { }
