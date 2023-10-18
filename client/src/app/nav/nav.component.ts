import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/User';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent {
  model: any = {};


  constructor(public accountService: AccountService, private router: Router) {
       
  }

  ngOnInit () : void{}

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: user => console.log(user),
      error: error => console.log(error)
    });
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next: _ => {
        this.router.navigateByUrl('/members');
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
