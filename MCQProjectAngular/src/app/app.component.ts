import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from './Service/service.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private service:ServiceService){}

  IsSection:boolean=false;
  SearchForm:any= FormGroup;
  router: any;
  data:any="No Record";

  ngOnInit(): void {
    let builder = new FormBuilder();
    this.SearchForm = builder.group({
      Search: new FormControl("", Validators.required)
    })
  }
  Search(data: any) {
    this.service.GetSingleUser(data.Search).subscribe((res:any)=>{
      console.log(res);
      
      if(res.message=="User doesn't exist")
        alert(res.message)
      this.data=res.user;
    })
  }
 
}

