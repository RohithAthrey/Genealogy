import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import { Gender } from '../models/gender.model';
import { Clan } from '../models/clan.model';
import { RegistrationDTO } from '../models/save-register.model';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';
import { ClanHouse } from '../models/clanHouse.model';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  lastName: string;
  middleName: string;
  firstName: string;
  birthDate: string;
  address: string;
  city: string;
  telephone: string;
  email: string;
  loginId: string;
  password: string;
  profilePicPath: string;
  selGender: number;
  selClan: number;
  selClanHouse: number;
  selClanHouseName: string;
  failMsg: string;
  showFailMsg: boolean;
  successMsg: string;
  showSuccessMsg: boolean;
  imgProgress: number;
  imgMsg: string;
  registerPara: string;
  grandparents: string;
  parents: string;
  greatGrandparents: string;


  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
    this.lastName = '';
    this.middleName = '';
    this.firstName = '';
    this.birthDate = '';
    this.address = '';
    this.city = '';
    this.telephone = '';
    this.email = '';
    this.loginId = '';
    this.password = '';
    this.profilePicPath = '';
    this.selGender = 0;
    this.selClan = 0;
    this.selClanHouse = 0;
    this.selClanHouseName = '';
    this.showFailMsg = false;
    this.failMsg = '';
    this.showSuccessMsg = false;
    this.successMsg = '';
    this.imgProgress = 0;
    this.imgMsg = '';
    this.registerPara = '';
    this.grandparents = '';
    this.parents = '';
    this.greatGrandparents = '';
  }

  ngOnInit() {
    //this.httpClient.get<Gender[]>(APIEndpoints.GET_ALL_GENDERS)
    //  .subscribe(response => {
    //    this.registerService.allGenders = response;
    //    this.registerService.allGenders.unshift({ 'genderID': 0, 'genderCode': 'N/A', 'genderValue': '---Select---' });
    //    console.log(this.registerService.allGenders);
    //  })

    //this.httpClient.get<Clan[]>(APIEndpoints.GET_ALL_CLANS)
    //  .subscribe(result => {
    //    this.registerService.allClans = result;
    //    this.registerService.allClans.unshift({ 'clanID': 0, 'name': '---Select---', 'symbol': 'N/A', 'subTotem': 'N/A' });
    //    console.log(this.registerService.allClans);
    //  })
    //this.httpClient.get<ClanHouse[]>(APIEndpoints.GET_ALL_CLAN_HOUSES)
    //  .subscribe(returned => {
    //    this.registerService.allClanHouse = returned;
    //    this.registerService.allClanHouse.unshift({ 'clanID': 0, 'clanHouseName': '------Select------', 'clanHouseID': 0 });
    //    console.log(this.registerService.allClanHouse);
    //  })

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
    var filtered= this.registerService.allClanHouse?.filter(clanHouse => clanHouse.clanID === this.selClan);
    //filtered?.unshift({ 'clanID': 0, 'clanHouseName': '------Select------', 'clanHouseID': 0 });
    //this.selClanHouse = 0;
    return filtered;
  }

  updateClanHouseOptions(item: any) {
    this.selClanHouse = parseInt(item.target.value);
    var foundClanHouse = this.registerService.allClanHouse?.find(x => x.clanHouseID === this.selClanHouse);

    if (foundClanHouse) {
      this.selClanHouseName = foundClanHouse.clanHouseName;
    } else {
      this.selClanHouseName = '';
    }

    console.log(this.selClanHouse);
    this.registerService.selectedClanHouseTree = this.selClanHouse;
    this.registerService.selectedClanHouseName = this.selClanHouseName;
    this.registerService.originalHouseName = this.selClanHouseName;
    console.log(this.registerService.selectedClanHouseTree);
  }




  genderValueChanged(item: any) {
    var found = this.registerService.allGenders?.find(x => x.genderValue  === item.target.value);
    if (found) {
      this.selGender = found.genderID;
    }
    console.log(this.selGender);
  }
  wordCount(text: string): number {
    if (text) {
      const words = text.trim().split(/\s+/);
      return words.length;
    }
    return 0;
  }
  uploadFile(files: any) {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.httpClient
      .post(APIEndpoints.UPLOAD_PROFILE, formData, { reportProgress: true, observe: 'events' })
      .subscribe({
        next: (event: any) => {
          if (event.type === HttpEventType.UploadProgress)
            this.imgProgress = Math.round(100 * event.loaded / event.total);
          else if (event.type === HttpEventType.Response) {
            this.imgMsg = 'Upload success.';
            console.log(event.body);
            this.profilePicPath = event.body.profilePicPath; //profilePicPath within the response body contains the profile pic path
          }
        },
        error: (error: HttpErrorResponse) => {
          this.showFailMsg = true;
          this.failMsg = "Failed to upload user profile:";
          console.log(`Failed to upload user profile! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
        },
      });
  }

  registerPerson() {
    if (this.validateData()) {
      var register = {} as RegistrationDTO;
      register.lastName = this.lastName;
      register.middleName = this.middleName;
      register.firstName = this.firstName;
      register.birthDate = this.birthDate;
      register.address = this.address;
      register.city = this.city;
      register.telephone = this.telephone;
      register.genderId = this.selGender;
      register.clanId = this.selClan;
      register.email = this.email;
      register.loginId = this.loginId;
      register.password = this.password;
      register.profilePicPath = this.profilePicPath;
      register.clanHouseId = this.selClanHouse;
      register.registerPara = this.registerPara;
      register.grandparents = this.grandparents;
      register.parents=this.parents;
      register.greatGrandparents = this.greatGrandparents;

      this.httpClient
        .post(APIEndpoints.CREATE_REGISTRATION, register, HTTP_OPTIONS)
        .subscribe({
          next: (registeredPersonFromServer) => {
            this.showSuccessMsg = true;
            this.successMsg = "Successfully submitted the user for registration";
            console.log('Successfully registered! Response from server:');
            console.log(registeredPersonFromServer);
          },
          error: (error: HttpErrorResponse) => {
            this.showFailMsg = true;
            this.failMsg = "Failed to submit the user for registration";
            console.log(`Failed to register! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
          },
        });
    }

  }

  validateData(): boolean {
    this.showFailMsg = false;
    this.failMsg = '';
    if (this.lastName == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid surname and proceed.';
      return false;
    }
    else if (this.middleName == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid middle name and proceed.';
      return false;
    }
    else if (this.firstName == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid first name and proceed.';
      return false;
    }
    else if (this.parents == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a parent and proceed.';
      return false;
    }
    else if (this.grandparents == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a grandparent and proceed.';
      return false;
    }
    else if (this.address == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid address and proceed.';
      return false;
    }
    else if (this.city == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid city and proceed.';
      return false;
    }
    else if (this.loginId == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid login id and proceed.';
      return false;
    }
    else if (this.password == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid password and proceed.';
      return false;
    }
    if (this.selGender === 0) {
      this.showFailMsg = true;
      this.failMsg = 'Please select a valid gender and proceed.';
      return false;
    }
    if (this.selClan === 0) {
      this.showFailMsg = true;
      this.failMsg = 'Please select a valid clan and proceed.';
      return false;
    }
    else if (!this.telephone && !this.email) {
      this.showFailMsg = true;
      this.failMsg = 'Please enter either an email or telephone.';
      return false;
    } else
    return true;
  }
}
