import { Component, NgModule, ViewChild, Input, OnInit } from '@angular/core';
import { DomandaOutcome } from './model/domanda-outcome.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
 
  constructor() { }
 
  ngOnInit(): void {
  }
}