import { Component } from "@angular/core";
import { Router } from "@angular/router";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'greenhaven';

  constructor(private router: Router){}  

  denyAccess(): boolean{
    if (this.router.url.includes('/auth')){
      return true;
    }
    return false;
  }

  showLabel(){
    if (this.router.url.includes('/profile')){
      return true;
    }
    return false;
  }

  
}
