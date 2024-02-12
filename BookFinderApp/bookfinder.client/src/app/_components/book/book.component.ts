import { Component, ElementRef, ViewChild } from '@angular/core';
import { BookService } from '../../_services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})

export class BookComponent {
  @ViewChild('searchQuery', { static: false }) searchQuery: ElementRef | undefined;
  volumeId: string = 'buc0AAAAMAAJ';

  constructor(private bookService: BookService) { }

  onButtonClick(): void {
    this.bookService.getBookDetails(this.volumeId)
      .subscribe(
        (data) => {
          console.log('Book details:', data);
        },
        (error) => {
          console.error('Error:', error);
        }
      );
    const searchQueryValue = this.searchQuery?.nativeElement.value;
    this.bookService.getBooks(searchQueryValue)
      .subscribe(
        (data) => {
          console.log("Book query result: ", data);
        },
        (error) => {
          console.error('Error: ', error);
        }
      );
  }
}
