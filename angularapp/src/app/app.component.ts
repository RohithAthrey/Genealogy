import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from './services/register.service';
import { Gender } from './models/gender.model';
import { Clan } from './models/clan.model';
import APIEndpoints from './constants/APIEndpoints';
import { ClanHouse } from './models/clanHouse.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //isOpenHomeForm = true;
  //isOpenAboutForm = false;
  //isOpenRegisterForm = false; 
  //isOpenLoginForm = false;
  //isOpenApproveForm = false;

  slides: string[];
  i: number;
  roleId: number;



  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
    this.i = 0;
    this.slides = [
      '../assets/BogandaPainting.jfif',
      '../assets/BogandaMap.jfif',
      '../assets/BogandaMuseum.jfif',
    ];
    this.roleId = 0;

    this.registerService.isOpenHomeForm = true;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;

  }

  ngOnInit() {
    this.httpClient.get<Gender[]>(APIEndpoints.GET_ALL_GENDERS)
      .subscribe(response => {
        this.registerService.allGenders = response;
        this.registerService.allGenders.unshift({ 'genderID': 0, 'genderCode': 'N/A', 'genderValue': '---Select---' });
        console.log(this.registerService.allGenders);
      })

    this.httpClient.get<Clan[]>(APIEndpoints.GET_ALL_CLANS)
      .subscribe(result => {
        this.registerService.allClans = result;
        this.registerService.allClans.unshift({ 'clanID': 0, 'name': '---Select---', 'symbol': 'N/A', 'subTotem': 'N/A' });
        console.log(this.registerService.allClans);
      })
    this.httpClient.get<ClanHouse[]>(APIEndpoints.GET_ALL_CLAN_HOUSES)
      .subscribe(returned => {
        this.registerService.allClanHouse = returned;
        this.registerService.allClans?.forEach( (value) => {
          this.registerService.allClanHouse?.unshift({ 'clanID': value.clanID, 'clanHouseName': '---Select---', 'clanHouseID': 0 });
        });
        //this.registerService.allClanHouse.unshift({ 'clanID': 0, 'clanHouseName': '---Select---', 'clanHouseID': 0 });
        //this.registerService.allClanHouse.unshift({ 'clanID': 1, 'clanHouseName': '---Select---', 'clanHouseID': 0 });
        //this.registerService.allClanHouse.unshift({ 'clanID': 0, 'clanHouseName': '---Select---', 'clanHouseID': 0 });
        console.log(this.registerService.allClanHouse);
      })

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

  //updateMenus(roleId: number) {
  //  this.roleId = roleId;
  //}

  openHomeForm() {
    this.registerService.isOpenHomeForm = true;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }

  openAboutForm() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = true;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }

  openRequestForm() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = true;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }

  openLoginForm() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = true;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }
  openApproveForm() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = true;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }
  openProfileForm() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = true;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }
  openmyClanForm() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = true;
    this.registerService.isOpenFamilyTree = false;
  }
  logout() {
    if (this.registerService.userRoleDTO != undefined) {
      this.registerService.userRoleDTO.roleId = 0;
    }
    this.registerService.isOpenHomeForm = true;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    this.registerService.isOpenmyClanForm = false;
    this.registerService.isOpenFamilyTree = false;
  }
  

  title = 'Buganda Genealogy';
}
