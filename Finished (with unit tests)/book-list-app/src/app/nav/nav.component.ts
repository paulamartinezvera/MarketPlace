import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  IsLogin:boolean;
  constructor(
    private router: Router
  ) { 
   
    this.IsLogin=false;

    if(this.router.url=="/"){
      this.IsLogin=true;
    }else if(this.router.url=="/login"){

    }
  }

  ngOnInit(): void {
  }

  navTo(path: string): void {
    this.router.navigate([`/${path}`]);

  }

}
