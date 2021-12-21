import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { IUser } from 'src/model/IUser';

@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html',
  styleUrls: ['./edit-account.component.css']
})
export class EditAccountComponent implements OnInit {

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

  updateUser() {
    let item: IUser = this.user!;

    let route = this.activatedRoute.params.subscribe(params => {
      item.id = params['id']
      this.service.updateUser(this.user).subscribe()
    });
  }
}
