import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RecommendationComponent } from './recommendation/recommendation.component';
import { AboutComponent } from './about/about.component';
import { OccupancyRatesComponent } from './occupancy-rates/occupancy-rates.component';
import { CostumerModule } from '../app/costumer/costumer.module'
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    RecommendationComponent,
    AboutComponent,
    OccupancyRatesComponent
  ],
  imports: [
    BrowserModule,
    CostumerModule,
    // RouterModule,
    // RouterModule.forRoot([]),
    AppRoutingModule,
  ],
  providers: [],
  // HomePageComponent AppComponent
  bootstrap: [HomePageComponent]
})
export class AppModule { }
