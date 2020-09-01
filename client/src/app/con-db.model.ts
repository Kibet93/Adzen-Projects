export interface Class1 {
  ClassID: number;
  ClassName: string;
}

export interface Gender {
  GenderID: number;
  Gender1: string;
}

export interface Student {
  StudentID: number;
  FirstName: string;
  MiddleName: string;
  Surname: string;
  GenderID: number;
  Photo: string;
  CurrentClassID: number;
}
