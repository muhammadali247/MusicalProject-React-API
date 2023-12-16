export const BASE_WEB_URL = "https://localhost:7073";
export const BASE_URL = `${BASE_WEB_URL}/api`; //api

// Artists API Calls
export const ARTIST_GETALL_URL = `${BASE_URL}/Artists`;
export const ARTIST_GETDETAILS_URL = (artistId) => `${BASE_URL}/Artists/${artistId}/details`;
export const ARTIST_CREATE_URL = `${BASE_URL}/Artists`;
export const ARTIST_UPDATE_URL = (artistId) => `${BASE_URL}/Artists/${artistId}`;
export const ARTIST_DELETE_URL = (artistId) => `${BASE_URL}/Artists/${artistId}`;

// MusicalProjects API Calls
export const MUSICAL_PROJECTS_GETALL_URL = `${BASE_URL}/MusicalProjects`;
export const MUSICAL_PROJECTS_DELETE_URL = (musicalProjectId) => `${BASE_URL}/MusicalProjects/${musicalProjectId}`;

// Events
export const EVENTS_GETALL_URL = `${BASE_URL}/Events`;
export const EVENTS_DELETE_URL = (eventId) => `${BASE_URL}/Events/${eventId}`;
export const EVENTS_CREATE_URL = `${BASE_URL}/Events`;

// Tickets
export const TICKETS_GETALL_URL = `${BASE_URL}/Tickets`;
export const TICKETS_DELETE_URL = (ticketId) => `${BASE_URL}/Tickets/${ticketId}`;

// Albums
export const ALBUMS_GETALL_URL = `${BASE_URL}/Albums`;
export const ALBUMS_DELETE_URL = (albumId) => `${BASE_URL}/Albums/${albumId}`;

// Songs
export const SONGS_GETALL_URL = `${BASE_URL}/Songs`;
export const SONGS_DELETE_URL = (songId) => `${BASE_URL}/Songs/${songId}`;


// Account
export const ACCOUNT_REGISTER_URL = `${BASE_URL}/Accounts/Register`
export const ACCOUNT_LOGIN_URL = `${BASE_URL}/Accounts/Login`;
export const ACCOUNT_VERIFYACCOUNT_URL = (userId) => `${BASE_URL}/Accounts/verify-account/${userId}`;
export const ACCOUNT_RESEND_OTP_URL = (userId) => `${BASE_URL}/Accounts/resend-otp/${userId}`;
export const ACCOUNT_FORGOT_PASSWORD_URL = `${BASE_URL}/Accounts/forgot-password`;
export const ACCOUNT_RESET_PASSWORD_URL = `${BASE_URL}/Accounts/reset-password`;
export const ACCOUNT_VALIDATE_RESET_PASSWORD_TOKEN_URL = `${BASE_URL}/Accounts/validate-reset-password-token`;
export const ACCOUNT_RENEW_TOKEN_URL = `${BASE_URL}/Accounts/renew-token`;
export const ACCOUNT_LOGOUT_URL = `${BASE_URL}/Accounts/logout`;


// Users
export const USERS_GETALL_LIMITED_URL = `${BASE_URL}/Users`;
export const USERS_GET_BY_ID_LIMITED_URL = (userId) =>  `${BASE_URL}/Users/${userId}`;
export const USERS_DELETE_URL = (userId) => `${BASE_URL}/Users/${userId}`;

