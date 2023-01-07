import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent {
  @Input() pages: number[] = []
  @Input() pageIndex = 1;
  @Output() newPageIndex = new EventEmitter<number>();
}
