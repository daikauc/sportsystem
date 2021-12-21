import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { ISub } from 'src/model/ISub';

@Component({
  selector: 'app-sub-transfer',
  templateUrl: './sub-transfer.component.html',
  styleUrls: ['./sub-transfer.component.css']
})
export class SubTransferComponent implements OnInit {

  sub: ISub = new ISub()
  userId: number = 1;
  constructor(
    private service: ApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  ngOnInit(): void {
    this.service.getSubByUserId(parseInt(localStorage.getItem('userId') || "0")).subscribe(
      data => {
        this.sub = data;
        console.log(this.sub);
      },
      error => {
        console.log(error);
      }
    )
  }

  transferSub() {
    this.sub.userId = this.userId;
    this.sub.id = 0
    this.service.addSub(this.sub).subscribe(
      data => {

      },
      error => {
        console.log(error);
      }
    )

  }
}
