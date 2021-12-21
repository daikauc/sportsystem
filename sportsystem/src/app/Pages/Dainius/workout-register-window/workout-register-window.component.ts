import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { IWorkout } from 'src/model/IWorkout';

@Component({
  selector: 'app-workout-register-window',
  templateUrl: './workout-register-window.component.html',
  styleUrls: ['./workout-register-window.component.css']
})
export class WorkoutRegisterWindowComponent implements OnInit {

  workout: IWorkout | undefined
  constructor(
    private service: ApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) { }

  ngOnInit(): void {
    let route = this.activatedRoute.params.subscribe(params => {

      this.service.getWorkoutById(params['id']).subscribe(
        data => {
          this.workout = data;
        },
        error => {
          console.log(error);
        }
      )
    });
  }
  register(): void{
    this.service.addWorkoutRegistration(parseInt(localStorage.getItem('userId') || "0"), this.workout?.id || 0).subscribe(
      data => {
        
      },
      error => {
        console.log(error);
      }
    );
    this.route.navigate(['workout']);
  }

}
