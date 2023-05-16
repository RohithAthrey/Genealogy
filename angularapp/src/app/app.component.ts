import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isOpenHomeForm = true;
  isOpenAboutForm = false;
  isOpenRegisterForm = false;
  isOpenLoginForm = false;
  isOpenApproveForm = false;

  slides: string[];
  i: number;


  constructor(http: HttpClient) {
    this.i = 0;
    this.slides = [
      '../assets/BogandaPainting.jfif',
      '../assets/BogandaMap.jfif',
      '../assets/BogandaMuseum.jfif',
    ];
  }

  getSlide() {
    return this.slides[this.i];
  }

  getPrev() {
    this.i == 0 ? (this.i = this.slides.length - 1) : this.i--;
  }

  getNext() {
    this.i < this.slides.length - 1 ? this.i++ : (this.i = 0);
  }

  openHomeForm() {
    this.isOpenHomeForm = true;
    this.isOpenAboutForm = false;
    this.isOpenRegisterForm = false;
    this.isOpenLoginForm = false;
    this.isOpenApproveForm = false;
  }

  openAboutForm() {
    this.isOpenHomeForm = false;
    this.isOpenAboutForm = true;
    this.isOpenRegisterForm = false;
    this.isOpenLoginForm = false;
    this.isOpenApproveForm = false;
  }

  openRequestForm() {
    this.isOpenHomeForm = false;
    this.isOpenAboutForm = false;
    this.isOpenRegisterForm = true;
    this.isOpenLoginForm = false;
    this.isOpenApproveForm = false;
  }

  openLoginForm() {
    this.isOpenHomeForm = false;
    this.isOpenAboutForm = false;
    this.isOpenRegisterForm = false;
    this.isOpenLoginForm = true;
    this.isOpenApproveForm = false;
  }
  openApproveForm() {
    this.isOpenHomeForm = false;
    this.isOpenAboutForm = false;
    this.isOpenRegisterForm = false;
    this.isOpenLoginForm = false;
    this.isOpenApproveForm = true;
  }

  title = 'Boganda Genealogy';
}
