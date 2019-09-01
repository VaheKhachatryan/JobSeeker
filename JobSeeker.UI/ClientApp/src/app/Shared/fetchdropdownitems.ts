import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { throwError, Observable } from "rxjs";
import {tap, catchError } from "rxjs/operators"
import { IDropDownItemModel } from "./IDropDownItemModel";

@Injectable({
    providedIn: 'root'
})
export class FetchDropDownItems {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    }

    getCities(): Observable<IDropDownItemModel[]> {
        return this.http.get<IDropDownItemModel[]>(this.baseUrl + '/api/DropDown/GetCities');
    }

    getCategories(): Observable<IDropDownItemModel[]> {
        return this.http.get<IDropDownItemModel[]>(this.baseUrl + '/api/DropDown/GetCategories');
    }

    getEmploymentType(): Observable<IDropDownItemModel[]> {
        return this.http.get<IDropDownItemModel[]>(this.baseUrl + '/api/DropDown/GetEmploymentTypes');
    }
}