import { Component } from '@angular/core';
import { BookService } from '../../_services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})

export class BookComponent {
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
  }
}
