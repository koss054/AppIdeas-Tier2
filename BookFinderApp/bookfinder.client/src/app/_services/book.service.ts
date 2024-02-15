import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookList } from '../_models/book-list.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:7056/api/books';

  constructor(private http: HttpClient) { }

  getBookDetails(volumeId: string): Observable<any> {
    const url = `${this.apiUrl}/${volumeId}`;
    return this.http.get(url);
  }

  getBooks(queryValue: string): Observable<any> {
    const url = `${this.apiUrl}/search/${queryValue.trim()}`;
    return this.http.get<BookList[]>(url);
  }
}
