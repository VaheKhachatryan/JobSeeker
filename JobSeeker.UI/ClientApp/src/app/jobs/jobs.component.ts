import { Component, OnInit } from '@angular/core';
import { JobsService } from './jobs.service';
import { IJob } from './IJob';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {
  title: string;
  jobs: IJob[];

  constructor(private jobservice: JobsService) {
    this.title = 'Jobs list'
    this.jobs = jobservice.getJobs();
   }

  ngOnInit() {

  }

}
