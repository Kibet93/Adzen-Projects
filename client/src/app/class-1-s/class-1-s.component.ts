import { Component, Injector } from '@angular/core';
import { Class1SGenerated } from './class-1-s-generated.component';

@Component({
  selector: 'page-class-1-s',
  templateUrl: './class-1-s.component.html'
})
export class Class1SComponent extends Class1SGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
