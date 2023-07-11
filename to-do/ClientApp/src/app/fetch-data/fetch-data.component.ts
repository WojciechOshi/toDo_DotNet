import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public todoitems: ToDoItem[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ToDoItem[]>(baseUrl + 'todoitem').subscribe(result => {
      this.todoitems = result;
    }, error => console.error(error));
  }
}

interface ToDoItem {
  name: string;
  cashValue: number;
  description: string;
  date: string;
}
