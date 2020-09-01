import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { Class1SComponent } from './class-1-s/class-1-s.component';
import { AddClass1Component } from './add-class-1/add-class-1.component';
import { EditClass1Component } from './edit-class-1/edit-class-1.component';
import { GendersComponent } from './genders/genders.component';
import { AddGenderComponent } from './add-gender/add-gender.component';
import { EditGenderComponent } from './edit-gender/edit-gender.component';
import { StudentsComponent } from './students/students.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { EditStudentComponent } from './edit-student/edit-student.component';
import { ApplicationUsersComponent } from './application-users/application-users.component';
import { ApplicationRolesComponent } from './application-roles/application-roles.component';
import { RegisterApplicationUserComponent } from './register-application-user/register-application-user.component';
import { LoginComponent } from './login/login.component';
import { AddApplicationRoleComponent } from './add-application-role/add-application-role.component';
import { AddApplicationUserComponent } from './add-application-user/add-application-user.component';
import { EditApplicationUserComponent } from './edit-application-user/edit-application-user.component';
import { ProfileComponent } from './profile/profile.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

import { SecurityService } from './security.service';
import { AuthGuard } from './auth.guard';
export const routes: Routes = [
  { path: '', redirectTo: '/class-1-s', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'class-1-s',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: Class1SComponent
      },
      {
        path: 'add-class-1',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddClass1Component
      },
      {
        path: 'edit-class-1/:ClassID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditClass1Component
      },
      {
        path: 'genders',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: GendersComponent
      },
      {
        path: 'add-gender',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddGenderComponent
      },
      {
        path: 'edit-gender/:GenderID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditGenderComponent
      },
      {
        path: 'students',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: StudentsComponent
      },
      {
        path: 'add-student',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddStudentComponent
      },
      {
        path: 'edit-student/:StudentID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditStudentComponent
      },
      {
        path: 'application-users',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ApplicationUsersComponent
      },
      {
        path: 'application-roles',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ApplicationRolesComponent
      },
      {
        path: 'register-application-user',
        data: {
          roles: ['Everybody'],
        },
        component: RegisterApplicationUserComponent
      },
      {
        path: 'add-application-role',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddApplicationRoleComponent
      },
      {
        path: 'add-application-user',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddApplicationUserComponent
      },
      {
        path: 'edit-application-user/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditApplicationUserComponent
      },
      {
        path: 'profile',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ProfileComponent
      },
      {
        path: 'unauthorized',
        data: {
          roles: ['Everybody'],
        },
        component: UnauthorizedComponent
      },
    ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        data: {
          roles: ['Everybody'],
        },
        component: LoginComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
