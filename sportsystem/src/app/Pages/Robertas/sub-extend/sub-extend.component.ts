import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { ISub } from 'src/model/ISub';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-sub-extend',
  templateUrl: './sub-extend.component.html',
  styleUrls: ['./sub-extend.component.css']
})
export class SubExtendComponent implements OnInit {

  sub: ISub = new ISub()
  date = new Date();
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

  extendSub() {


    this.sub.end = formatDate(this.date.setDate(this.date.getDate() + 30), 'yyyy/MM/dd', 'en');
    let metai: number = parseInt(this.sub.end[0] + this.sub.end[1] + this.sub.end[2] + this.sub.end[3])
    let menesis: number = parseInt(this.sub.end[5] + this.sub.end[6])
    let diena: number = parseInt(this.sub.end[8] + this.sub.end[9])

    diena += 10
    if (diena > 31) {
      diena -= 30
      menesis += 1
    }
    if (menesis > 12) {
      menesis = 1
      metai += 1
    }
    this.sub.end = metai + "/" + menesis + "/" + diena

    this.service.updateSub(this.sub).subscribe(
      data => {

      },
      error => {
        console.log(error);
      }
    )

  }


}
