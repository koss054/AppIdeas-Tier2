import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
}
