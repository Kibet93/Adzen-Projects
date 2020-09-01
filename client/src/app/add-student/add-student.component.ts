import { Component, Injector } from '@angular/core';
import { AddStudentGenerated } from './add-student-generated.component';

@Component({
  selector: 'page-add-student',
  templateUrl: './add-student.component.html'
})
export class AddStudentComponent extends AddStudentGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
