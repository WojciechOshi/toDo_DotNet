import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public todoitems: ToDoItem[] = [];
  public httpClient: HttpClient;
  public baseUrl: string;
  public toDoItemsForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.toDoItemsForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      cashValue: ['', Validators.required]
    });

    http.get<ToDoItem[]>(baseUrl + 'todoitem').subscribe(result => {
      this.todoitems = result;
    }, error => console.error(error));
  }

  onSubmit() {
    if (this.toDoItemsForm.valid) {
      const toDoItem = {
        Name: this.toDoItemsForm.value.name,
        Description: this.toDoItemsForm.value.description,
        CashValue: this.toDoItemsForm.value.cashValue,
        Date: new Date()
      };

      this.httpClient.post<any>(this.baseUrl + 'todoitem', toDoItem).subscribe(
        (toDoItemsResponse) => {
          this.todoitems = toDoItemsResponse;
        },
        error => {
          console.error(error);
        }
      );
    }
  }
}
interface ToDoItem {
  name: string;
  cashValue: number;
  description: string;
  date: string;
}
