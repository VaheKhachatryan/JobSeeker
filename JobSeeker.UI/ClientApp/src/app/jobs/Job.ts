import { IJob } from "./IJob";

export class Job implements IJob {
    Title: string;
    Description: string;
    PostedDate: Date;
    Category: string;
    City: string;
    EmploymentType: string;
}