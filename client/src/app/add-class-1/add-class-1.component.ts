import { Component, Injector } from '@angular/core';
import { AddClass1Generated } from './add-class-1-generated.component';

@Component({
  selector: 'page-add-class-1',
  templateUrl: './add-class-1.component.html'
})
export class AddClass1Component extends AddClass1Generated {
  constructor(injector: Injector) {
    super(injector);
  }
}
