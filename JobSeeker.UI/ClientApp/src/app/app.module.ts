import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DropdownModule } from 'angular-dropdown-component';
import { AppComponent } from './app.component';
import { JobsComponent } from './jobs/jobs.component';

@NgModule({
  declarations: [
    AppComponent,
    JobsComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DropdownModule,
    RouterModule.forRoot([
      { path: '', component: JobsComponent, pathMatch: 'full' }

    ])
  ],
  providers: [
    {provide: 'BASE_URL', useValue: 'https://localhost:44394'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
