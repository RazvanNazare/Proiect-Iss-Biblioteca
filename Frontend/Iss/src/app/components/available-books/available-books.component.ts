import { Component, OnInit } from '@angular/core';
import { BookModel } from 'src/app/models/book.model';
import { ApiService } from '../services/apiService';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-available-books',
  templateUrl: './available-books.component.html',
  styleUrls: ['./available-books.component.css']
})
export class AvailableBooksComponent implements OnInit {

  mockBooks: BookModel[];
  subscriptions: Subscription[] = [];


  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.getAllBooks();
  }

  getAllBooks() {
    this.subscriptions.push(
      this.api.getBooks()
        .subscribe(res => {
          this.mockBooks = res;
        }))
  }

  ngOnDestroy() {
    if (this.subscriptions.length == 0) return;
    for (let sub of this.subscriptions) {
      sub.unsubscribe();
    }
  }
}
