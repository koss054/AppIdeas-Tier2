import { ImageLinks } from "./image-links.model";

export interface VolumeInfo {
  title?: string;
  subtitle?: string;
  authors: string[];
  publisher?: string;
  publishedDate?: string;
  description?: string;
  pageCount: number;
  categories: string[];
  imageLinks: ImageLinks;
}
