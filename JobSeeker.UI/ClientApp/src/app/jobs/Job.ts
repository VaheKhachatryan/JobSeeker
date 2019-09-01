import { IJob } from "./IJob";

export class Job implements IJob {
    title: string;
    description: string;
    postedDate: Date;
    category: string;
    city: string;
    employmentType: string;
}