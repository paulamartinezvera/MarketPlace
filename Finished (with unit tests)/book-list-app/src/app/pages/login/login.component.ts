import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { Router, ActivatedRoute } from '@angular/router'; 
import { NavigationExtras } from '@angular/router'; 

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  email: string;
  password: string;

  constructor(public userService: UsersService,private router: Router, private route: ActivatedRoute) {
    sessionStorage.removeItem('user'); 
  }

  login() {
    const user = {username: this.email, password: btoa(this.password)};
    this.userService.login(user).subscribe( (data:any) => {
      if(data.length==0){
        this.userService._toastError('Usuario o clave incorrecta');
        sessionStorage.removeItem('user');   
      }else{
        var userString=JSON.stringify(data);
        sessionStorage.setItem('user', userString); 
        this.navTo("home");
      }
    
    });
  }
  navTo(path: string): void {
      this.router.navigate([`/${path}`]);
    }
  
  ngOnInit(): void {
  }
}
