import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DesenvolvedorasComponent } from './components/paginas/desenvolvedoras/desenvolvedoras.component';
import { HomeComponent } from './components/paginas/home/home.component';
import { JogosComponent } from './components/paginas/jogos/jogos.component';

const routes: Routes = [
  {"path": '', component: HomeComponent },
  {"path": 'jogos', component: JogosComponent },
  {"path": 'desenvolvedoras', component: DesenvolvedorasComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
