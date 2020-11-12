import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { QuestionFormComponent } from './question-form/question-form.component';
import { UserQuestionListComponent } from './user-question-list/user-question-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'userquestions', component: UserQuestionListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const RoutingComponents = [
  NavMenuComponent,
  HomeComponent,
  QuestionFormComponent,
  UserQuestionListComponent,
];
