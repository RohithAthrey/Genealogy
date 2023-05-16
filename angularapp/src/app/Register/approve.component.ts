import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';
import { PersonRegisterStatusDTO } from '../models/approve-register.model';
import { UpdatedRequestDTO } from '../models/save-register.model';

@Component({
  selector: 'approve',
  templateUrl: './approve.component.html',
  styleUrls: ['./approve.component.css']
})

export class ApproveComponent implements OnInit {
  registerTypeId = 1;
  updateSuccessful = false;
    requestService: any;

  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
   
  }

  ngOnInit() {
    this.getToBeApprovedRegistrations();
  }

  getToBeApprovedRegistrations() {
    this.httpClient.get<PersonRegisterStatusDTO>(`${APIEndpoints.GET_REGISTRATION_BY_ID}/${this.registerTypeId}`)
      .subscribe(response => {
        this.registerService.personRegisterStatusDTO = response;
        this.registerService.allPersonStatus = this.registerService.personRegisterStatusDTO.personStatuses;
        console.log(this.registerService.allPersonStatus);
      })
  }

  updateRegistration(typeId: number, personClanRequestId: number) {
    this.registerTypeId = typeId;
    var register = {} as UpdatedRequestDTO;
    register.personClanRequestId = personClanRequestId;
    register.requestTypeId = typeId;
    register.lastUpdatedBy = "Kenneth R Odombe";

    this.httpClient
      .put(`${APIEndpoints.UPDATE_REGISTRATION}/${personClanRequestId}`, register, HTTP_OPTIONS)
      .subscribe({
        next: (response) => {
          this.updateSuccessful = true;

          //let updatedRequestFromServer: UpdatedRequestDTO = response as UpdatedRequestDTO;

          //let updatedRequestIndex = this.requestService.allPersonStatus.findIndex((post => post.id == updatedPostFromServer.id));

          //this.postService.allPosts[updatedPostIndex].title = updatedPostFromServer.title;
          //this.postService.allPosts[updatedPostIndex].content = updatedPostFromServer.content;
          //this.postService.allPosts[updatedPostIndex].published = updatedPostFromServer.published;

          console.log('Successfully updated the post! Response from server:');
          console.log(response);

          this.registerTypeId = 1;
          this.getToBeApprovedRegistrations();
          console.log('Successfully registered! Response from server:');
        },
        error: (error: HttpErrorResponse) => {
          console.log(`Failed to register! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
        },
      });
  }  


  

  
}
