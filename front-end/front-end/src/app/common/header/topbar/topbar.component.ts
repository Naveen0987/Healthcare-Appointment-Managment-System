import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { UserService } from '../../../services/user/user.service';

@Component({
  selector: 'app-topbar',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './topbar.component.html',
  styles: ``
})
export class TopbarComponent implements OnInit{
  username: string | null = null;

    constructor(private userService: UserService) {}
  ngOnInit(): void{
    this.username = this.userService.getUsername();
  }

}
