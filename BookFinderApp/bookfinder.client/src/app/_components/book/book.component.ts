import { Component, ElementRef, ViewChild } from '@angular/core';
import { BookService } from '../../_services/book.service';
import { BookList } from '../../_models/book-list.model';
import { BookDetails } from '../../_models/book-details.model';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})

export class BookComponent {
  @ViewChild('searchQuery', { static: false }) searchQuery: ElementRef | undefined;
  volumeId: string = 'buc0AAAAMAAJ';
  bookList: BookList = {
    kind: '',
    totalItems: 0,
    items: []
  }
  bookDetailsArray: BookDetails[] = [];

  constructor(private bookService: BookService) { }

  onButtonClick(): void {
    const searchQueryValue = this.searchQuery?.nativeElement.value;
    this.bookService.getBooks(searchQueryValue)
      .subscribe(
        (data) => {
          this.bookList = data;
          this.bookDetailsArray = this.bookList.items;
          console.log("Book query result: ", this.bookDetailsArray);
        },
        (error) => {
          console.error('Error: ', error);
        }
      );
  }
}
