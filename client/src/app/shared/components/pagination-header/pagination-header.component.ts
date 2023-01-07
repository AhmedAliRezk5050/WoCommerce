import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';

@Component({
  selector: 'app-pagination-header',
  templateUrl: './pagination-header.component.html',
  styleUrls: ['./pagination-header.component.scss']
})
export class PaginationHeaderComponent implements OnChanges{
  @Input() pageIndex = 1;
  @Input() itemsCount = 0;
  @Input() pageSize = 6;
  paginationHeaderMsg = ''
  setPaginationHeaderMsg() {
    const pageSize = this.pageSize >= this.itemsCount ? this.itemsCount : this.pageSize;
    if (this.itemsCount === 0) {
      this.paginationHeaderMsg = 'There are 0 results'
      return;
    }

    if (this.pageIndex === 1) {
      this.paginationHeaderMsg = `Showing 1-${pageSize} of ${this.itemsCount}`
      return;
    }

    this.paginationHeaderMsg = `Showing ${(this.pageIndex - 1)*pageSize + 1} - ${this.pageIndex*pageSize} of ${this.itemsCount}`
    return;
  }


  ngOnChanges(changes: SimpleChanges): void {
    this.setPaginationHeaderMsg()
  }
}
