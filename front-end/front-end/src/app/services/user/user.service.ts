import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7185/api/Users';

  constructor(private http: HttpClient) { }

  register(user: User): Observable<any> {
    return this.http.post(`${this.apiUrl}/Register`, user);
  }

  login(username: string, password: string): Observable<any> {
    const body = { username, password };
    return this.http.post(`${this.apiUrl}/Login`, body);
  }

  getPatients(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  setUsername(username: string): void {
    localStorage.setItem('username', username);
  }

  // New method to get the username
  getUsername(): string | null {
    return localStorage.getItem('username');
  }

  // New method to clear the username (optional, for logout)
  clearUsername(): void {
    localStorage.removeItem('username');
  }
}
