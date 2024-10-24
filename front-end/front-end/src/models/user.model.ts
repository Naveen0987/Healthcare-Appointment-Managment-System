export interface User {
    username: string;
    passwordHash: string; // Ensure this matches the property name used in the signup component
    fullname: string;
    email: string;
    phoneNumber: string;
    dateOfBirth: string;
    role: string;
}
