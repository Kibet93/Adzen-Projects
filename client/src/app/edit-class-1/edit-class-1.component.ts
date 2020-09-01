import { Component, Injector } from '@angular/core';
import { EditClass1Generated } from './edit-class-1-generated.component';

@Component({
  selector: 'page-edit-class-1',
  templateUrl: './edit-class-1.component.html'
})
export class EditClass1Component extends EditClass1Generated {
  constructor(injector: Injector) {
    super(injector);
  }
}
