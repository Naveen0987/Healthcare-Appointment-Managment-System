import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../services/user/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent {
  user = {
    username: '',
    passwordHash: '',  // Changed to 'passwordHash' to match backend
    fullname: '',
    email: '',
    phoneNumber: '',
    dateOfBirth: '',
    role: 'Patient' // Default role is 'Patient'
  };

  constructor(private service: UserService, private router: Router) {}

  onSubmit() {
    this.service.register(this.user).subscribe(
      response => {
        console.log("Signup successful", response);
        this.router.navigate(['/user']); // Redirect to login after successful signup
      },
      error => {
        console.error('Signup Failed', error);
        alert(`Signup Failed: ${error.status} - ${error.statusText}`);
      }
    );
  }
}
