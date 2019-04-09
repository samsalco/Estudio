import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MedicineComponent } from './components/medicine/medicine.component';
import { PatientsComponent } from './components/patients/patients.component';
import { LaboratoryComponent } from './components/laboratory/laboratory.component';
 
 
const APP_ROUTES: Routes = [
  { path: 'inicio', component: HomeComponent },
  { path: 'medicines/:id', component: MedicineComponent },
  { path: 'patients', component: PatientsComponent },
  { path: 'laboratory/:his', component: LaboratoryComponent},
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, { useHash: true });
