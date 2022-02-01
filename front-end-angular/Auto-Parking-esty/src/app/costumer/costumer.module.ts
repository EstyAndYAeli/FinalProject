import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreditComponent }from './credit/credit.component'
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { PersonalSpaceComponent } from './personal-space/personal-space.component';
import { HistoryParkingComponent }  from './history-parking/history-parking.component'

@NgModule({
  declarations: [ 
    HistoryParkingComponent,
    SignInComponent,
    SignUpComponent,
    CreditComponent,
    PersonalSpaceComponent],
  imports: [
   
    CommonModule
  ]
})
export class CostumerModule { }
