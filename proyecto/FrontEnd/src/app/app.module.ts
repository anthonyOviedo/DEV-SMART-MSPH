// Angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AgmCoreModule } from '@agm/core';



// Routes
import { APP_ROUTES } from './app.routes';

// Modules
import { ServiceModule } from './services/service.module';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



// Components 
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { PagesComponent } from './pages/pages.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

// Services
import { UsuarioService, HttphInterceptorService } from './services/service.index';





@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PagesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    APP_ROUTES,
    FormsModule,
    ReactiveFormsModule,
    ServiceModule,
    NgbModule,
    SharedModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDCLVmvVTac-g7KgAUv0pDpmGxoUS-aVsI'
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttphInterceptorService,
      multi: true,
      deps: [ UsuarioService ]
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
