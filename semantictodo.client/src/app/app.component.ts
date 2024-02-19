import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { API_BASE_URL, Category, Client } from '../data-access/dataAccessClient';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public categories: Category[] = []
  public title = 'semantictodo.client'
  public connection: HubConnection | undefined

  constructor(private dataAccessClient: Client, @Inject(API_BASE_URL) public baseUrl: string) {}

  ngOnInit() {
    this.initWebSocket();
    this.getTodos();
  }

  getTodos() {
     this.dataAccessClient.todo().subscribe(todos => {
      this.categories = todos
    })
  }

  initWebSocket() {
    this.connection = new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}/hub/todo`)
      .build();

      this.connection.on("updateTodos", (categories: Category[]) => {this.categories = categories})

      this.connection.start()
    }
}
