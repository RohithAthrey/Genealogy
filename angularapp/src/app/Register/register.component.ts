import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import { Gender } from '../models/gender.model';
import { Clan } from '../models/clan.model';
import { RegistrationDTO } from '../models/save-register.model';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';

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
  selGender: number;
  selClan: number;
  failMsg: string;
  showFailMsg: boolean;
  successMsg: string;
  showSuccessMsg: boolean;

  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
    this.lastName = '';
    this.middleName = '';
    this.firstName = '';
    this.birthDate = '';
    this.address = '';
    this.city = '';
    this.telephone = '';
    this.email = '';
    this.selGender = 0;
    this.selClan = 0;
    this.showFailMsg = false;
    this.failMsg = '';
    this.showSuccessMsg = false;
    this.successMsg = '';
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

  }

  clanValueChanged(item: any) {
    var found = this.registerService.allClans?.find(x => x.name === item.target.value);
    if (found) {
      this.selClan = found.clanID;
    }
    console.log(this.selClan);
  }

  genderValueChanged(item: any) {
    var found = this.registerService.allGenders?.find(x => x.genderValue === item.target.value);
    if (found) {
      this.selGender = found.genderID;
    }
    console.log(this.selGender);
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
      register.email = this.email;
      register.loginId = this.firstName+this.lastName;
      register.clanId = this.selClan;

      this.httpClient
        .post(APIEndpoints.CREATE_REGISTRATION, register, HTTP_OPTIONS)
        .subscribe({
          next: (registeredPersonFromServer) => {
            this.showSuccessMsg = true;
            this.successMsg = "Successfully submitted the user for registration:";
            console.log('Successfully registered! Response from server:');
            console.log(registeredPersonFromServer);
          },
          error: (error: HttpErrorResponse) => {
            this.showFailMsg = true;
            this.failMsg = "Failed to submit the user for registration:";
            console.log(`Failed to register! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
          },
        });
    }
  }

  validateData(): boolean {
    this.showFailMsg = false;
    this.failMsg = '';
    if (this.firstName == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid first name and proceed.';
      return false;
    }
    else if (this.middleName == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid middle name and proceed.';
      return false;
    }
    else if (this.lastName == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid last name and proceed.';
      return false;
    }
    else if (this.birthDate == '') {
      this.showFailMsg = true;
      this.failMsg = 'Please enter a valid DOB and proceed.';
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
    if (this.selGender === 0) {
      this.showFailMsg = true;
      this.failMsg = 'Please select a valid gender and proceed.';
      return false;
    }
    if (this.selClan === 0) {
      this.showFailMsg = true;
      this.failMsg = 'Please select a valid clan and proceed.';
      return false;
    } else
    return true;
  }
}
