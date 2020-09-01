import { Component, Injector } from '@angular/core';
import { EditStudentGenerated } from './edit-student-generated.component';

@Component({
  selector: 'page-edit-student',
  templateUrl: './edit-student.component.html'
})
export class EditStudentComponent extends EditStudentGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
