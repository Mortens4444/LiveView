import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import {NgIf} from '@angular/common';

@Component({
  imports: [NgIf],
  selector: 'app-camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.scss']
})
export class CameraComponent implements OnInit, OnDestroy {
  @ViewChild('videoElement', { static: false }) videoElement!: ElementRef<HTMLVideoElement>; // Videó elem referencia
  stream: MediaStream | null = null;

  constructor() { }

  ngOnInit(): void {
    this.startCamera();
  }

  ngOnDestroy(): void {
    this.stopCamera();
  }

  startCamera(): void {
    navigator.mediaDevices.getUserMedia({ video: true })
      .then((stream) => {
        this.stream = stream;
        if (this.videoElement) {
          this.videoElement.nativeElement.srcObject = stream;
        }
      })
      .catch((error) => {
        console.error('Hiba történt a kamera elérésében: ', error);
      });
  }

  stopCamera(): void {
    if (this.stream) {
      const tracks = this.stream.getTracks();
      tracks.forEach(track => track.stop()); // Minden track leállítása
      this.stream = null;
    }
  }
}
