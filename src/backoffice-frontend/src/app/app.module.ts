import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { StatisticsServiceFake } from './services/statistics.service.fake';
import { StatisticsService } from './services/statistics.service';
import { GetApplicationRowsServiceFake } from './services/get-application-rows.service.fake';
import { GetApplicationRowsService } from './services/get-application-rows.service';
import { AppComponent } from './app.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { ApplicationTableComponent } from './application-table/application-table.component';
import { FriendlyHourPipe } from './shared/pipes/friendly-hour.pipe';


@NgModule({
  declarations: [
    AppComponent,
    StatisticsComponent,
    ApplicationTableComponent,
    FriendlyHourPipe
  ],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    HttpClientModule,
  ],
  providers: [
    { provide: StatisticsService, useClass: StatisticsServiceFake },
    { provide: GetApplicationRowsService, useClass: GetApplicationRowsServiceFake }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
