import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { CreditComponent }from './costumer/credit/credit.component'
import { SignInComponent } from './costumer/sign-in/sign-in.component';
import { SignUpComponent } from './costumer/sign-up/sign-up.component';
import { PersonalSpaceComponent } from './costumer/personal-space/personal-space.component';
import { HistoryParkingComponent }  from './costumer/history-parking/history-parking.component'
import { HomePageComponent } from './home-page/home-page.component';
import { RecommendationComponent } from './recommendation/recommendation.component';
import { OccupancyRatesComponent } from './occupancy-rates/occupancy-rates.component';

export const ROUTES: Route[] = [
  { path: "", redirectTo: "home page", pathMatch: "full"},
  { path: "home page", component: HomePageComponent},
  { path: "history", component: HistoryParkingComponent},
  { path: "signUp", component: SignUpComponent},
  { path: "signIn", component: SignInComponent},
  { path: "personal area", component: PersonalSpaceComponent},
  { path: "credit", component: CreditComponent},
  { path: "recommendation", component: RecommendationComponent},
  { path: "occupancy rates", component: OccupancyRatesComponent},
  //details/:id=====parameter sending
]
@NgModule({
  imports: [RouterModule.forRoot(ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule { }





