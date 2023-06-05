import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RegisterService } from '../services/register.service';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';
import { PersonRegisterStatusDTO } from '../models/approve-register.model';
import { UpdatedRequestDTO } from '../models/save-register.model';
import { LoginDTO, UserRoleDTO } from '../models/login-register.model';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  @Output() roleId = new EventEmitter<number>();
  username: string;
  password: string;
  loginSuccess: string;
  loginFailure: string;
  showSuccess: boolean;
  showFailure: boolean;
  constructor(private httpClient: HttpClient, public registerService: RegisterService) {
    this.username = "";
    this.password = "";
    this.loginSuccess= "";
    this.loginFailure = "";
    this.showSuccess = false;
    this.showFailure = false;
  }

  ngOnInit() {
    
  }

  loginPerson() {
    this.showFailure = false;
    this.showSuccess = false;
    var login = {} as LoginDTO;
    login.username = this.username;
    login.password = this.password;
    this.httpClient
      .post(APIEndpoints.VERIFY_LOGIN, login, HTTP_OPTIONS)
      .subscribe({
        next: (registeredPersonFromServer) => {
          this.showSuccess = true;
          this.loginSuccess = "Successfully logged in:";
          this.registerService.loggedinPersonId = parseInt(registeredPersonFromServer.toString(), 10);
          console.log('Successfully registered! Response from server:');
          console.log(registeredPersonFromServer);
          this.httpClient.get<UserRoleDTO>(`${APIEndpoints.GET_ROLE_MODULES_BY_USERID}/${registeredPersonFromServer}`)
            .subscribe({
              next: (userRoleFromServer) => {
                this.registerService.userRoleDTO = userRoleFromServer;
                console.log(this.registerService.userRoleDTO.roleId);
                this.showSuccess = true;
                this.loginSuccess = "ffsffesoifesf";
                console.log('Successfully fetched user role modules! Response from server:');
                console.log(userRoleFromServer);
                this.registerService.isOpenHomeForm = true;
                this.registerService.isOpenLoginForm = false;

              //  this.roleId.emit(this.registerService.userRoleDTO.roleId);
              },
              error: (error: HttpErrorResponse) => {
                this.showFailure = true;
                this.loginFailure = "Failedn:";
                console.log(`Failed tor! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
              }
            });
        },
        error: (error: HttpErrorResponse) => {
          this.showFailure = true;
          this.loginFailure = "Failed to login:";
          console.log(`Failed to register! Response from server: "HTTP statuscode: ${error.status}: ${error.error}"`);
        },
      });
    
  }


  





}
