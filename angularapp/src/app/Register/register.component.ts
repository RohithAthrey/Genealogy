import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
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
  loginId: string;
  password: string;
  profilePicPath: string;
  selGender: number;
  selClan: number;
  failMsg: string;
  showFailMsg: boolean;
  successMsg: string;
  showSuccessMsg: boolean;
  imgProgress: number;
  imgMsg: string;

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
    this.showFailMsg = false;
    this.failMsg = '';
    this.showSuccessMsg = false;
    this.successMsg = '';
    this.imgProgress = 0;
    this.imgMsg = '';
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
      register.email = this.email;
      register.loginId = this.loginId;
      register.password = this.password;
      register.profilePicPath = this.profilePicPath;
      register.clanId = this.selClan;

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
    } else
    return true;
  }
}
