import { Component, Injector } from '@angular/core';
import { AddGenderGenerated } from './add-gender-generated.component';

@Component({
  selector: 'page-add-gender',
  templateUrl: './add-gender.component.html'
})
export class AddGenderComponent extends AddGenderGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
