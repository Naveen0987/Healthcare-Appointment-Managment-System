import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { FormsModule } from '@angular/forms';
import { UserService } from '../services/user/user.service';
// import { error } from 'console';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  username: string = '';
  password: string = '';
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router, private userService: UserService) {}

  onLogin(): void {
    console.log('Login attempt with username:', this.username, 'and password:', this.password);
    this.authService.login(this.username, this.password).subscribe(
      response => {  // Changed from Response to response
        // Handle successful login
        if(response && response.token){
        this.userService.setUsername(this.username);
        localStorage.setItem('token', response.token);
        console.log('Stored username:', localStorage.getItem('username'));
        console.log('Stored username:',this.userService.getUsername());
        alert('Login successful!');
        this.router.navigate(['/home']); // Redirect to home or any other route
        }else{
          alert('Login Failed: Invalid Response');
        }
      },
      error => {
        // Handle login error
        console.error('Login error:', error); // Log the error for debugging
        this.errorMessage = 'Invalid credentials'; // User-friendly error message
        alert('Login Failed: Invalid Credentials');
      }
    );
  }

  navigateToSignup() {
    this.router.navigate(['/signup']);
  }
}




