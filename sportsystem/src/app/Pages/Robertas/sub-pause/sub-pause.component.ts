import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { ISub } from 'src/model/ISub';

@Component({
  selector: 'app-sub-pause',
  templateUrl: './sub-pause.component.html',
  styleUrls: ['./sub-pause.component.css']
})
export class SubPauseComponent implements OnInit {

  sub: ISub = new ISub()
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

  pauseSub() {
    this.sub.stopped = true;

    this.service.updateSub(this.sub).subscribe(
      data => {

      },
      error => {
        console.log(error);
      }
    )

  }


  resumeSub() {
    this.sub.stopped = false;

    this.service.updateSub(this.sub).subscribe(
      data => {

      },
      error => {
        console.log(error);
      }
    )

  }

}
