import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public todoitems: ToDoItem[] = [];
  public httpClient: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;

    http.get<ToDoItem[]>(baseUrl + 'todoitem').subscribe(result => {
      this.todoitems = result;
    }, error => console.error(error));
  };

  createToDoItem() {
    const item = {
      Name: 'Milena',
      Description: 'Kupiła cwelucha',
      CashValue: 420,
      Date: new Date()
    };

    this.httpClient.post<any>(this.baseUrl + 'todoitem', item).subscribe(
      () => {
        console.log('Item created successfully.');
      },
      error => {
        console.error(error);
      }
    );
  }
}

interface ToDoItem {
  name: string;
  cashValue: number;
  description: string;
  date: string;
}
