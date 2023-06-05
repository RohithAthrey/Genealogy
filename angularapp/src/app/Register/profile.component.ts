import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';
import { PersonRegisterStatusDTO } from '../models/approve-register.model';
import { UpdatedRequestDTO } from '../models/save-register.model';
import { ProfileScreenDTO } from '../models/profile-register.model';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {
  about: string = '';
  surname: string = '';
  middleName: string = '';
  firstName: string = '';
  email: string = '';
  phone: string = '';
  profilePicPath: string = '';
  
  constructor(private httpClient: HttpClient, public registerService: RegisterService) {


  }

  ngOnInit() {
    this.getUserInfo();
    
  }
    getUserInfo() {
      this.httpClient.get<ProfileScreenDTO>(`${APIEndpoints.GET_PROFILE_PATH}/${this.registerService.loggedinPersonId}`)
        .subscribe(response => {
          this.profilePicPath = response.profilePicPath;
          this.about = response.about;
          this.surname = response.surname;
          this.middleName = response.middleName;
          this.firstName = response.firstName;
          this.email = response.email;
          this.phone = response.phone;
        })


  }
  createProfilePicPath(serverPath: any) {
    return `https://localhost:7065/${serverPath}`;
  }

 }
  

  






