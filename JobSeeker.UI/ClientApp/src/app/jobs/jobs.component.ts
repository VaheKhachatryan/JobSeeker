import { Component, OnInit } from '@angular/core';
import { JobsService } from './jobs.service';
import { IJob } from './IJob';
import { JobRequestModel } from './jobRequestModel';
import { IDropDownItemModel } from '../Shared/IDropDownItemModel';
import { FetchDropDownItems } from '../Shared/fetchdropdownitems';
import { FilterType } from '../Shared/FilterEnum';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {
  title: string;
  jobs: IJob[];
  errorMessage: string;
  jobRequestModel: JobRequestModel = new JobRequestModel();
  cities: IDropDownItemModel[];
  categories: IDropDownItemModel[];
  employmnetTypes: IDropDownItemModel[];

  constructor(private jobservice: JobsService, private fetchDropDownItems: FetchDropDownItems) {
    this.title = 'Jobs list'
    this.jobservice.getJobs(this.jobRequestModel).subscribe({
      next: jobs => this.jobs = jobs,
      error: err => this.errorMessage = err
    });

    this.fetchDropDownItems.getCities().subscribe({
      next: cities => this.cities = cities,
      error: err => this.errorMessage = err
    });

    this.fetchDropDownItems.getCategories().subscribe({
      next: categories => this.categories = categories,
      error: err => this.errorMessage = err
    });

    this.fetchDropDownItems.getEmploymentType().subscribe({
      next: employmnetTypes => this.employmnetTypes = employmnetTypes,
      error: err => this.errorMessage = err
    });

   }

   filterJobs(filterVal: any, filterType: FilterType) {
    switch(filterType){
      case FilterType.CityFilter: {
        this.jobRequestModel.CityIds.push(filterVal);
      break;  
      }
      case FilterType.CategoryFilter: {
        this.jobRequestModel.CategoryIds.push(filterVal);
      break;  
      }
      case FilterType.EmploymentFilter: {
        this.jobRequestModel.EmploymentIds.push(filterVal);
      break;  
      }
    }
    this.jobservice.getJobs(this.jobRequestModel).subscribe({
      next: jobs => this.jobs = jobs,
      error: err => this.errorMessage = err
    });
   }

  ngOnInit() {

  }

}
