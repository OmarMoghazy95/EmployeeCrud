export interface PaginationResponse<T> {
  totalCount: number;
  data: T[];
}
