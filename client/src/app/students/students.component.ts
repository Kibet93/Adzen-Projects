import { Component, Injector } from '@angular/core';
import { StudentsGenerated } from './students-generated.component';

@Component({
  selector: 'page-students',
  templateUrl: './students.component.html'
})
export class StudentsComponent extends StudentsGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
