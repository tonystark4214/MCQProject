import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiceService } from '../Service/service.service';
@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {
  constructor(private router: Router, private service: ServiceService) { }
  PostForm: any = FormGroup;

  ngOnInit(): void {
    let builder = new FormBuilder();
    this.PostForm = builder.group({
      question: new FormControl("", Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(500)])),
      answer: new FormControl("", Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(500)])),
      option1: new FormControl("", Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(500)])),
      option2: new FormControl("", Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(500)])),
      option3: new FormControl("", Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(500)])),
      option4: new FormControl("", Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(500)])),
    })
  }
  PostQuestion(data:any){
    this.service.PostQuestion(data).subscribe((res:any)=>{
      console.log(res);
      if(res.message=="Question Added Succesfully"){
        alert(res.message)
        this.router.navigate(['/mcqsection'])
      }
      else{
        alert("Error")
      }
    })
  }
}
