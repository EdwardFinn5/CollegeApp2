import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'College Connect';
  colUsers: any;

  constructor(private http: HttpClient) {}
  
  ngOnInit() {
  this.getColUsers(); 
  }

  getColUsers() {
    this.http.get('https://localhost:5001/api/colUsers').subscribe(response => {
      this.colUsers = response;
      console.log(response);
    }, error => {
      console.log(error);
    })  
  }
  
}