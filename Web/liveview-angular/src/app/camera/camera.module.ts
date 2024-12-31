import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CameraComponent } from './camera.component';

@NgModule({
  declarations: [
    CameraComponent  // A CameraComponent deklarálása
  ],
  imports: [
    CommonModule  // Használhatjuk a CommonModule-ot, hogy biztosítsuk az alap Angular direktívák működését (pl. *ngIf, *ngFor)
  ],
  exports: [
    CameraComponent  // A CameraComponent exportálása, hogy más modulok is használhassák
  ]
})
export class CameraModule { }
