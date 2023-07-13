import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../Service/service.service';

@Component({
  selector: 'app-show-user',
  templateUrl: './show-user.component.html',
  styleUrls: ['./show-user.component.css']
})
export class ShowUserComponent implements OnInit {

  constructor(private service: ServiceService) { }

  userList: any

  ngOnInit(): void {
    this.GetUserList();
  }

  GetUserList() {
    this.service.GetUserList().subscribe((res: any) => {
      this.userList = res.userList;
      console.log(this.userList);
    })
  }
}
