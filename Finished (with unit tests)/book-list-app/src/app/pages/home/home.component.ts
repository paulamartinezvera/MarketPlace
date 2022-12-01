import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { Router, ActivatedRoute } from '@angular/router'; 
import { NavigationExtras } from '@angular/router'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  email: string;
  password: string;

  constructor(public userService: UsersService,private router: Router, private route: ActivatedRoute) {}

  login() {
    const user = {username: this.email, password: btoa(this.password)};
    this.userService.login(user).subscribe( (data:boolean) => {
      if(data==true){
        this.router.navigate(['market'], { relativeTo: this.route });
      }
    
    });
  }

  ngOnInit(): void {
  }


}
