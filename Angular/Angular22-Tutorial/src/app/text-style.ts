import { Directive, ElementRef, inject } from '@angular/core';

@Directive({
  selector: '[appTextStyle]',
   exportAs: 'appTextStyle'
})
export class TextStyle {
  private el = inject(ElementRef)

  constructor(){
     this.el.nativeElement.style.color = 'orange';
    this.el.nativeElement.style.fontWeight = 'bold';
  }

   changeStyle() {
    this.el.nativeElement.style.color = 'blue';
    this.el.nativeElement.style.fontStyle = 'italic';
  }
}
