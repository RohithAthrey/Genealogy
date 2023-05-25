export interface PersonRegisterStatusDTO {
  requestTypeId: number;
  personStatuses: PersonStatus[];
}

export interface PersonStatus {
  personId: number;
  fullName: string;
  clanName: string;
  profilePicPath: string;
  personClanRequestId: number;
}
