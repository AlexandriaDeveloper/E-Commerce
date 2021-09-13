import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
baseUrl =environment.apiUrl;
validationErrors :any;
  constructor(private httpService : HttpClient) { }

  ngOnInit(): void {
  }

  get404Error (){
    return this.httpService.get(this.baseUrl+'products/42').subscribe(res => 
      console.log(res),
      err => console.log(err)
      );
  }

  get500Error (){
    return this.httpService.get(this.baseUrl+'buggy/servererror').subscribe(res => 
      console.log(res),
      err => console.log(err)
      );
  }
  get400Error (){
    return this.httpService.get(this.baseUrl+'buggy/badrequest').subscribe(res => 
      console.log(res),
      err => console.log(err)
      );
  }

  get400ValidationError (){
    return this.httpService.get(this.baseUrl+'products/fortytwo').subscribe(res => 
      console.log(res),
      err => {
      console.log(err);
      this.validationErrors=err.errors
    }

      );
  }



}
