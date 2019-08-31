import { Injectable } from "@angular/core";
import { IJob } from "./IJob";
import { Job } from "./Job";

@Injectable({
    providedIn: 'root'
})
export class JobsService {
    getJobs(): Job[] {
      
        return [
            {
                "Title": "test",
                "Description": "test",
                "PostedDate": new Date("2019-01-16"),
                "Category": "test",
                "City": "test",
                "EmploymentType": "test"
              },
              {
                "Title": "test",
                "Description": "test",
                "PostedDate": new Date("2019-01-16"),
                "Category": "test",
                "City": "test",
                "EmploymentType": "test"
              },
              {
                "Title": "test",
                "Description": "test",
                "PostedDate":  new Date("2019-01-16"),
                "Category": "test",
                "City": "test",
                "EmploymentType": "test"
              }
        ];
    }
}