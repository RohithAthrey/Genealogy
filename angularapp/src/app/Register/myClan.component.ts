import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';
import { PersonRegisterStatusDTO } from '../models/approve-register.model';
import { UpdatedRequestDTO } from '../models/save-register.model';

@Component({
  selector: 'myClan',
  templateUrl: './myClan.component.html',
  styleUrls: ['./myClan.component.css']
})

export class myClanComponent implements OnInit {
  selClan: number;
  selClanHouse: number;
  selClanHouseName: string;
  originalSelClanHouseName?: string;
  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
    this.selClan = 0;
    this.originalSelClanHouseName = this.registerService.selectedClanHouseName;
    this.selClanHouse = 0;
    this.selClanHouseName = '';
  }

  ngOnInit() {

  }
  openFamilyTree() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    /*this.registerService.isOpenmyClanForm = false;*/
    this.registerService.isOpenFamilyTree = true;
  }
  openFamilyTree2() {
    this.registerService.isOpenHomeForm = false;
    this.registerService.isOpenAboutForm = false;
    this.registerService.isOpenRegisterForm = false;
    this.registerService.isOpenLoginForm = false;
    this.registerService.isOpenApproveForm = false;
    this.registerService.isOpenProfileForm = false;
    /*this.registerService.isOpenmyClanForm = false;*/
    this.registerService.selectedClanHouseName = this.originalSelClanHouseName;
    this.registerService.isOpenFamilyTree = true;
  }
  clanValueChanged(item: any) {

    // Find the selected clan based on its name
    var foundClan = this.registerService.allClans?.find(x => x.name === item.target.value);

    if (foundClan) {
      this.selClan = foundClan.clanID;
      //this.selClanHouse = 1;

      // Update the options in the "Clan House" dropdown based on the selected clan
    }

    console.log(this.selClan);
  }
  getFilteredClanHouses() {
    return this.registerService.allClanHouse?.filter(clanHouse => clanHouse.clanID === this.selClan);
  }

  updateClanHouseOptions(item: any) {
    this.selClanHouse = parseInt(item.target.value);
    var foundClanHouse = this.registerService.allClanHouse?.find(x => x.clanHouseID === this.selClanHouse);

    if (foundClanHouse) {
      this.selClanHouseName = foundClanHouse.clanHouseName;
    } else {
      this.selClanHouseName = '';
    }

    console.log(this.selClanHouseName);
    this.registerService.selectedClanHouseTree = this.selClanHouse;
    this.registerService.selectedClanHouseName = this.selClanHouseName;
  }

  
  







}
