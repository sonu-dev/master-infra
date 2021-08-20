import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.cmponent';
import { LoginComponent } from './login/login.component';
import { AuthGuardService } from './shared/services/auth-gaurd.service';
import { AuthenticationService } from './shared/services/authentication.service';
import { UserService } from './shared/services/user.service';
import { FakeBackendProvider } from './shared/interceptors/fake.backend.interceptor';
import { JwtTokenProvider } from './shared/interceptors/jwt.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [
    AuthGuardService,
    AuthenticationService,
    UserService,
    JwtTokenProvider,
    FakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
