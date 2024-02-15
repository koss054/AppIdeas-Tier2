import { SearchInfo } from "./search-info.model";
import { VolumeInfo } from "./volume-info.model";

export interface BookDetails {
  id?: string;
  etag?: string;
  selfLink?: string;
  volumeInfo: VolumeInfo;
  searchInfo: SearchInfo;
}
