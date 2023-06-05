import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import APIEndpoints from '../constants/APIEndpoints';
import HTTP_OPTIONS from '../constants/HttpOptions';
import { PersonRegisterStatusDTO } from '../models/approve-register.model';
import { UpdatedRequestDTO } from '../models/save-register.model';

@Component({
  selector: 'familyTree',
  templateUrl: './familyTree.component.html',
  styleUrls: ['./familyTree.component.css']
})

export class familyTreeComponent implements OnInit {

  constructor(private httpClient: HttpClient, public registerService: RegisterService) {


  }

  ngOnInit() {
    console.log(this.registerService.selectedClanHouseName)
  }









}
