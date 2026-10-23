import { Component, Input, OnChanges, Output, SimpleChanges, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-title',
  standalone: true,
  imports: [],
  templateUrl: './title.component.html',
  styleUrl: './title.component.scss'
})
export class TitleComponent implements OnChanges{
//interpolación de datos del hijo al padre
 @Input() title ='';
 //interpolación de datos del padre al hijo
 @Output() dataFromChild=new EventEmitter();

 ngOnChanges(changes: SimpleChanges): void {
  console.log(changes);
  this.dataFromChild.emit('data from child component');
 }
}
