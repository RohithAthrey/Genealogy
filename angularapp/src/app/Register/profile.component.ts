import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
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
  imgProgress: number;
  imgMsg: string;
  failMsg: string;
  showFailMsg: boolean;
  successMsg: string;
  showSuccessMsg: boolean;

  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
    this.showFailMsg = false;
    this.failMsg = '';
    this.showSuccessMsg = false;
    this.successMsg = '';
    this.imgProgress = 0;
    this.imgMsg = '';
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
  uploadFile(files: any) {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);


    this.httpClient
      .put(`${APIEndpoints.UPDATE_PROFILE_PICTURE}/${this.registerService.loggedinPersonId}`, formData, { reportProgress: true, observe: 'events' })
      .subscribe({
        next: (event: any) => {
          if (event.type === HttpEventType.UploadProgress)
            this.imgProgress = Math.round(100 * event.loaded / event.total);
          else if (event.type === HttpEventType.Response) {
            this.imgMsg = 'Upload success.';
            console.log(event.body);
            this.profilePicPath = event.body.profilePicPath; 
          }
        },
        error: (error: HttpErrorResponse) => {
          this.showFailMsg = true;
          this.failMsg = 'Failed to upload user profile:';
          console.log(`Failed to upload user profile! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
        },
      });

  }
  createProfilePicPath(serverPath: any) {
    return `https://localhost:7065/${serverPath}`;
  }

 }
  

  






