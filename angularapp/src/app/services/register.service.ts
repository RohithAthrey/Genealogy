import { Injectable } from '@angular/core';
import { Gender } from '../models/gender.model';
import { Clan } from '../models/clan.model';
import { RegistrationDTO } from '../models/save-register.model';
import { PersonRegisterStatusDTO, PersonStatus } from '../models/approve-register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor() { }

  allGenders?: Gender[];
  allClans?: Clan[];
  allRegistrations?: RegistrationDTO[];
  personRegisterStatusDTO?: PersonRegisterStatusDTO;
  allPersonStatus?: PersonStatus[];
}
