import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent {
  model: any = {};


  constructor(public accountService: AccountService, private router: Router, 
    private toastr: ToastrService) {
       
  }

  ngOnInit () : void{}

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: user => console.log(user),
      error: error => this.toastr.error(error)
    });
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next: _ => {
        this.router.navigateByUrl('/members');
      },
      error: (err) => {
        this.toastr.error(err.error);
      }
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
