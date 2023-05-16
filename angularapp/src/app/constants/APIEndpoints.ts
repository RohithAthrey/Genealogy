import { isDevMode } from '@angular/core';

const SERVER_BASE_URL_DEVELOPMENT = 'https://localhost:7065';
const SERVER_BASE_URL_PRODUCTION = 'https://aspnetcorereacttutorial-aspnetserver.azurewebsites.net';

const BASE_ENDPOINTS = {
  GET_ALL_REGISTRATIONS: 'register',
  GET_ALL_GENDERS: 'register/getGenders',
  GET_ALL_CLANS: 'register/getClans',
  GET_REGISTRATION_BY_ID: 'register',
  CREATE_REGISTRATION: 'register',
  UPDATE_REGISTRATION: 'register',
  DELETE_REGISTRATION: 'register'
};

const DEVELOPMENT_ENDPOINTS = {
  GET_ALL_REGISTRATIONS: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_ALL_REGISTRATIONS}`,
  GET_ALL_GENDERS: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_ALL_GENDERS}`,
  GET_ALL_CLANS: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_ALL_CLANS}`,
  /**
  * Append /{id}. Example: \`${API_ENDPOINTS.GET_REGISTRATION_BY_ID}/1\`
  */
  GET_REGISTRATION_BY_ID: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.GET_REGISTRATION_BY_ID}`,
  /**
  * Send the registration to create as an object of type RegisterCreateUpdateDTO in the HTTP body.
  */
  CREATE_REGISTRATION: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.CREATE_REGISTRATION}`,
  /**
  * Append /{id}. Example: \`${API_ENDPOINTS.UPDATE_REGISTRATION}/1\`.
  * Send the post to update as an object of type RegisterCreateUpdateDTO in the HTTP body.
  */
  UPDATE_REGISTRATION: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.UPDATE_REGISTRATION}`,
  /**
  * Append /{id}. Example: \`${API_ENDPOINTS.DELETE_REGISTRATION}/1\`
  */
  DELETE_REGISTRATION: `${SERVER_BASE_URL_DEVELOPMENT}/${BASE_ENDPOINTS.DELETE_REGISTRATION}`
};

const PRODUCTION_ENDPOINTS = {
  GET_ALL_REGISTRATIONS: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.GET_ALL_REGISTRATIONS}`,
  GET_ALL_GENDERS: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.GET_ALL_GENDERS}`,
  GET_ALL_CLANS: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.GET_ALL_CLANS}`,
  GET_REGISTRATION_BY_ID: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.GET_REGISTRATION_BY_ID}`,
  CREATE_REGISTRATION: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.CREATE_REGISTRATION}`,
  UPDATE_REGISTRATION: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.UPDATE_REGISTRATION}`,
  DELETE_REGISTRATION: `${SERVER_BASE_URL_PRODUCTION}/${BASE_ENDPOINTS.DELETE_REGISTRATION}`
};

const ENDPOINTS_TO_EXPORT = isDevMode() ? DEVELOPMENT_ENDPOINTS : PRODUCTION_ENDPOINTS;

export default ENDPOINTS_TO_EXPORT;