import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Owner } from '../models/owner.model';
import { Pet, PetType } from '../models/pet.model';
import {ArrayFirstOrDefaultPipe} from '../extensions/array-first-or-default.pipe';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OwnerService {
  pet1: Pet= {id:1,ownerId:1,age:2,name:"Duke",type:PetType.Dog};
  pet2: Pet ={id:2,ownerId:2,age:3,name:"Meenie",type:PetType.Rabbit};
  pet3: Pet ={id:3,ownerId:2,age:1,name:"Shaw",type:PetType.Cat};
  pet4: Pet ={id:4,ownerId:3,age:1,name:"Paw",type:PetType.Cat};
  owners: Array<Owner> = [
    { id:1,firstName:"Jes",lastName: "J",pets: [this.pet1]},
    { id:2,firstName:"Teza",lastName: "A",pets: [this.pet2,this.pet3]},
    { id:3,firstName:"Roy",lastName: null,pets: [this.pet4]}
  ];
 
  constructor(private arrFirstOrDefault: ArrayFirstOrDefaultPipe, private http: HttpClient) { }
  
  getAll() {
    //return of(this.owners);
    return this.http
      .get<Array<Owner>>(`api/owner`)
      .pipe(map(resp => resp));
  }

  getById(id:number) {
    return of(this.arrFirstOrDefault.transform(this.owners,id));
  }

  save(data: Owner): Observable<any> {
     return this.http
       .post<any>(`api/owner`, data)
       .pipe(map(res => res));
  }

  savePet(data: Pet): Observable<any> {
    return this.http
      .post<any>(`api/owner/pet`, data)
      .pipe(map(res => res));
  }
}
