import { Injectable } from "@angular/core";
import { map } from "rxjs";
import { BookModel } from "src/app/models/book.model";
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })
  export class ApiService {
    private baseURL: string = "https://localhost:44317/api/Book";
    constructor(private http: HttpClient) {
    }
  
    addBook(data: BookModel) {
      return this.http.post<BookModel>(`${this.baseURL}`, data)
        .pipe(map((result: BookModel) => {
          return result;
        },
          (err: any) => console.log("addBook does not work properly", err)))
    }
  
    getBooks() {
      return this.http.get<BookModel[]>(`${this.baseURL}`)
        .pipe(map((result: BookModel[]) => {
          return result;
        },
          (err: any) => console.log('getBooks does not work properly', err)))
    }
  
    updateBook(data: BookModel) {
      return this.http.put<BookModel>(`${this.baseURL}`, data)
        .pipe(map((result: BookModel) => {
          return result;
        },
          (err: any) => console.log("updateBook does not work properly", err)))
    }
  
    deleteBook(id: number) {
      return this.http.delete<BookModel>(`${this.baseURL}/${id}`)
        .pipe(map((result: BookModel) => {
          return result;
        },
          (err: any) => console.log("deleteBook does not work properly", err)))
    }
  }