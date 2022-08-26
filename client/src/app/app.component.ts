import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = "Web Chat";
  display = false;

  constructor(private http:HttpClient) {}

  ngOnInit() {
  }

  onPress() {
    //this.display = true;

    //To toggle the component
    this.display = !this.display;
  }
}
