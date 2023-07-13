import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) { }

  GetSingleUser(id:number){
    return this.http.get("http://localhost:5156/GetSingleUser?id="+id);
  }
  GetUserList(){
    return this.http.get("http://localhost:5156/GetUserList");
  }

  GetQuestions(){
    return this.http.get("http://localhost:5156/GetQuestions");
  }

  PostUserData(data:any){
    return this.http.post("http://localhost:5156/PostUserData",data);
  }

  PostQuestion(data:any){
    return this.http.post("http://localhost:5156/PostQuestion",data);
  }
}
