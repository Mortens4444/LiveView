import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { CameraComponent } from './camera/camera.component'; // Importáljuk a CameraComponent-et
import { CameraModule } from './camera/camera.module'; // Importáljuk a CameraComponent-et

@NgModule({
  declarations: [
    AppComponent,
    CameraComponent
  ],
  imports: [
    BrowserModule,
    CameraModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
