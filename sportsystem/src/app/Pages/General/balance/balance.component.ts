import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { IUser } from 'src/model/IUser';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {

  constructor(
    private service: ApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  user: IUser = new IUser();

  ngOnInit(): void {
    let route = this.activatedRoute.params.subscribe(params => {

      this.service.getUserById(params['id']).subscribe(
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
