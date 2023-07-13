import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MCQSectionComponent } from './mcqsection/mcqsection.component';
import { ShowUserComponent } from './show-user/show-user.component';
import { AddQuestionComponent } from './add-question/add-question.component';
const routes: Routes = [
  {
    path:"mcqsection",
    component:MCQSectionComponent
  },
  {
    path:"userList",
    component:ShowUserComponent
  },
  {
    path:'addQuestion',
    component:AddQuestionComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
