import { Injectable } from '@angular/core';
import { Gender } from '../models/gender.model';
import { Clan } from '../models/clan.model';
import { RegistrationDTO } from '../models/save-register.model';
import { PersonRegisterStatusDTO, PersonStatus } from '../models/approve-register.model';
import { UserRoleDTO } from '../models/login-register.model';
import { ClanHouse } from '../models/clanHouse.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor() { }

  allGenders?: Gender[];
  allClans?: Clan[];
  allClanHouse?: ClanHouse[];
  allRegistrations?: RegistrationDTO[];
  personRegisterStatusDTO?: PersonRegisterStatusDTO;
  allPersonStatus?: PersonStatus[];
  userRoleDTO?: UserRoleDTO;
  loggedinPersonId?: number;
  originalHouseName?: string;
  logoutBoolean= false;


  isOpenHomeForm = false;
  isOpenAboutForm = false;
  isOpenRegisterForm = false;
  isOpenLoginForm = false;
  isOpenApproveForm = false;
  isOpenProfileForm = false;
  isOpenmyClanForm = false;
  isOpenFamilyTree = false;
  selectedClanHouseTree?: number;
  selectedClanHouseName?: string;

}
