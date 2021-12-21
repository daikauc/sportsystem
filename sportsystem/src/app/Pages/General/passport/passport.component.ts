import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { IUser } from 'src/model/IUser';

@Component({
  selector: 'app-passport',
  templateUrl: './passport.component.html',
  styleUrls: ['./passport.component.css']
})
export class PassportComponent implements OnInit {

  constructor(
    private service: ApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  user: IUser = new IUser();

  ngOnInit(): void {
    let route = this.activatedRoute.params.subscribe(params => {

      this.service.getUserById(parseInt(localStorage.getItem('userId') || "0")).subscribe(
        data => {
          this.user = data;
          console.log(this.user);
        },
        error => {
          console.log(error);
        }
      )
    });
  }

}
