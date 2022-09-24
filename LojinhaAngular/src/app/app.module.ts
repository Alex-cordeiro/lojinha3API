import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopoComponent } from './components/topo/topo.component';
import { PainelComponent } from './components/painel/painel.component';
import { RodapeComponent } from './components/rodape/rodape.component';
import { HomeComponent } from './components/paginas/home/home.component';
import { JogosComponent } from './components/paginas/jogos/jogos.component';
import { DesenvolvedorasComponent } from './components/paginas/desenvolvedoras/desenvolvedoras.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MenuComponent } from './components/menu/menu.component';
//import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {NgxPaginationModule} from 'ngx-pagination';
import {MatSliderModule } from '@angular/material/slider';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatExpansionModule} from '@angular/material/expansion';

@NgModule({
  declarations: [
    AppComponent,
    TopoComponent,
    PainelComponent,
    RodapeComponent,
    HomeComponent,
    JogosComponent,
    DesenvolvedorasComponent,
    MenuComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    //FontAwesomeModule,
    NgxPaginationModule,
    MatSliderModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatExpansionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
