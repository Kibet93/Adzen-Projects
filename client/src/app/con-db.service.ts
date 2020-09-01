import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './con-db.model';

@Injectable()
export class ConDbService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('conDb');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getClass1S(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Class1s`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createClass1(expand: string | null, class1: models.Class1 | null) : Observable<any> {
    return this.odata.post(`/Class1s`, class1, { expand }, []);
  }

  deleteClass1(classId: number | null) : Observable<any> {
    return this.odata.delete(`/Class1s(${classId})`, item => !(item.ClassID == classId));
  }

  getClass1ByClassId(expand: string | null, classId: number | null) : Observable<any> {
    return this.odata.getById(`/Class1s(${classId})`, { expand });
  }

  updateClass1(expand: string | null, classId: number | null, class1: models.Class1 | null) : Observable<any> {
    return this.odata.patch(`/Class1s(${classId})`, class1, item => item.ClassID == classId, { expand }, []);
  }

  getGenders(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Genders`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createGender(expand: string | null, gender: models.Gender | null) : Observable<any> {
    return this.odata.post(`/Genders`, gender, { expand }, []);
  }

  deleteGender(genderId: number | null) : Observable<any> {
    return this.odata.delete(`/Genders(${genderId})`, item => !(item.GenderID == genderId));
  }

  getGenderByGenderId(expand: string | null, genderId: number | null) : Observable<any> {
    return this.odata.getById(`/Genders(${genderId})`, { expand });
  }

  updateGender(expand: string | null, genderId: number | null, gender: models.Gender | null) : Observable<any> {
    return this.odata.patch(`/Genders(${genderId})`, gender, item => item.GenderID == genderId, { expand }, []);
  }

  getStudents(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Students`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createStudent(expand: string | null, student: models.Student | null) : Observable<any> {
    return this.odata.post(`/Students`, student, { expand }, ['Gender', 'Class1']);
  }

  deleteStudent(studentId: number | null) : Observable<any> {
    return this.odata.delete(`/Students(${studentId})`, item => !(item.StudentID == studentId));
  }

  getStudentByStudentId(expand: string | null, studentId: number | null) : Observable<any> {
    return this.odata.getById(`/Students(${studentId})`, { expand });
  }

  updateStudent(expand: string | null, studentId: number | null, student: models.Student | null) : Observable<any> {
    return this.odata.patch(`/Students(${studentId})`, student, item => item.StudentID == studentId, { expand }, ['Gender','Class1']);
  }
}
