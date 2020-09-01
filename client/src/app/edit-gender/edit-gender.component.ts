import { Component, Injector } from '@angular/core';
import { EditGenderGenerated } from './edit-gender-generated.component';

@Component({
  selector: 'page-edit-gender',
  templateUrl: './edit-gender.component.html'
})
export class EditGenderComponent extends EditGenderGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
