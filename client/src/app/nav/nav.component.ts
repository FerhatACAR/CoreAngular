import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent {
  model: any = {}
  loggedIn = false;
  constructor(private accountService: AccountService) {
       
  }

  ngOnInit () : void{}

  login(){
    this.accountService.login(this.model).subscribe({
      next: () => {
        console.log('Login Successful');
        this.loggedIn = true;
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  logout(){
    this.loggedIn = false;
  }
}
