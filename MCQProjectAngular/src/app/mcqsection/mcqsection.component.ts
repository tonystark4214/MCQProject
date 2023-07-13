import { Component, HostListener, OnInit, Renderer2 } from '@angular/core';
import { ServiceService } from '../Service/service.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-mcqsection',
  templateUrl: './mcqsection.component.html',
  styleUrls: ['./mcqsection.component.css']
})
export class MCQSectionComponent implements OnInit {

  userName: any;
  questionContainer: boolean = false;
  IsInput: boolean = true;
  IsQuestion:boolean=true;
  IsResult:boolean=false;
  questionData: any
  counter: number = 1;
  box: any;
  str: any;
  className: any;
  i: number = 0;
  qAttempted: any = 0;
  Marks: number = 0;
  MarksArray = []
  Result: any = {}
  PostData:any={}
  GrandTotal:any;
  constructor(private service: ServiceService, private router: Router, private renderer: Renderer2) { }

  ngOnInit(): void { }

  StartTest() {
    this.IsInput = false;
    this.questionContainer = true;
    this.Result.userName = this.userName;

    this.service.GetQuestions().subscribe((res: any) => {
      this.questionData = res.question
      console.log(this.questionData);
      
    })
  }
  handleChange(change: any, index: any) {
    document.getElementsByClassName("")

    var target = change.target || change.srcElement || change.currentTarget;
    var idAttr = target.attributes.id;
    var value = idAttr.nodeValue;

    this.str = "option" + value;


    const elements = document.querySelectorAll('.form-check');

    elements.forEach((element) => {
      element.classList.remove('red');
      element.classList.remove('green');
    });

    this.box = document.getElementById(this.str);


    if (change.target.value == this.questionData[index].answer) {
      this.box.classList.remove('red');
      this.box.classList.add('green');
      this.Result["question" + parseInt(index + 1)] = 1
    }
    else {
      this.box.classList.remove('green');
      this.box.classList.add('red');
      this.Result["question" + parseInt(index + 1)] = 0

    }
    console.log(this.Result);

  }
  Submit() {
    this.Marks=0;
    this.qAttempted = (Object.values(this.Result).length-1)
    this.MarksArray = Object.values(this.Result)
    for (let i = 1; i <= this.qAttempted; i++) {
      this.Marks = this.Marks + parseInt(this.MarksArray[i]);
    }
    
    this.PostData.userName=this.userName;
    this.PostData.qAttempted=this.qAttempted;
    this.PostData.totalQ=this.questionData.length;
    this.PostData.correctQ=this.Marks
    this.GrandTotal=Math.round((this.Marks*100)/parseInt(this.questionData.length))
    console.log(this.PostData);
    this.service.PostUserData(this.PostData).subscribe((res)=>{
      console.log(res);
    })

    this.questionContainer=false;
    this.IsResult=true;

  }
  CloseResult(){
    this.router.navigate([''])
  }

}


