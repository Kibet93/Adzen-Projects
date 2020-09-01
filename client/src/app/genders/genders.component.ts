import { Component, Injector } from '@angular/core';
import { GendersGenerated } from './genders-generated.component';

@Component({
  selector: 'page-genders',
  templateUrl: './genders.component.html'
})
export class GendersComponent extends GendersGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
