import { BookDetails } from "./book-details.model";

export interface BookList {
  kind: string;
  totalItems: number;
  items: BookDetails[];
}
