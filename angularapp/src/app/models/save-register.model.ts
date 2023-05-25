export interface RegistrationDTO {
  lastName: string;
  middleName: string;
  firstName: string;
  birthDate: string;
  address: string;
  city: string;
  telephone?: string;
  genderId: number;
  email: string;
  loginId: string;
  password: string;
  profilePicPath: string;
  clanId: number;
}
export interface UpdatedRequestDTO {
  personClanRequestId: number;
  personId: number;
  requestTypeId: number;
  lastUpdatedBy: string;
}
