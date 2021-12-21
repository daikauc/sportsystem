import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { ISub } from 'src/model/ISub';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})
export class SubscriptionComponent implements OnInit {

  sub: ISub | undefined
  sustabdyta: string = "";

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
        if (this.sub.stopped) {
          this.sustabdyta = "SUSTABDYTA"
        }
        else {
          this.sustabdyta = "NAUDOJAMA"
        }
      },
      error => {
        console.log(error);
        this.sustabdyta = "NETURITE PRENUMERATOS"
      }
    )
  }

}
