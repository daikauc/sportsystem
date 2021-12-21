import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(
    private service: ApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  username: string = ""

  ngOnInit(): void {
    this.username = localStorage.getItem('username') || 'Guest';
  }

  openBalance() {
    this.route.navigate(["balance/" + localStorage.getItem('userId')]);
  }

}
