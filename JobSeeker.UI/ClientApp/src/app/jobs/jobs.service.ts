import { Injectable, Inject } from "@angular/core";
import { IJob } from "./IJob";
import { Job } from "./Job";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { JobRequestModel } from "./jobRequestModel";
import { throwError, Observable } from "rxjs";
import { JsonPipe } from "@angular/common";
import {tap, catchError } from "rxjs/operators"
import { RequestOptions } from "@angular/http";

@Injectable({
    providedIn: 'root'
})
export class JobsService {
    url = this.baseUrl + '/api/Job/GetJobs';

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    }
    getJobs(request: JobRequestModel): Observable<IJob[]> {
      const  headers = new  HttpHeaders().set('Content-Type','application/json');
      
      return this.http.post<IJob[]>(this.url, request, {headers}).pipe(tap(data => console.log('All: ' + JSON.stringify(data))), 
      catchError(this.handleError)
      );
    }

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
          // A client-side or network error occurred. Handle it accordingly.
          console.error('An error occurred:', error.error.message);
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong,
          console.error(
            `Backend returned code ${error.status}, ` +
            `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return throwError(
          'Something bad happened; please try again later.');
      };
}