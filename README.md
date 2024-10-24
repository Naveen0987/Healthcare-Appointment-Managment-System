# Healthcare-Appointment-Managment-System
 Documentation for Healthcare Appointment and Management System project.

Table of Contents:

1.Overview
2.Project Structure
3.Components
4.Services
5.Routing Configuration
6.Data Storage and Retrieval
7.Models
8.Installation
9.Usage
1o Troubleshooting

1.Overview

The Healthcare Appointment and Management System is a web application designed to manage appointments, departments, and doctors. Built using Angular, Html,Css,Js,MySQL, and Bootstrap.

2.Project Structure

dist/
node_modules/
src/
app/
components/
appointment/
dashboard/
department/
doctor/
services/
appointment.service.ts
department.service.ts
doctor.service.ts
models/
appointment.model.ts
department.model.ts
doctor.model.ts
assets/
environments/
index.html
main.ts
polyfills.ts
styles.css
tsconfig.json
package.json
README.md
3.Components

3.1Appointment Component

Handles appointment booking

3.2Dashboard Component

Displays Home
Displays Services
Displays  Blogs
Displays  Contact US

3.3Department Component

Lists available departments

3.4Doctor Component

Lists available doctors

4.Services

4.1Appointment Service

Creates appointments

4.2Department Service

Handles department data 

5.Routing Configuration

TypeScript
const routes: Routes = [
  {
    path: 'appointment',
    component: AppointmentComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'department',
    component: DepartmentComponent
  },
  {
    path: 'doctor',
    component: DoctorComponent
  },
];

6.Data Storage and Retrieval

The application uses MySQL to store data. Angular services interact with the database using HTTP requests.

7.Models

7.1Appointment Model

TypeScript
export class Appointment {
  id: number;
  patientName: string;
  doctorName: string;
  departmentName: string;
  appointmentDate: Date;
  appointmentTime: string;
}

7.2Department Model

TypeScript
export class Department {
  id: number;
  departmentName: string;
  description: string;
}

7.3Doctor Model

TypeScript
export class Doctor {
  id: number;
  doctorName: string;
  departmentName: string;
  specialization: string;
}

8.Installation

Copy the code
Run npm install
Create a MySQL database
Configure database credentials in environment.ts
Run ng serve

9. Usage
Access the application at http://localhost:4200
Book appointments, manage departments, and doctors

10. Troubleshooting

Check console logs for errors
Verify database connection
Consult Angular and MySQL documentation
