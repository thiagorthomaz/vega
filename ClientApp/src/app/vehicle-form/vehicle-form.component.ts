import { MakeService } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makes : any[];
  models : any[];
  vehicle : any = {};

  constructor(private makeService : MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes =>{
        this.makes = makes as any[];
      }
    );    
  }

  OnMakeChanges() {
      console.log("VEHICLE", this.vehicle);
      var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
      this.models = selectedMake ? selectedMake.models : [];

  }

}
