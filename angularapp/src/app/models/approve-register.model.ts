export interface PersonRegisterStatusDTO {
  requestTypeId: number;
  personStatuses: PersonStatus[];
}

export interface PersonStatus {
  personId: number;
  fullName: string;
  clanHouseName: string;
  profilePicPath: string;
  registerPara: string;
  grandparents: string;
  parents: string;
  greatGrandparets: string;
  personClanHouseRequestId: number;
}
