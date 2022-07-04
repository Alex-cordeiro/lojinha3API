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

@NgModule({
  declarations: [
    AppComponent,
    TopoComponent,
    PainelComponent,
    RodapeComponent,
    HomeComponent,
    JogosComponent,
    DesenvolvedorasComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
